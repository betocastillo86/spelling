//-----------------------------------------------------------------------
// <copyright file="Game.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Beto.Core.Data;

    /// <summary>
    /// The game class
    /// </summary>
    public class Game : IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        /// <value>
        /// The group identifier.
        /// </value>
        public short GroupId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

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

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public virtual User User { get; set; }

        /// <summary>
        /// Gets or sets the type of the group.
        /// </summary>
        /// <value>
        /// The type of the group.
        /// </value>
        [NotMapped]
        public virtual GroupType GroupType
        {
            get
            {
                return (GroupType)this.GroupId;
            }

            set
            {
                this.GroupId = Convert.ToInt16(value);
            }
        }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        [NotMapped]
        public virtual Language Language
        {
            get
            {
                return Enum.Parse<Language>(this.OriginLanguage);
            }

            set
            {
                this.OriginLanguage = value.ToString();
            }
        }
    }
}