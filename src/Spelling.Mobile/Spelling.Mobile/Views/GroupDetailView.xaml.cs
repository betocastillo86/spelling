//-----------------------------------------------------------------------
// <copyright file="GroupDetailView.xaml.cs" company="Gabriel Castillo">
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
    /// Group Detail View
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GroupDetailView : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupDetailView"/> class.
        /// </summary>
        /// <param name="groupType">Type of the group.</param>
        public GroupDetailView(GroupType groupType)
        {
            this.ViewModel = ServiceRegister.Instance.Resolve<GroupDetailViewModel>();
            this.ViewModel.SetGroupType(groupType);

            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        /// <value>
        /// The view model.
        /// </value>
        public GroupDetailViewModel ViewModel
        {
            get => this.BindingContext as GroupDetailViewModel;
            set => this.BindingContext = value;
        }
    }
}