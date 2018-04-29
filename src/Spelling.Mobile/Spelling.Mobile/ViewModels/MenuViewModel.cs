//-----------------------------------------------------------------------
// <copyright file="MenuViewModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.ViewModels
{
    using System;
    using System.Windows.Input;
    using Spelling.Mobile.Domain.Enums;
    using Spelling.Mobile.Views;
    using Xamarin.Forms;

    /// <summary>
    /// Menu View Model
    /// </summary>
    public class MenuViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuViewModel"/> class.
        /// </summary>
        public MenuViewModel()
        {
            this.ChooseMenu = new Command<string>(this.ChooseMenuCommand);
        }

        /// <summary>
        /// Gets the choose menu.
        /// </summary>
        /// <value>
        /// The choose menu.
        /// </value>
        public ICommand ChooseMenu { get; private set; }

        /// <summary>
        /// Chooses the menu command.
        /// </summary>
        /// <param name="option">The option.</param>
        private async void ChooseMenuCommand(string option)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new GroupDetailView((GroupType)Enum.Parse(typeof(GroupType), option)));
        }
    }
}