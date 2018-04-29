//-----------------------------------------------------------------------
// <copyright file="GroupDetailViewModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.ViewModels
{
    using System.Windows.Input;
    using Spelling.Mobile.Domain.Enums;
    using Spelling.Mobile.Views;
    using Xamarin.Forms;

    /// <summary>
    /// Group Detail View Model
    /// </summary>
    public class GroupDetailViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupDetailViewModel"/> class.
        /// </summary>
        public GroupDetailViewModel()
        {
            this.BeginGame = new Command(this.BeginGameCommand);
        }

        /// <summary>
        /// Gets the begin game.
        /// </summary>
        /// <value>
        /// The begin game.
        /// </value>
        public ICommand BeginGame { get; private set; }

        /// <summary>
        /// Gets the type of the group.
        /// </summary>
        /// <value>
        /// The type of the group.
        /// </value>
        public GroupType GroupType { get; private set; }

        /// <summary>
        /// Sets the type of the group.
        /// </summary>
        /// <param name="groupType">Type of the group.</param>
        public void SetGroupType(GroupType groupType)
        {
            this.GroupType = groupType;
        }

        /// <summary>
        /// Begins the game command.
        /// </summary>
        private async void BeginGameCommand()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new NewGameView(this.GroupType));
        }
    }
}