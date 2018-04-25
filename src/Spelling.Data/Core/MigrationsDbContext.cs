//-----------------------------------------------------------------------
// <copyright file="MigrationsDbContext.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Data.Core
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    /// <summary>
    /// Migration Db Context
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory{Spelling.Data.SpellingContext}" />
    public class MigrationsDbContext : IDesignTimeDbContextFactory<SpellingContext>
    {
        /// <summary>
        /// Creates a new instance of a derived context.
        /// </summary>
        /// <param name="args">Arguments provided by the design-time service.</param>
        /// <returns>
        /// An instance of <typeparamref name="TContext" />.
        /// </returns>
        public SpellingContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SpellingContext>();
            builder.UseSqlServer("Server=localhost;Database=Spelling;User Id=sa;Password=Temporal1;MultipleActiveResultSets=false");
            return new SpellingContext(builder.Options);
        }
    }
}