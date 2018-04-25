//-----------------------------------------------------------------------
// <copyright file="WordModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Spelling.Domain;

    /// <summary>
    /// Word Model
    /// </summary>
    /// <seealso cref="Spelling.Models.Common.BaseModel" />
    public class WordModel : BaseModel
    {
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
        [JsonConverter(typeof(StringEnumConverter))]
        public GroupType GroupType { get; set; }
    }
}