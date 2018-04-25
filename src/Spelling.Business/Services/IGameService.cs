//-----------------------------------------------------------------------
// <copyright file="IGameService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Business.Services
{
    using System.Threading.Tasks;
    using Beto.Core.Data;
    using Spelling.Domain;

    /// <summary>
    /// Game Service
    /// </summary>
    public interface IGameService
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupType">Type of the group.</param>
        /// <param name="originLanguage">The origin language.</param>
        /// <param name="orderBy">order by game</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>the game</returns>
        IPagedList<Game> GetAll(
            int? userId = null,
            GroupType? groupType = null,
            Language? originLanguage = null,
            OrderByGame orderBy = OrderByGame.Newest,
            int page = 0,
            int pageSize = int.MaxValue);

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupType">Type of the group.</param>
        /// <param name="originLanguage">The origin language.</param>
        /// <param name="orderBy">order by game</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>the games</returns>
        Task<IPagedList<Game>> GetAllAsync(
            int? userId = null,
            GroupType? groupType = null,
            Language? originLanguage = null,
            OrderByGame orderBy = OrderByGame.Newest,
            int page = 0,
            int pageSize = int.MaxValue);

        /// <summary>
        /// Gets the best scores.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupType">Type of the group.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>the scores</returns>
        IPagedList<BestScore> GetBestScores(
            int? userId = null,
            GroupType? groupType = null,
            int page = 0,
            int pageSize = int.MaxValue);

        /// <summary>
        /// Inserts the asynchronous.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <returns>the task</returns>
        Task InsertAsync(Game game);

        /// <summary>
        /// Inserts the best score.
        /// </summary>
        /// <param name="bestScore">The best score.</param>
        /// <returns>the task</returns>
        Task InsertBestScoreAsync(BestScore bestScore);

        /// <summary>
        /// Updates the best score.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <returns>the task</returns>
        Task UpdateBestScore(Game game);
    }
}