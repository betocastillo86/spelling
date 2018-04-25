//-----------------------------------------------------------------------
// <copyright file="GameMapping.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Data.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Spelling.Domain;

    /// <summary>
    /// Game Mapping
    /// </summary>
    public static class GameMapping
    {
        /// <summary>
        /// Maps the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public static void Map(this EntityTypeBuilder<Game> entity)
        {
            entity.Property(e => e.CreationDate).HasColumnType("datetime");

            entity.Property(e => e.OriginLanguage)
               .HasMaxLength(50);
        }
    }
}