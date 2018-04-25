//-----------------------------------------------------------------------
// <copyright file="AnswerMapping.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Data.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Spelling.Domain;

    /// <summary>
    /// Answer Mapping
    /// </summary>
    public static class AnswerMapping
    {
        /// <summary>
        /// Maps the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public static void Map(this EntityTypeBuilder<Answer> entity)
        {
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
        }
    }
}