//-----------------------------------------------------------------------
// <copyright file="DatabaseInitialization.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Web.Infraestructure
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Spelling.Data;
    using Spelling.Data.Seeding;

    /// <summary>
    /// Database Initialization
    /// </summary>
    public static class DatabaseInitialization
    {
        /// <summary>
        /// Initializes the database.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public static void InitDatabase(this IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        { 
            using (var context = (SpellingContext)serviceProvider.GetService(typeof(SpellingContext)))
            {
                context.Database.EnsureCreated();
                context.EnsureSeeding(env, app);
            }
        }
    }
}