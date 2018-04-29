//-----------------------------------------------------------------------
// <copyright file="ServiceRegister.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Web.Infraestructure
{
    using Beto.Core.Caching;
    using Beto.Core.Data;
    using Beto.Core.Data.Configuration;
    using Beto.Core.Exceptions;
    using Beto.Core.Helpers;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using Spelling.Business.Configuration;
    using Spelling.Business.Exceptions;
    using Spelling.Business.Security;
    using Spelling.Business.Services;
    using Spelling.Data;

    /// <summary>
    /// Service Register
    /// </summary>
    public static class ServiceRegister
    {
        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void RegisterServices(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddDbContext<SpellingContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //// Settings

            services.AddScoped<IGeneralSettings, GeneralSettings>();

            //// Services

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IWordService, WordService>();

            services.AddScoped<IGameService, GameService>();

            services.AddScoped<ILoggerService, LogService>();

            //// Core

            services.AddScoped<IWorkContext, WorkContext>();

            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

            services.AddScoped<IMessageExceptionFinder, MessageExceptionFinder>();

            services.AddScoped<IDbContext, SpellingContext>();

            services.AddScoped<IHttpContextHelper, HttpContextHelper>();

            services.AddScoped<ICacheManager, MemoryCacheManager>();

            services.AddScoped<ICoreSettingService, CoreSettingService>();

            //// .Net

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}