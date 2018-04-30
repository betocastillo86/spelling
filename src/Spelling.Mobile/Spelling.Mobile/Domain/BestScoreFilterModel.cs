//-----------------------------------------------------------------------
// <copyright file="BestScoreFilterModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.Domain
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Spelling.Mobile.Domain.Enums;

    /// <summary>
    /// Best Score Filter Model
    /// </summary>
    /// <seealso cref="Spelling.Mobile.Domain.BaseXamarinFilterModel" />
    public class BestScoreFilterModel : BaseXamarinFilterModel
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets the type of the group.
        /// </summary>
        /// <value>
        /// The type of the group.
        /// </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public GroupType? GroupType { get; set; }
    }
}