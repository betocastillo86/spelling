//-----------------------------------------------------------------------
// <copyright file="SummaryGame.xaml.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.Views
{
    using Spelling.Mobile.Domain;
    using Spelling.Mobile.Infraestructure;
    using Spelling.Mobile.ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Summary Game
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SummaryGame : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryGame"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public SummaryGame(SummaryGameModel model)
        {
            this.ViewModel = ServiceRegister.Instance.Resolve<SummaryGameViewModel>();
            this.ViewModel.SetModel(model);

            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        /// <value>
        /// The view model.
        /// </value>
        public SummaryGameViewModel ViewModel
        {
            get => this.BindingContext as SummaryGameViewModel;
            set => this.BindingContext = value;
        }

        /// <summary>
        /// Child method. Application developers can override this method to provide behavior when the back button is pressed.
        /// </summary>
        /// <returns>
        /// To be added.
        /// </returns>
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}