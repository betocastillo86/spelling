//-----------------------------------------------------------------------
// <copyright file="XamarinSpellingException.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.Exceptions
{
    using System;

    /// <summary>
    /// Xamarin Spelling Exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class XamarinSpellingException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XamarinSpellingException"/> class.
        /// </summary>
        public XamarinSpellingException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XamarinSpellingException"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        public XamarinSpellingException(XamarinSpellingExceptionCode code) : base(code.ToString())
        {
            this.Code = code;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XamarinSpellingException"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="apiErrorModel">The API error model.</param>
        public XamarinSpellingException(XamarinSpellingExceptionCode code, ApiErrorModel apiErrorModel) : base(code.ToString())
        {
            this.Code = code;
            this.ApiError = apiErrorModel;
        }

        /// <summary>
        /// Gets or sets the API error.
        /// </summary>
        /// <value>
        /// The API error.
        /// </value>
        public ApiErrorModel ApiError { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public XamarinSpellingExceptionCode Code { get; set; }
    }
}