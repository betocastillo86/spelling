//-----------------------------------------------------------------------
// <copyright file="NewGameViewModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Windows.Input;
    using Spelling.Mobile.Domain;
    using Spelling.Mobile.Domain.Enums;
    using Spelling.Mobile.Exceptions;
    using Spelling.Mobile.Infraestructure;
    using Spelling.Mobile.Sevices;
    using Spelling.Mobile.Views;
    using Xamarin.Forms;

    /// <summary>
    /// New Game View Model
    /// </summary>
    /// <seealso cref="Spelling.Mobile.Domain.BaseViewModel" />
    public class NewGameViewModel : BaseViewModel
    {
        /// <summary>
        /// The rest service
        /// </summary>
        private readonly IRestService restService;

        /// <summary>
        /// The work context
        /// </summary>
        private readonly IWorkContext workContext;

        /// <summary>
        /// The count seconds timer
        /// </summary>
        private int countSecondsTimer = 0;

        /// <summary>
        /// The current word
        /// </summary>
        private WordModel currentWord = null;

        /// <summary>
        /// The current word index
        /// </summary>
        private int currentWordIndex = 0;

        /// <summary>
        /// The left words text
        /// </summary>
        private string leftWordsText = null;

        /// <summary>
        /// The timer
        /// </summary>
        private Timer timer;

        /// <summary>
        /// The timer text
        /// </summary>
        private string timerText = null;

        /// <summary>
        /// The user answer
        /// </summary>
        private string userAnswer = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewGameViewModel"/> class.
        /// </summary>
        /// <param name="restService">The rest service.</param>
        /// <param name="workContext">The work context.</param>
        public NewGameViewModel(
            IRestService restService,
            IWorkContext workContext)
        {
            this.restService = restService;
            this.workContext = workContext;

            this.SaveWord = new Command(this.SaveWordCommand);
            this.SkipWord = new Command(this.SkipWordCommand);
            this.Exit = new Command(this.ExitCommand);
        }

        /// <summary>
        /// Gets or sets the current word.
        /// </summary>
        /// <value>
        /// The current word.
        /// </value>
        public WordModel CurrentWord
        {
            get => this.currentWord;
            set => this.SetValue(ref this.currentWord, value);
        }

        /// <summary>
        /// Gets the exit.
        /// </summary>
        /// <value>
        /// The exit.
        /// </value>
        public ICommand Exit { get; private set; }

        /// <summary>
        /// Gets the type of the group.
        /// </summary>
        /// <value>
        /// The type of the group.
        /// </value>
        public GroupType GroupType { get; private set; }

        /// <summary>
        /// Gets or sets the left words text.
        /// </summary>
        /// <value>
        /// The left words text.
        /// </value>
        public string LeftWordsText
        {
            get => this.leftWordsText;
            set => this.SetValue(ref this.leftWordsText, value);
        }

        /// <summary>
        /// Gets the save word.
        /// </summary>
        /// <value>
        /// The save word.
        /// </value>
        public ICommand SaveWord { get; private set; }

        /// <summary>
        /// Gets the skip word.
        /// </summary>
        /// <value>
        /// The skip word.
        /// </value>
        public ICommand SkipWord { get; private set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>
        /// The summary.
        /// </value>
        public SummaryGameModel Summary { get; set; }

        /// <summary>
        /// Gets or sets the timer text.
        /// </summary>
        /// <value>
        /// The timer text.
        /// </value>
        public string TimerText
        {
            get => this.timerText;
            set => this.SetValue(ref this.timerText, value);
        }

        /// <summary>
        /// Gets or sets the user answer.
        /// </summary>
        /// <value>
        /// The user answer.
        /// </value>
        public string UserAnswer
        {
            get => this.userAnswer;
            set => this.SetValue(ref this.userAnswer, value);
        }

        /// <summary>
        /// Gets or sets the words.
        /// </summary>
        /// <value>
        /// The words.
        /// </value>
        public IList<WordModel> Words { get; set; }

        /// <summary>
        /// Exits the command.
        /// </summary>
        public async void ExitCommand()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        /// <summary>
        /// Saves the game.
        /// </summary>
        public async void SaveGame()
        {
            var gameModel = new GameModel
            {
                GroupType = this.GroupType,
                Negatives = this.Summary.IncorrectAnswers,
                Positives = this.Summary.CorrectAnswers,
                OriginLanguage = "Spanish",
                Time = this.countSecondsTimer,
                Total = this.Words.Count
            };

            try
            {
                this.Summary.Time = this.countSecondsTimer;

                await this.restService.Post<GameModel>("http://10.0.2.2:52017/api/v1/games", gameModel, this.workContext.CurrentToken?.Access_Token);

                await Application.Current.MainPage.Navigation.PushAsync(new SummaryGame(this.Summary));
            }
            catch (XamarinSpellingException)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo guardar el mensaje", "Cerrar");
            }
        }

        /// <summary>
        /// Saves the word command.
        /// </summary>
        public void SaveWordCommand()
        {
            if (string.IsNullOrEmpty(this.UserAnswer))
            {
                return;
            }

            this.AddAnswer();
            this.NextWord();
        }

        /// <summary>
        /// Sets the type of the group.
        /// </summary>
        /// <param name="groupType">Type of the group.</param>
        public void SetGroupType(GroupType groupType)
        {
            this.GroupType = groupType;
            this.Summary = new SummaryGameModel();

            this.LoadWords();
        }

        /// <summary>
        /// Adds the answer.
        /// </summary>
        private void AddAnswer()
        {
            var answer = new AnswerModel
            {
                Answer = this.UserAnswer,
                IsCorrectAnswer = !string.IsNullOrEmpty(this.UserAnswer) ? this.UserAnswer.ToLowerInvariant().Equals(this.CurrentWord.English.ToLowerInvariant()) : false,
                Word = this.CurrentWord
            };

            this.Summary.Answers.Add(answer);

            if (answer.IsCorrectAnswer)
            {
                this.Summary.CorrectAnswers++;
            }
            else
            {
                this.Summary.IncorrectAnswers++;
            }
        }

        /// <summary>
        /// Initializes the game.
        /// </summary>
        private void InitGame()
        {
            this.NextWord();
            this.timer = new Timer(
                (del) =>
                {
                    this.countSecondsTimer++;
                    this.TimerText = TimeSpan.FromSeconds(countSecondsTimer).ToString(@"hh\:mm\:ss");
                },
                null,
                0,
                1000);
        }

        /// <summary>
        /// Loads the words.
        /// </summary>
        private async void LoadWords()
        {
            var filter = new WordFilterModel();
            filter.GroupType = this.GroupType;
            filter.PageSize = 500;
            filter.OrderBy = "Random";

            try
            {
                this.Words = (await this.restService.Get<WordFilterModel, PaginationResponseModel<WordModel>>("http://10.0.2.2:52017/api/v1/words", filter, this.workContext?.CurrentToken.Access_Token))
                               .Results;

                this.InitGame();
            }
            catch (XamarinSpellingException)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ocurrió un error al obtener los datos", "Cerrar");
            }
        }

        /// <summary>
        /// Nexts the word.
        /// </summary>
        private void NextWord()
        {
            if (this.currentWordIndex != this.Words.Count)
            {
                this.CurrentWord = this.Words[this.currentWordIndex];
                this.currentWordIndex++;

                this.Summary.LeftWords = this.currentWordIndex;
                this.Summary.TotalWords = this.Words.Count;
                this.LeftWordsText = $"{this.Summary.LeftWords}/{this.Summary.TotalWords}";
                this.UserAnswer = string.Empty;
            }
            else
            {
                this.timer.Dispose();
                this.SaveGame();
            }
        }

        /// <summary>
        /// Skips the word command.
        /// </summary>
        private void SkipWordCommand()
        {
            this.AddAnswer();
            this.NextWord();
        }
    }
}