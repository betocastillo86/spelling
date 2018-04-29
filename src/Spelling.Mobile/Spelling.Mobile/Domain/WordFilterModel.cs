//-----------------------------------------------------------------------
// <copyright file="WordFilterModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.Domain
{
    using Spelling.Mobile.Domain.Enums;

    /// <summary>
    /// Word filter model
    /// </summary>
    /// <seealso cref="Spelling.Mobile.Domain.BaseXamarinFilterModel" />
    public class WordFilterModel : BaseXamarinFilterModel
    {
        /// <summary>
        /// Gets or sets the type of the group.
        /// </summary>
        /// <value>
        /// The type of the group.
        /// </value>
        public GroupType? GroupType { get; set; }
    }
}