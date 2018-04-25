//-----------------------------------------------------------------------
// <copyright file="SpellingContext.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Data
{
    using Beto.Core.Data;
    using Microsoft.EntityFrameworkCore;
    using Spelling.Data.Mapping;
    using Spelling.Domain;

    /// <summary>
    /// Spelling Context
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    /// <seealso cref="Beto.Core.Data.IDbContext" />
    public class SpellingContext : DbContext, IDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpellingContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public SpellingContext(DbContextOptions<SpellingContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the answers.
        /// </summary>
        /// <value>
        /// The answers.
        /// </value>
        public virtual DbSet<Answer> Answers { get; set; }

        /// <summary>
        /// Gets or sets the best scores.
        /// </summary>
        /// <value>
        /// The best scores.
        /// </value>
        public virtual DbSet<BestScore> BestScores { get; set; }

        /// <summary>
        /// Gets or sets the games.
        /// </summary>
        /// <value>
        /// The games.
        /// </value>
        public virtual DbSet<Game> Games { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the words.
        /// </summary>
        /// <value>
        /// The words.
        /// </value>
        public virtual DbSet<Word> Words { get; set; }

        /// <summary>
        /// Gets or sets the system settings.
        /// </summary>
        /// <value>
        /// The system settings.
        /// </value>
        public virtual DbSet<SystemSetting> SystemSettings { get; set; }

        /// <summary>
        /// Gets or sets the logs.
        /// </summary>
        /// <value>
        /// The logs.
        /// </value>
        public virtual DbSet<Log> Logs { get; set; }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>().Map();
            modelBuilder.Entity<BestScore>().Map();
            modelBuilder.Entity<Game>().Map();
            modelBuilder.Entity<User>().Map();
            modelBuilder.Entity<Word>().Map();
            modelBuilder.Entity<SystemSetting>().Map();
            modelBuilder.Entity<Log>().Map();
        }
    }
}