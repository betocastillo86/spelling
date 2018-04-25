//-----------------------------------------------------------------------
// <copyright file="GroupExtensions.cs" company="Gabriel Castillo">
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
    /// Group Extensions
    /// </summary>
    public static class GroupExtensions
    {
        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>the model</returns>
        public static GameModel ToModel(this Game entity)
        {
            return new GameModel
            {
                CreationDate = entity.CreationDate,
                GroupType = entity.GroupType,
                Id = entity.Id,
                Negatives = entity.Negatives,
                OriginLanguage = entity.Language,
                Positives = entity.Positives,
                Time = entity.Time,
                Total = entity.Total
            };
        }

        /// <summary>
        /// To the models.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>the models</returns>
        public static IList<GameModel> ToModels(this ICollection<Game> entities)
        {
            return entities.Select(ToModel).ToList();
        }
    }
}