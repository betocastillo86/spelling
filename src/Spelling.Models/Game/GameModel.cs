//-----------------------------------------------------------------------
// <copyright file="GameModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Models
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Spelling.Domain;

    /// <summary>
    /// Game Model
    /// </summary>
    /// <seealso cref="Spelling.Models.BaseModel" />
    public class GameModel : BaseModel
    {
        /// <summary>
        /// Gets or sets the type of the group.
        /// </summary>
        /// <value>
        /// The type of the group.
        /// </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public GroupType? GroupType { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public int Time { get; set; }

        /// <summary>
        /// Gets or sets the positives.
        /// </summary>
        /// <value>
        /// The positives.
        /// </value>
        public int Positives { get; set; }

        /// <summary>
        /// Gets or sets the negatives.
        /// </summary>
        /// <value>
        /// The negatives.
        /// </value>
        public int Negatives { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the origin language.
        /// </summary>
        /// <value>
        /// The origin language.
        /// </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public Language? OriginLanguage { get; set; }
    }
}