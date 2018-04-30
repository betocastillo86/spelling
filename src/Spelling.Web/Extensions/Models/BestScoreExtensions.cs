//-----------------------------------------------------------------------
// <copyright file="BestScoreExtensions.cs" company="Gabriel Castillo">
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
    /// Best Score Extensions
    /// </summary>
    public static class BestScoreExtensions
    {
        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>the model</returns>
        public static BestScoreModel ToModel(this BestScore entity)
        {
            return new BestScoreModel
            {
                GameCreationDate = entity.GameCreationDate,
                GroupType = entity.GroupType,
                Points = entity.Points,
                Time = entity.Time,
                User = entity.User.ToModel()
            };
        }

        /// <summary>
        /// To the models.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>the models</returns>
        public static IList<BestScoreModel> ToModels(this ICollection<BestScore> entities)
        {
            return entities.Select(ToModel).ToList();
        }
    }
}