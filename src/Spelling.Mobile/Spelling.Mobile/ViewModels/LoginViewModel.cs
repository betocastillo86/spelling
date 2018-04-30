//-----------------------------------------------------------------------
// <copyright file="LoginViewModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.ViewModels
{
    using System.Collections.Generic;
    using System.Windows.Input;
    using Spelling.Mobile.Domain;
    using Spelling.Mobile.Exceptions;
    using Spelling.Mobile.Infraestructure;
    using Spelling.Mobile.Models;
    using Spelling.Mobile.Sevices;
    using Xamarin.Forms;

    /// <summary>
    /// Login View Model
    /// </summary>
    public class LoginViewModel
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
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        /// <param name="restService">The rest service.</param>
        /// <param name="workContext">The work context.</param>
        public LoginViewModel(
            IRestService restService,
            IWorkContext workContext)
        {
            this.restService = restService;
            this.workContext = workContext;

            this.Model = new LoginModel() { Email = "admin@admin.com", Password = "123456" };
            this.TryAuthenticate = new Command(this.Authenticate);
        }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public LoginModel Model { get; set; }

        /// <summary>
        /// Gets the try authenticate.
        /// </summary>
        /// <value>
        /// The try authenticate.
        /// </value>
        public ICommand TryAuthenticate { get; private set; }

        /// <summary>
        /// Authenticates this instance.
        /// </summary>
        private async void Authenticate()
        {
            try
            {
                var parameters = new Dictionary<string, string>();
                parameters.Add("username", this.Model.Email);
                parameters.Add("password", this.Model.Password);
                parameters.Add("grant_type", "password");

                var token = await this.restService.PostUrlEncoded<TokenModel>("http://10.0.2.2:52017/api/v1/auth", parameters);

                this.GetCurretUser(token);
            }
            catch (XamarinSpellingException)
            {
                await Application.Current.MainPage.DisplayAlert("Entrar", "Los datos de autenticación son incorrectos", "Cerrar");
            }
        }

        /// <summary>
        /// Gets the curret user.
        /// </summary>
        /// <param name="token">The token.</param>
        private async void GetCurretUser(TokenModel token)
        {
            try
            {
                var user = await this.restService.Get<UserModel>("http://10.0.2.2:52017/api/v1/auth/current", authToken: token.Access_Token);

                this.workContext.SetNewToken(token, user);

                Application.Current.MainPage = new NavigationPage(new Spelling.Mobile.Views.MenuView());
            }
            catch (XamarinSpellingException)
            {
                await Application.Current.MainPage.DisplayAlert("Entrar", "Los datos de autenticación son incorrectos", "Cerrar");
            }
        }
    }
}