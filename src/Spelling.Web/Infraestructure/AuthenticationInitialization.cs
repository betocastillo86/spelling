//-----------------------------------------------------------------------
// <copyright file="AuthenticationInitialization.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Web.Infraestructure
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Authentication Initialization
    /// </summary>
    public static class AuthenticationInitialization
    {
        /// <summary>
        /// Registers the authentication services.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void RegisterAuthenticationServices(this IServiceCollection services)
        {
            services.AddAuthentication(Microsoft.AspNetCore.Server.HttpSys.HttpSysDefaults.AuthenticationScheme)
                .AddOAuthValidation(Microsoft.AspNetCore.Server.HttpSys.HttpSysDefaults.AuthenticationScheme)
                .AddOpenIdConnectServer(c =>
                {
                    c.Provider = new SpellingAuthorizationProvider();

                    c.AccessTokenLifetime = new System.TimeSpan(150, 0, 0);

                    // Enable the authorization and token endpoints.
                    c.TokenEndpointPath = "/api/v1/auth";

                    c.AllowInsecureHttp = true;
                });
        }

        /// <summary>
        /// Configures the authentication.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void ConfigureAuthentication(this IApplicationBuilder app)
        {
            app.UseAuthentication();
        }
    }
}