//-----------------------------------------------------------------------
// <copyright file="AuthenticationController.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Web.Controllers
{
    using Beto.Core.Exceptions;
    using Beto.Core.Web.Api.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Spelling.Business.Security;
    using Spelling.Web.Extensions.Models;

    /// <summary>
    /// Authentication Controller
    /// </summary>
    /// <seealso cref="Beto.Core.Web.Api.Controllers.BaseApiController" />
    [Route("api/v1/auth/current")]
    public class AuthenticationController : BaseApiController
    {
        /// <summary>
        /// The work context
        /// </summary>
        private readonly IWorkContext workContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
        /// </summary>
        /// <param name="messageExceptionFinder">The message exception finder.</param>
        /// <param name="workContext">The work context.</param>
        public AuthenticationController(
            IMessageExceptionFinder messageExceptionFinder,
            IWorkContext workContext) : base(messageExceptionFinder)
        {
            this.workContext = workContext;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>the action</returns>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var model = this.workContext.CurrentUser.ToModel();
            return this.Ok(model);
        }
    }
}