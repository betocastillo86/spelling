//-----------------------------------------------------------------------
// <copyright file="SystemSettingMapping.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Data.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Spelling.Domain;

    /// <summary>
    /// System Setting Mapping
    /// </summary>
    public static class SystemSettingMapping
    {
        /// <summary>
        /// Maps the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public static void Map(this EntityTypeBuilder<SystemSetting> entity)
        {
            entity.ToTable("SystemSettings");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            entity.Property(e => e.Value).IsRequired();
        }
    }
}