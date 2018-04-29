//-----------------------------------------------------------------------
// <copyright file="SummaryGameModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.Domain
{
    using System.Collections.Generic;

    /// <summary>
    /// Summary Model
    /// </summary>
    /// <seealso cref="Spelling.Mobile.Domain.BaseViewModel" />
    public class SummaryGameModel : BaseViewModel
    {
        /// <summary>
        /// The correct answers
        /// </summary>
        private int correctAnswers = 0;

        /// <summary>
        /// The incorrect answers
        /// </summary>
        private int incorrectAnswers = 0;

        /// <summary>
        /// The left words
        /// </summary>
        private int leftWords = 0;

        /// <summary>
        /// The time
        /// </summary>
        private int time = 0;

        /// <summary>
        /// The total words
        /// </summary>
        private int totalWords = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryGameModel"/> class.
        /// </summary>
        public SummaryGameModel()
        {
            this.Answers = new List<AnswerModel>();
        }

        /// <summary>
        /// Gets or sets the answers.
        /// </summary>
        /// <value>
        /// The answers.
        /// </value>
        public IList<AnswerModel> Answers { get; set; }

        /// <summary>
        /// Gets or sets the correct answers.
        /// </summary>
        /// <value>
        /// The correct answers.
        /// </value>
        public int CorrectAnswers
        {
            get => this.correctAnswers;
            set => this.SetValue(ref this.correctAnswers, value);
        }

        /// <summary>
        /// Gets or sets the incorrect answers.
        /// </summary>
        /// <value>
        /// The incorrect answers.
        /// </value>
        public int IncorrectAnswers
        {
            get => this.incorrectAnswers;
            set => this.SetValue(ref this.incorrectAnswers, value);
        }

        /// <summary>
        /// Gets or sets the left words.
        /// </summary>
        /// <value>
        /// The left words.
        /// </value>
        public int LeftWords
        {
            get => this.leftWords;
            set => this.SetValue(ref this.leftWords, value);
        }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public int Time
        {
            get => this.time;
            set => this.SetValue(ref this.time, value);
        }

        /// <summary>
        /// Gets or sets the total words.
        /// </summary>
        /// <value>
        /// The total words.
        /// </value>
        public int TotalWords
        {
            get => this.totalWords;
            set => this.SetValue(ref this.totalWords, value);
        }
    }
}