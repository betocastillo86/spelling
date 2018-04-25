//-----------------------------------------------------------------------
// <copyright file="UserMapping.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Data.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Spelling.Domain;

    /// <summary>
    /// User Mapping
    /// </summary>
    public static class UserMapping
    {
        /// <summary>
        /// Maps the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public static void Map(this EntityTypeBuilder<User> entity)
        {
            entity.Property(e => e.CreationDate).HasColumnType("datetime");

            entity.Property(e => e.Email)
               .HasMaxLength(150);

            entity.Property(e => e.Password)
               .HasMaxLength(50);

            entity.Property(e => e.Salt)
               .HasMaxLength(6);
        }
    }
}