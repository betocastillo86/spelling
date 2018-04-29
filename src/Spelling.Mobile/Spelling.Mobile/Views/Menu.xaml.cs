//-----------------------------------------------------------------------
// <copyright file="Menu.xaml.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.Views
{
    using Spelling.Mobile.Infraestructure;
    using Spelling.Mobile.ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Menu View
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        public Menu()
        {
            this.ViewModel = ServiceRegister.Instance.Resolve<MenuViewModel>();

            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        /// <value>
        /// The view model.
        /// </value>
        public MenuViewModel ViewModel
        {
            get => this.BindingContext as MenuViewModel;
            set => this.BindingContext = value;
        }
    }
}