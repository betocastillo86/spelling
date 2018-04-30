//-----------------------------------------------------------------------
// <copyright file="BestScoresController.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Web.Controllers
{
    using System.Threading.Tasks;
    using Beto.Core.Exceptions;
    using Beto.Core.Web.Api.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Spelling.Business.Services;
    using Spelling.Models;
    using Spelling.Web.Extensions.Models;

    /// <summary>
    /// Best Scores Controller
    /// </summary>
    /// <seealso cref="Beto.Core.Web.Api.Controllers.BaseApiController" />
    [Route("api/v1/bestscores")]
    public class BestScoresController : BaseApiController
    {
        /// <summary>
        /// The game service
        /// </summary>
        private readonly IGameService gameService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BestScoresController"/> class.
        /// </summary>
        /// <param name="messageExceptionFinder">The message exception finder.</param>
        /// <param name="gameService">The game service.</param>
        public BestScoresController(
            IMessageExceptionFinder messageExceptionFinder,
            IGameService gameService) : base(messageExceptionFinder)
        {
            this.gameService = gameService;
        }

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>the action</returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery]BestScoreFilterModel filter)
        {
            var scores = await this.gameService.GetBestScoresAsync(
                userId: filter.UserId,
                groupType: filter.GroupType,
                page: filter.Page,
                pageSize: filter.PageSize);

            var models = scores.ToModels();

            return this.Ok(models, scores.HasNextPage, scores.TotalCount);
        }
    }
}