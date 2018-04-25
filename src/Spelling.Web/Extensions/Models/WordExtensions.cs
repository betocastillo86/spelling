//-----------------------------------------------------------------------
// <copyright file="WordExtensions.cs" company="Gabriel Castillo">
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
    /// Word Extensions
    /// </summary>
    public static class WordExtensions
    {
        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>the model</returns>
        public static WordModel ToModel(this Word entity)
        {
            return new WordModel
            {
                English = entity.English,
                GroupType = entity.GroupType,
                Id = entity.Id,
                Spanish = entity.Spanish
            };
        }

        /// <summary>
        /// To the models.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>the models</returns>
        public static IList<WordModel> ToModels(this ICollection<Word> entities)
        {
            return entities.Select(ToModel).ToList();
        }
    }
}