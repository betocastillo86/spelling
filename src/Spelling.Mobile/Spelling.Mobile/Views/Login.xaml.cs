﻿//-----------------------------------------------------------------------
// <copyright file="Login.xaml.cs" company="Gabriel Castillo">
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
    /// Login View
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Login"/> class.
        /// </summary>
        public Login()
        {
            this.ViewModel = ServiceRegister.Instance.Resolve<LoginViewModel>();

            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        /// <value>
        /// The view model.
        /// </value>
        public LoginViewModel ViewModel
        {
            get => this.BindingContext as LoginViewModel;
            set => this.BindingContext = value;
        }
    }
}