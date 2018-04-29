//-----------------------------------------------------------------------
// <copyright file="TokenModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.Models
{
    /// <summary>
    /// Token Model
    /// </summary>
    public class TokenModel
    {
        /// <summary>
        /// Gets or sets the resource.
        /// </summary>
        /// <value>
        /// The resource.
        /// </value>
        public string Resource { get; set; }

        /// <summary>
        /// Gets or sets the scope.
        /// </summary>
        /// <value>
        /// The scope.
        /// </value>
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the type of the token.
        /// </summary>
        /// <value>
        /// The type of the token.
        /// </value>
        public string Token_Type { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>
        /// The access token.
        /// </value>
        public string Access_Token { get; set; }

        /// <summary>
        /// Gets or sets the expires in.
        /// </summary>
        /// <value>
        /// The expires in.
        /// </value>
        public long Expires_In { get; set; }

        /// <summary>
        /// Gets or sets the identifier token.
        /// </summary>
        /// <value>
        /// The identifier token.
        /// </value>
        public string Id_Token { get; set; }
    }
}