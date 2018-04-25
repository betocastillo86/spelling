//-----------------------------------------------------------------------
// <copyright file="MessageExceptionFinder.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Business.Exceptions
{
    using System;
    using Beto.Core.Exceptions;

    /// <summary>
    /// Message Exception Finder
    /// </summary>
    /// <seealso cref="Beto.Core.Exceptions.IMessageExceptionFinder" />
    public class MessageExceptionFinder : IMessageExceptionFinder
    {
        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>the error message</returns>
        public static string GetErrorMessage(SpellingExceptionCode code)
        {
            switch (code)
            {
                case SpellingExceptionCode.BadArgument:
                    return "El dato enviado es invalido";

                case SpellingExceptionCode.InvalidForeignKey:
                    return "La llave relacionada es invalida";

                default:
                    return "Se ha encontrado un error";
            }
        }

        /// <summary>
        /// Gets the error message depending of the exception code
        /// </summary>
        /// <typeparam name="T">the type of errors</typeparam>
        /// <param name="exceptionCode">The exception code.</param>
        /// <returns>
        /// The text of exception
        /// </returns>
        public string GetErrorMessage<T>(T exceptionCode)
        {
            if (exceptionCode is SpellingExceptionCode)
            {
                return MessageExceptionFinder.GetErrorMessage((SpellingExceptionCode)Enum.Parse(typeof(SpellingExceptionCode), exceptionCode.ToString()));
            }
            else
            {
                return string.Empty;
            }
        }
    }
}