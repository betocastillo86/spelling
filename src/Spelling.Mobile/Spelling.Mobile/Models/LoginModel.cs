//-----------------------------------------------------------------------
// <copyright file="LoginModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.Models
{
    using Spelling.Mobile.Domain;

    /// <summary>
    /// Login Model
    /// </summary>
    public class LoginModel : BaseViewModel
    {
        /// <summary>
        /// The email
        /// </summary>
        private string email;

        /// <summary>
        /// The password
        /// </summary>
        private string password;

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email
        {
            get => this.email;
            set => this.SetValue(ref this.email, value);
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password
        {
            get => this.password;
            set => this.SetValue(ref this.password, value);
        }
    }
}