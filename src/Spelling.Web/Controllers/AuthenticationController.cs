//-----------------------------------------------------------------------
// <copyright file="AuthenticationController.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Web.Controllers
{
    using Beto.Core.Exceptions;
    using Beto.Core.Web.Api.Controllers;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Authentication Controller
    /// </summary>
    /// <seealso cref="Beto.Core.Web.Api.Controllers.BaseApiController" />
    [Route("api/v1/auth/current")]
    public class AuthenticationController : BaseApiController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
        /// </summary>
        /// <param name="messageExceptionFinder">The message exception finder.</param>
        public AuthenticationController(IMessageExceptionFinder messageExceptionFinder) : base(messageExceptionFinder)
        {
        }
    }
}