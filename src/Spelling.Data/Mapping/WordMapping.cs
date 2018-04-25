//-----------------------------------------------------------------------
// <copyright file="WordMapping.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Data.Mapping
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Spelling.Domain;

    /// <summary>
    /// Word Mapping
    /// </summary>
    public static class WordMapping
    {
        /// <summary>
        /// Maps the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public static void Map(this EntityTypeBuilder<Word> entity)
        {
            entity.Property(e => e.Spanish)
               .HasMaxLength(600);

            entity.Property(e => e.English)
               .HasMaxLength(600);
        }
    }
}