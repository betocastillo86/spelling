//-----------------------------------------------------------------------
// <copyright file="WordFilterModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Models
{
    using System;
    using Beto.Core.Web.Api;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Spelling.Domain;

    /// <summary>
    /// Word Filter Model
    /// </summary>
    /// <seealso cref="Beto.Core.Web.Api.BaseFilterModel" />
    public class WordFilterModel : BaseFilterModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WordFilterModel"/> class.
        /// </summary>
        public WordFilterModel()
        {
            this.MaxPageSize = 500;
            this.ValidOrdersBy = Enum.GetNames(typeof(OrderByWord));
        }

        /// <summary>
        /// Gets or sets the type of the group.
        /// </summary>
        /// <value>
        /// The type of the group.
        /// </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public GroupType? GroupType { get; set; }

        /// <summary>
        /// Gets the order by enum.
        /// </summary>
        /// <value>
        /// The order by enum.
        /// </value>
        public OrderByWord OrderByEnum
        {
            get
            {
                return string.IsNullOrEmpty(this.OrderBy) ? OrderByWord.Spanish : Enum.Parse<OrderByWord>(this.OrderBy);
            }
        }
    }
}