//-----------------------------------------------------------------------
// <copyright file="SummaryGameViewModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;
    using Spelling.Mobile.Domain;
    using Spelling.Mobile.Views;
    using Xamarin.Forms;

    /// <summary>
    /// Summary Game View Model
    /// </summary>
    /// <seealso cref="Spelling.Mobile.Domain.BaseViewModel" />
    public class SummaryGameViewModel : BaseViewModel
    {
        /// <summary>
        /// The model
        /// </summary>
        private SummaryGameModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryGameViewModel"/> class.
        /// </summary>
        public SummaryGameViewModel()
        {
            this.Finish = new Command(this.FinishCommand);
        }

        /// <summary>
        /// Gets the finish.
        /// </summary>
        /// <value>
        /// The finish.
        /// </value>
        public ICommand Finish { get; private set; }

        /// <summary>
        /// Gets the incorrect answers.
        /// </summary>
        /// <value>
        /// The incorrect answers.
        /// </value>
        public IList<AnswerModel> IncorrectAnswers { get; private set; }

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public SummaryGameModel Model { get => this.model; private set => this.SetValue(ref this.model, value); }

        /// <summary>
        /// Finishes the command.
        /// </summary>
        public async void FinishCommand()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new MenuView());
        }

        /// <summary>
        /// Sets the model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void SetModel(SummaryGameModel model)
        {
            this.Model = model;
            this.IncorrectAnswers = model.Answers.Where(c => !c.IsCorrectAnswer).ToList();
        }
    }
}