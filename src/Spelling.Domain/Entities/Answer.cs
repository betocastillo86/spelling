//-----------------------------------------------------------------------
// <copyright file="Answer.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Domain
{
    using System;
    using Beto.Core.Data;

    /// <summary>
    /// Answer class
    /// </summary>
    public class Answer : IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the game identifier.
        /// </summary>
        /// <value>
        /// The game identifier.
        /// </value>
        public int GameId { get; set; }

        /// <summary>
        /// Gets or sets the word identifier.
        /// </summary>
        /// <value>
        /// The word identifier.
        /// </value>
        public int WordId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [correct answer].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [correct answer]; otherwise, <c>false</c>.
        /// </value>
        public bool CorrectAnswer { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the game.
        /// </summary>
        /// <value>
        /// The game.
        /// </value>
        public virtual Game Game { get; set; }

        /// <summary>
        /// Gets or sets the word.
        /// </summary>
        /// <value>
        /// The word.
        /// </value>
        public virtual Word Word { get; set; }
    }
}