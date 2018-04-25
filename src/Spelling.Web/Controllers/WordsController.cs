//-----------------------------------------------------------------------
// <copyright file="WordsController.cs" company="Gabriel Castillo">
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
    /// Words Controller
    /// </summary>
    /// <seealso cref="Beto.Core.Web.Api.Controllers.BaseApiController" />
    [Route("api/v1/words")]
    public class WordsController : BaseApiController
    {
        /// <summary>
        /// The word service
        /// </summary>
        private readonly IWordService wordService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordsController"/> class.
        /// </summary>
        /// <param name="messageExceptionFinder">The message exception finder.</param>
        /// <param name="wordService">The word service.</param>
        public WordsController(
            IMessageExceptionFinder messageExceptionFinder,
            IWordService wordService) : base(messageExceptionFinder)
        {
            this.wordService = wordService;
        }

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>the action</returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] WordFilterModel filter)
        {
            var words = await this.wordService.GetAllAsync(
                filter.GroupType, 
                filter.OrderByEnum,
                filter.Page, 
                filter.PageSize);

            var models = words.ToModels();

            return this.Ok(models, words.HasNextPage, words.TotalCount);
        }
    }
}