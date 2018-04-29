//-----------------------------------------------------------------------
// <copyright file="AnswerModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.Domain
{
    /// <summary>
    /// Answer Model
    /// </summary>
    public class AnswerModel
    {
        /// <summary>
        /// Gets or sets the word.
        /// </summary>
        /// <value>
        /// The word.
        /// </value>
        public WordModel Word { get; set; }

        /// <summary>
        /// Gets or sets the answer.
        /// </summary>
        /// <value>
        /// The answer.
        /// </value>
        public string Answer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is correct answer.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is correct answer; otherwise, <c>false</c>.
        /// </value>
        public bool IsCorrectAnswer { get; set; }
    }
}