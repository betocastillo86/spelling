//-----------------------------------------------------------------------
// <copyright file="SpellingAuthorizationProvider.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Web.Infraestructure
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AspNet.Security.OpenIdConnect.Extensions;
    using AspNet.Security.OpenIdConnect.Primitives;
    using AspNet.Security.OpenIdConnect.Server;
    using Microsoft.AspNetCore.Authentication;
    using Spelling.Business.Services;

    /// <summary>
    /// Spelling Authorization Provider
    /// </summary>
    /// <seealso cref="AspNet.Security.OpenIdConnect.Server.OpenIdConnectServerProvider" />
    public class SpellingAuthorizationProvider : OpenIdConnectServerProvider
    {
        /// <summary>
        /// Represents an event called for each validated token request
        /// to allow the user code to decide how the request should be handled.
        /// </summary>
        /// <param name="context">The context instance associated with this event.</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task" /> that can be used to monitor the asynchronous operation.
        /// </returns>
        public override async Task HandleTokenRequest(HandleTokenRequestContext context)
        {
            if (context.Request.IsPasswordGrantType())
            {
                var userService = (IUserService)context.HttpContext.RequestServices.GetService(typeof(IUserService));

                var user = await userService.ValidateAuthentication(context.Request.Username, context.Request.Password);

                if (user != null)
                {
                    var identity = new ClaimsIdentity(context.Scheme.Name);

                    identity.AddClaim(OpenIdConnectConstants.Claims.Subject, user.Id.ToString());
                    identity.AddClaim(OpenIdConnectConstants.Claims.Email, user.Email);

                    var ticket = new AuthenticationTicket(
                        new ClaimsPrincipal(identity),
                        new AuthenticationProperties(),
                        context.Scheme.Name);

                    ticket.SetScopes(
                        OpenIdConnectConstants.Scopes.OpenId,
                        OpenIdConnectConstants.Scopes.Email,
                        OpenIdConnectConstants.Scopes.Profile);

                    ticket.SetResources("http://spelling.tuils.com");

                    context.Validate(ticket);
                }
                else
                {
                    context.Reject(
                        error: OpenIdConnectConstants.Errors.AccessDenied,
                        description: "Los datos ingresados son invalidos");
                }
            }
        }

        /// <summary>
        /// Represents an event called for each request to the token endpoint
        /// to determine if the request is valid and should continue to be processed.
        /// </summary>
        /// <param name="context">The context instance associated with this event.</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task" /> that can be used to monitor the asynchronous operation.
        /// </returns>
        public override Task ValidateTokenRequest(ValidateTokenRequestContext context)
        {
            // Reject the token requests that don't use grant_type=password or grant_type=refresh_token.
            if (!context.Request.IsPasswordGrantType())
            {
                context.Reject(
                           error: OpenIdConnectConstants.Errors.InvalidClient,
                           description: "Tipo de autenticación inválida");

                return Task.FromResult(0);
            }

            context.Skip();

            return Task.FromResult(0);
        }
    }
}