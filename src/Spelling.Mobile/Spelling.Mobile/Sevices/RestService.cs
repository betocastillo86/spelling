//-----------------------------------------------------------------------
// <copyright file="RestService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.Sevices
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Spelling.Mobile.Exceptions;

    /// <summary>
    /// The rest service
    /// </summary>
    /// <seealso cref="Spelling.Mobile.Sevices.IRestService" />
    public class RestService : IRestService
    {
        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request.</typeparam>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="authToken">The authentication token.</param>
        /// <returns>
        /// the response
        /// </returns>
        public async Task<TResponse> Get<TRequest, TResponse>(string url, TRequest parameters = null, string authToken = null)
            where TRequest : class
            where TResponse : class
        {
            using (var client = new HttpClient())
            {
                if (authToken != null)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);
                }

                var queryString = string.Empty;

                if (parameters != null)
                {
                    queryString = string.Join(
                        "&",
                        parameters
                       .GetType()
                       .GetProperties()
                       .Where(c =>
                       {
                           return c.GetValue(parameters) != null /*&& (c.PropertyType == typeof(int) || c.PropertyType == typeof(string) || c.PropertyType.IsEnum)*/;
                       })
                       .Select(c => $"{c.Name}={c.GetValue(parameters)}"));

                    url += !string.IsNullOrEmpty(queryString) ? string.Concat("?", queryString) : string.Empty;
                }

                var response = await client.GetAsync(url);
                return await this.HandleResponse<TResponse>(response);
            }
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="content">The content.</param>
        /// <param name="authToken">The authentication token.</param>
        /// <returns>
        /// the task
        /// </returns>
        public async Task Post<TRequest>(string url, TRequest content, string authToken = null)
        {
            using (var client = new HttpClient())
            {
                if (authToken != null)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);
                }

                var jsonContent = JsonConvert.SerializeObject(content);
                var response = await client.PostAsync(url, new StringContent(jsonContent, null, "application/json"));
                await this.HandleVoidResponse(response);
            }
        }

        /// <summary>
        /// Posts the URL encoded.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="content">The content.</param>
        /// <param name="authToken">The authentication token.</param>
        /// <returns>
        /// the response
        /// </returns>
        public async Task<TResponse> PostUrlEncoded<TResponse>(string url, IEnumerable<KeyValuePair<string, string>> content, string authToken = null)
        {
            using (var client = new HttpClient())
            {
                if (authToken != null)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);
                }

                var jsonContent = JsonConvert.SerializeObject(content);

                var response = await client.PostAsync(url, new FormUrlEncodedContent(content));
                return await this.HandleResponse<TResponse>(response);
            }
        }

        /// <summary>
        /// Gets the error code by status code.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <returns>the error depending the status code</returns>
        private XamarinSpellingExceptionCode GetErrorCodeByStatusCode(HttpStatusCode statusCode)
        {
            switch (statusCode)
            {
                case HttpStatusCode.BadRequest:
                    return XamarinSpellingExceptionCode.BadRequestException;

                case HttpStatusCode.Unauthorized:
                    return XamarinSpellingExceptionCode.UnauthorizedException;

                case HttpStatusCode.Forbidden:
                    return XamarinSpellingExceptionCode.ForbidenException;

                case HttpStatusCode.InternalServerError:
                    return XamarinSpellingExceptionCode.RequestException;

                default:
                    return XamarinSpellingExceptionCode.RequestException;
            }
        }

        /// <summary>
        /// Handles the response.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="response">The response.</param>
        /// <param name="exception">The exception.</param>
        /// <returns>the deserialized response</returns>
        private async Task<TResponse> HandleResponse<TResponse>(HttpResponseMessage response, HttpRequestException exception = null)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return JsonConvert.DeserializeObject<TResponse>(jsonResponse);
            }
            else
            {
                var error = this.GetErrorCodeByStatusCode(response.StatusCode);
                throw new XamarinSpellingException(error, JsonConvert.DeserializeObject<ApiErrorModel>(jsonResponse));
            }
        }

        /// <summary>
        /// Handles the void response.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="exception">The exception.</param>
        /// <returns>the task</returns>
        /// <exception cref="Spelling.Mobile.Exceptions.XamarinSpellingException">if the code throws and exception</exception>
        private async Task HandleVoidResponse(HttpResponseMessage response, HttpRequestException exception = null)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Created)
            {
                var error = this.GetErrorCodeByStatusCode(response.StatusCode);
                throw new XamarinSpellingException(error, JsonConvert.DeserializeObject<ApiErrorModel>(jsonResponse));
            }
        }
    }
}