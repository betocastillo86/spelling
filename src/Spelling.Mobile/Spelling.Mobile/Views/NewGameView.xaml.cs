//-----------------------------------------------------------------------
// <copyright file="NewGameView.xaml.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.Views
{
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
    }
}