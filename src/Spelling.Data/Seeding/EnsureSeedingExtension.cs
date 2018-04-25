//-----------------------------------------------------------------------
// <copyright file="EnsureSeedingExtension.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Data.Seeding
{
    using System.Linq;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <summary>
    /// Ensure seeding extensions
    /// </summary>
    public static class EnsureSeedingExtension
    {
        /// <summary>
        /// Ensures the seeding.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="host">The host.</param>
        /// <param name="builder">The builder.</param>
        public static void EnsureSeeding(this SpellingContext context, IHostingEnvironment host, IApplicationBuilder builder)
        {
            if (EnsureSeedingExtension.AreAllMigrationsApplied(context))
            {
                EnsureSeedingExtension.Seed(context, host, builder);
            }
        }

        /// <summary>
        /// Ares all migrations applied.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>if the migrations were applied</returns>
        private static bool AreAllMigrationsApplied(SpellingContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        /// <summary>
        /// Seeds the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="host">The host.</param>
        /// <param name="builder">The builder.</param>
        private static void Seed(SpellingContext context, IHostingEnvironment host, IApplicationBuilder builder)
        {
            SeedUsers.Seed(context);
        }
    }
}