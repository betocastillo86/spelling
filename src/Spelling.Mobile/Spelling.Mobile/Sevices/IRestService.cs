//-----------------------------------------------------------------------
// <copyright file="IRestService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.Sevices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface of rest service
    /// </summary>
    public interface IRestService
    {
        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="authToken">The authentication token.</param>
        /// <returns>the response</returns>
        Task<TResponse> Get<TResponse>(string url, string authToken = null) where TResponse : class;

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request.</typeparam>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="authToken">The authentication token.</param>
        /// <returns>the response</returns>
        Task<TResponse> Get<TRequest, TResponse>(string url, TRequest parameters = null, string authToken = null) where TRequest : class where TResponse : class;

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="content">The content.</param>
        /// <param name="authToken">The authentication token.</param>
        /// <returns>the task</returns>
        Task Post<TRequest>(string url, TRequest content, string authToken = null);

        /// <summary>
        /// Posts the URL encoded.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="content">The content.</param>
        /// <param name="authToken">The authentication token.</param>
        /// <returns>the response</returns>
        Task<TResponse> PostUrlEncoded<TResponse>(string url, IEnumerable<KeyValuePair<string, string>> content, string authToken = null);
    }
}