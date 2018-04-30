//-----------------------------------------------------------------------
// <copyright file="UserExtensions.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Web.Extensions.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Spelling.Domain;
    using Spelling.Models;

    /// <summary>
    /// User Extensions
    /// </summary>
    public static class UserExtensions
    {
        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>the model</returns>
        public static UserModel ToModel(this User entity)
        {
            return new UserModel
            {
                Email = entity.Email,
                Id = entity.Id
            };
        }

        /// <summary>
        /// To the models.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>the models</returns>
        public static IList<UserModel> ToModels(this ICollection<User> entities)
        {
            return entities.Select(ToModel).ToList();
        }
    }
}