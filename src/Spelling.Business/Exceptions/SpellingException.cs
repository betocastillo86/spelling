//-----------------------------------------------------------------------
// <copyright file="SpellingException.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Business.Exceptions
{
    using Beto.Core.Exceptions;

    /// <summary>
    /// Spelling Exception
    /// </summary>
    /// <seealso cref="Beto.Core.Exceptions.CoreException{Spelling.Business.Exceptions.SpellingExceptionCode}" />
    public class SpellingException : CoreException<SpellingExceptionCode>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpellingException"/> class.
        /// </summary>
        /// <param name="error">The error.</param>
        public SpellingException(string error) : base(error)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpellingException"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        public SpellingException(SpellingExceptionCode code) : base(MessageExceptionFinder.GetErrorMessage(code))
        {
            this.Code = code;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpellingException"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="error">The error.</param>
        public SpellingException(SpellingExceptionCode code, string error) : base(error)
        {
            this.Code = code;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpellingException"/> class.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="code">The code.</param>
        public SpellingException(string target, SpellingExceptionCode code) : base(MessageExceptionFinder.GetErrorMessage(code))
        {
            this.Target = target;
            this.Code = code;
        }
    }
}