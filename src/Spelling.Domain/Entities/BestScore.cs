//-----------------------------------------------------------------------
// <copyright file="BestScore.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Beto.Core.Data;

    /// <summary>
    /// Best score
    /// </summary>
    public class BestScore : IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        /// <value>
        /// The group identifier.
        /// </value>
        public short GroupId { get; set; }

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
    }
}