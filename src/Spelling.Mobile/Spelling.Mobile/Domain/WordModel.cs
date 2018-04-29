//-----------------------------------------------------------------------
// <copyright file="WordModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.Domain
{
    using Spelling.Mobile.Domain.Enums;

    /// <summary>
    /// Word Model
    /// </summary>
    public class WordModel
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
        /// Gets or sets the type of the group.
        /// </summary>
        /// <value>
        /// The type of the group.
        /// </value>
        public GroupType GroupType { get; set; }
    }
}