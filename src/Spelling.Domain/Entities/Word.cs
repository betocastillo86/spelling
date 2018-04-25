//-----------------------------------------------------------------------
// <copyright file="Word.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Beto.Core.Data;

    /// <summary>
    /// The Word
    /// </summary>
    public class Word : IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the spanish.
        /// </summary>
        /// <value>
        /// The spanish.
        /// </value>
        public string Spanish { get; set; }

        /// <summary>
        /// Gets or sets the english.
        /// </summary>
        /// <value>
        /// The english.
        /// </value>
        public string English { get; set; }

        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        /// <value>
        /// The group identifier.
        /// </value>
        public short GroupId { get; set; }

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