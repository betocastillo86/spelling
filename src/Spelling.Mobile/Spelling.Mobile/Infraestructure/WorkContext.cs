//-----------------------------------------------------------------------
// <copyright file="WorkContext.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.Infraestructure
{
    using Spelling.Mobile.Models;

    /// <summary>
    /// Work Context
    /// </summary>
    /// <seealso cref="Spelling.Mobile.Infraestructure.IWorkContext" />
    public class WorkContext : IWorkContext
    {
        /// <summary>
        /// The current token
        /// </summary>
        private TokenModel currentToken = null;

        /// <summary>
        /// Gets the current token.
        /// </summary>
        /// <value>
        /// The current token.
        /// </value>
        public TokenModel CurrentToken => this.currentToken;

        /// <summary>
        /// Gets a value indicating whether this instance is authenticated.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is authenticated; otherwise, <c>false</c>.
        /// </value>
        public bool IsAuthenticated => this.currentToken != null;

        /// <summary>
        /// Sets the new token.
        /// </summary>
        /// <param name="tokenModel">The token model.</param>
        public void SetNewToken(TokenModel tokenModel)
        {
            this.currentToken = tokenModel;
        }
    }
}