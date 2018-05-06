//-----------------------------------------------------------------------
// <copyright file="NewGameView.xaml.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.Views
{
    using System.Threading.Tasks;
    using Spelling.Mobile.Domain.Enums;
    using Spelling.Mobile.Infraestructure;
    using Spelling.Mobile.ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// The new game
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewGameView : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewGameView"/> class.
        /// </summary>
        /// <param name="groupType">Type of the group.</param>
        public NewGameView(GroupType groupType)
        {
            this.ViewModel = ServiceRegister.Instance.Resolve<NewGameViewModel>();
            this.ViewModel.SetGroupType(groupType);

            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        /// <value>
        /// The view model.
        /// </value>
        public NewGameViewModel ViewModel
        {
            get => this.BindingContext as NewGameViewModel;
            set => this.BindingContext = value;
        }

        /// <summary>
        /// Application developers can override this method to provide behavior when the back button is pressed.
        /// </summary>
        /// <returns>
        /// To be added.
        /// </returns>
        protected override bool OnBackButtonPressed()
        {
            ////if (Application.Current.MainPage.DisplayAlert("No ha terminado la partida", "¿Estas seguro que deseas salir?", "Quedarse en la página", "Salir").Result)
            ////{
            ////    return true;
            ////}

            return base.OnBackButtonPressed();
        }
    }
}