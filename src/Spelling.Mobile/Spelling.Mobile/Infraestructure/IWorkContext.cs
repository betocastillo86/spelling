//-----------------------------------------------------------------------
// <copyright file="IWorkContext.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.Infraestructure
{
    using Spelling.Mobile.Models;

    /// <summary>
    /// Interface work context
    /// </summary>
    public interface IWorkContext
    {
        /// <summary>
        /// Gets the current token.
        /// </summary>
        /// <value>
        /// The current token.
        /// </value>
        TokenModel CurrentToken { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is authenticated.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is authenticated; otherwise, <c>false</c>.
        /// </value>
        bool IsAuthenticated { get; }

        /// <summary>
        /// Sets the new token.
        /// </summary>
        /// <param name="tokenModel">The token model.</param>
        void SetNewToken(TokenModel tokenModel);
    }
}