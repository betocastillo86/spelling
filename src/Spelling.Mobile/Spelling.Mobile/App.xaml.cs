//-----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile
{
    using Newtonsoft.Json;
    using Plugin.Settings;
    using Plugin.Settings.Abstractions;
    using Spelling.Mobile.Infraestructure;
    using Spelling.Mobile.Models;
    using Spelling.Mobile.Views;
    using Xamarin.Forms;

    /// <summary>
    /// The application start
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Application" />
    public partial class App : Application
    {
        /// <summary>
        /// The API URL
        /// </summary>
        public static string ApiUrl = "http://betocastillo86-003-site6.htempurl.com/api/v1/";

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            ServiceRegister.Instance.Build();

            var workContext = ServiceRegister.Instance.Resolve<IWorkContext>();

            this.MainPage = !workContext.IsAuthenticated ? (Page)new LoginView() : (Page)new NavigationPage(new MenuView());
        }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public static TokenModel Token
        {
            get
            {
                var tokenSaved = Settings.GetValueOrDefault("AuthToken", null);
                return tokenSaved != null ? JsonConvert.DeserializeObject<TokenModel>(tokenSaved) : null;
            }

            set
            {
                Settings.AddOrUpdateValue("AuthToken", JsonConvert.SerializeObject(value));
            }
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        private static ISettings Settings => CrossSettings.Current;

        /// <summary>
        /// Application developers override this method to perform actions when the application resumes from a sleeping state.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        /// <summary>
        /// Application developers override this method to perform actions when the application enters the sleeping state.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        /// <summary>
        /// Application developers override this method to perform actions when the application starts.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnStart()
        {
            // Handle when your app starts
        }
    }
}