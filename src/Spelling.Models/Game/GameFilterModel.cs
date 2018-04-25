//-----------------------------------------------------------------------
// <copyright file="GameFilterModel.cs" company="Gabriel Castillo">
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
    /// Game Filter Model
    /// </summary>
    /// <seealso cref="Beto.Core.Web.Api.BaseFilterModel" />
    public class GameFilterModel : BaseFilterModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameFilterModel"/> class.
        /// </summary>
        public GameFilterModel()
        {
            this.MaxPageSize = 50;
        }

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

        /// <summary>
        /// Gets the order by enum.
        /// </summary>
        /// <value>
        /// The order by enum.
        /// </value>
        public OrderByGame OrderByEnum
        {
            get
            {
                return string.IsNullOrEmpty(this.OrderBy) ? OrderByGame.Newest : Enum.Parse<OrderByGame>(this.OrderBy);
            }
        }
    }
}