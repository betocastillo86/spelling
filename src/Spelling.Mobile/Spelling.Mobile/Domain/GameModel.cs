//-----------------------------------------------------------------------
// <copyright file="GameModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.Domain
{
    using System;
    using Spelling.Mobile.Domain.Enums;

    /// <summary>
    /// Game Model
    /// </summary>
    public class GameModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the type of the group.
        /// </summary>
        /// <value>
        /// The type of the group.
        /// </value>
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
        public string OriginLanguage { get; set; }
    }
}