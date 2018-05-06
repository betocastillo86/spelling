//-----------------------------------------------------------------------
// <copyright file="SeedUsers.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Spelling.Domain;

    /// <summary>
    /// Seed Users
    /// </summary>
    public static class SeedUsers
    {
        /// <summary>
        /// Seeds the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public static void Seed(SpellingContext context)
        {
            var users = new List<User>();

            users.Add(new User { Email = "admin@admin.com", Password = "de0395eac174d64f431eb79a30e3dac76cb936f4", Salt = "123456", CreationDate = DateTime.UtcNow });
            users.Add(new User { Email = "gabriel.castillo86@gmail.com", Password = "de0395eac174d64f431eb79a30e3dac76cb936f4", Salt = "123456", CreationDate = DateTime.UtcNow });
            users.Add(new User { Email = "erica.estefanny@gmail.com", Password = "de0395eac174d64f431eb79a30e3dac76cb936f4", Salt = "123456", CreationDate = DateTime.UtcNow });

            foreach (var item in users)
            {
                if (!context.Users.Any(c => c.Email.Equals(item.Email)))
                {
                    context.Users.Add(item);
                }
            }

            context.SaveChanges();
        }
    }
}