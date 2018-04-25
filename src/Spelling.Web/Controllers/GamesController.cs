//-----------------------------------------------------------------------
// <copyright file="GamesController.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Beto.Core.Exceptions;
    using Beto.Core.Web.Api.Controllers;
    using Beto.Core.Web.Api.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Spelling.Business.Exceptions;
    using Spelling.Business.Security;
    using Spelling.Business.Services;
    using Spelling.Domain;
    using Spelling.Models;
    using Spelling.Web.Extensions.Models;

    /// <summary>
    /// Games Controller
    /// </summary>
    /// <seealso cref="Beto.Core.Web.Api.Controllers.BaseApiController" />
    [Route("api/v1/games")]
    public class GamesController : BaseApiController
    {
        /// <summary>
        /// The game service
        /// </summary>
        private readonly IGameService gameService;

        /// <summary>
        /// The work context
        /// </summary>
        private readonly IWorkContext workContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="GamesController"/> class.
        /// </summary>
        /// <param name="messageExceptionFinder">The message exception finder.</param>
        /// <param name="gameService">The game service.</param>
        /// <param name="workContext">The work context.</param>
        public GamesController(
            IMessageExceptionFinder messageExceptionFinder,
            IGameService gameService,
            IWorkContext workContext) : base(messageExceptionFinder)
        {
            this.gameService = gameService;
            this.workContext = workContext;
        }

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>the action</returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery]GameFilterModel filter)
        {
            if (this.workContext.CurrentUserId != filter.UserId)
            {
                return this.Forbid();
            }

            var games = await this.gameService.GetAllAsync(
                userId: filter.UserId,
                groupType: filter.GroupType,
                orderBy: filter.OrderByEnum,
                page: filter.Page,
                pageSize: filter.PageSize);

            var models = games.ToModels();

            return this.Ok(models, games.HasNextPage, games.TotalCount);
        }

        /// <summary>
        /// Posts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>the action</returns>
        [HttpPost]
        [Authorize]
        [RequiredModel]
        public async Task<IActionResult> Post([FromBody] GameModel model)
        {
            var game = new Game
            {
                Language = model.OriginLanguage.Value,
                GroupType = model.GroupType.Value,
                Negatives = model.Negatives,
                Positives = model.Positives,
                Time = model.Time,
                Total = model.Total,
                UserId = this.workContext.CurrentUserId
            };

            try
            {
                await this.gameService.InsertAsync(game);

                // TODO: Pasar a subscriber
                await this.UpdateBestScores(game);

                return this.Ok(new BaseModel { Id = game.Id });
            }
            catch (SpellingException e)
            {
                return this.BadRequest(e);
            }
        }

        /// <summary>
        /// Updates the best scores.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <returns>the task</returns>
        private async Task UpdateBestScores(Game game)
        {
            await this.gameService.UpdateBestScore(game);
        }
    }
}