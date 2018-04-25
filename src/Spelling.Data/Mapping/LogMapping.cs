//-----------------------------------------------------------------------
// <copyright file="LogMapping.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Data.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Spelling.Domain;

    /// <summary>
    /// Log Mapping
    /// </summary>
    public static class LogMapping
    {
        /// <summary>
        /// Maps the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public static void Map(this EntityTypeBuilder<Log> entity)
        {
            entity.Property(e => e.FullMessage).IsRequired();

            entity.Property(e => e.IpAddress).HasColumnType("varchar(100)");

            entity.Property(e => e.PageUrl).HasColumnType("varchar(500)");

            entity.Property(e => e.ShortMessage).IsRequired();

            entity.HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Log_User_UserId");
        }
    }
}