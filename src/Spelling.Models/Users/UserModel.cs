//-----------------------------------------------------------------------
// <copyright file="UserModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Models
{
    /// <summary>
    /// User Model
    /// </summary>
    /// <seealso cref="Spelling.Models.BaseModel" />
    public class UserModel : BaseModel
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }
    }
}