//-----------------------------------------------------------------------
// <copyright file="BestScoreModel.cs" company="Gabriel Castillo">
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
    /// Base Score Model
    /// </summary>
    public class BestScoreModel
    {
        /// <summary>
        /// Gets or sets the type of the group.
        /// </summary>
        /// <value>
        /// The type of the group.
        /// </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public GroupType GroupType { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public UserModel User { get; set; }

        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        /// <value>
        /// The points.
        /// </value>
        public int Points { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public int Time { get; set; }

        /// <summary>
        /// Gets or sets the game creation date.
        /// </summary>
        /// <value>
        /// The game creation date.
        /// </value>
        public DateTime GameCreationDate { get; set; }
    }
}