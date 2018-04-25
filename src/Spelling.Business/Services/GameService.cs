//-----------------------------------------------------------------------
// <copyright file="GameService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Business.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Beto.Core.Data;
    using Spelling.Domain;

    /// <summary>
    /// Game Service
    /// </summary>
    /// <seealso cref="Spelling.Business.Services.IGameService" />
    public class GameService : IGameService
    {
        /// <summary>
        /// The best score repository
        /// </summary>
        private readonly IRepository<BestScore> bestScoreRepository;

        /// <summary>
        /// The game repository
        /// </summary>
        private readonly IRepository<Game> gameRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameService"/> class.
        /// </summary>
        /// <param name="gameRepository">The game repository.</param>
        /// <param name="bestScoreRepository">The best score repository.</param>
        public GameService(
            IRepository<Game> gameRepository,
            IRepository<BestScore> bestScoreRepository)
        {
            this.gameRepository = gameRepository;
            this.bestScoreRepository = bestScoreRepository;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupType">Type of the group.</param>
        /// <param name="originLanguage">The origin language.</param>
        /// <param name="orderBy">order by game</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// the game
        /// </returns>
        public IPagedList<Game> GetAll(
            int? userId = null,
            GroupType? groupType = null,
            Language? originLanguage = null,
            OrderByGame orderBy = OrderByGame.Newest,
            int page = 0,
            int pageSize = int.MaxValue)
        {
            return new PagedList<Game>(this.GetAllQuery(userId, groupType, originLanguage), page, pageSize);
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupType">Type of the group.</param>
        /// <param name="originLanguage">The origin language.</param>
        /// <param name="orderBy">order by game</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// the games
        /// </returns>
        public async Task<IPagedList<Game>> GetAllAsync(
            int? userId = null,
            GroupType? groupType = null,
            Language? originLanguage = null,
            OrderByGame orderBy = OrderByGame.Newest,
            int page = 0,
            int pageSize = int.MaxValue)
        {
            return await new PagedList<Game>().Async(this.GetAllQuery(userId, groupType, originLanguage), page, pageSize);
        }

        /// <summary>
        /// Gets the best scores.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupType">Type of the group.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// the scores
        /// </returns>
        public IPagedList<BestScore> GetBestScores(int? userId = null, GroupType? groupType = null, int page = 0, int pageSize = int.MaxValue)
        {
            var query = this.bestScoreRepository.TableNoTracking;

            if (!userId.HasValue)
            {
                query = query.Where(c => c.UserId == userId);
            }

            if (!groupType.HasValue)
            {
                query = query.Where(c => c.GroupId == Convert.ToInt16(groupType));
            }

            return new PagedList<BestScore>(query, page, pageSize);
        }

        /// <summary>
        /// Inserts the asynchronous.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <returns>
        /// the task
        /// </returns>
        public async Task InsertAsync(Game game)
        {
            game.CreationDate = DateTime.UtcNow;

            await this.gameRepository.InsertAsync(game);
        }

        /// <summary>
        /// Inserts the best score.
        /// </summary>
        /// <param name="bestScore">The best score.</param>
        /// <returns>
        /// the task
        /// </returns>
        public async Task InsertBestScoreAsync(BestScore bestScore)
        {
            await this.bestScoreRepository.InsertAsync(bestScore);
        }

        /// <summary>
        /// Updates the best score.
        /// </summary>
        /// <param name="game">The last game.</param>
        /// <returns>
        /// the task
        /// </returns>
        public async Task UpdateBestScore(Game game)
        {
            var topScore = this.bestScoreRepository.TableNoTracking
                .FirstOrDefault(c => c.UserId == game.UserId && c.GroupId == game.GroupId);

            if (topScore == null)
            {
                await this.InsertBestScoreAsync(new BestScore
                {
                    GroupType = game.GroupType,
                    Points = game.Positives,
                    Time = game.Time,
                    UserId = game.UserId,
                    GameCreationDate = game.CreationDate
                });
            }
            else if (topScore.Points < game.Positives)
            {
                topScore.Points = game.Positives;
                topScore.Time = game.Time;
                topScore.GameCreationDate = game.CreationDate;

                await this.bestScoreRepository.UpdateAsync(topScore);
            }
        }

        /// <summary>
        /// Gets all query.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupType">Type of the group.</param>
        /// <param name="originLanguage">The origin language.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns>the query</returns>
        private IQueryable<Game> GetAllQuery(
            int? userId = null,
            GroupType? groupType = null,
            Language? originLanguage = null,
            OrderByGame orderBy = OrderByGame.Newest)
        {
            var query = this.gameRepository.TableNoTracking;

            if (userId.HasValue)
            {
                query = query.Where(c => c.UserId == userId.Value);
            }

            if (groupType.HasValue)
            {
                query = query.Where(c => c.GroupId == Convert.ToInt16(groupType));
            }

            if (originLanguage.HasValue)
            {
                query = query.Where(c => c.OriginLanguage.Equals(originLanguage.ToString()));
            }

            switch (orderBy)
            {
                case OrderByGame.Newest:
                    query = query.OrderByDescending(c => c.CreationDate);
                    break;

                case OrderByGame.Top:
                    query = query.OrderByDescending(c => c.Positives);
                    break;

                default:
                    query = query.OrderBy(c => c.Id);
                    break;
            }

            return query;
        }
    }
}