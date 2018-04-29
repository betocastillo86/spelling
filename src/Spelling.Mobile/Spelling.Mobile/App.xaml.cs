//-----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile
{
    using Spelling.Mobile.Infraestructure;
    using Spelling.Mobile.Views;
    using Xamarin.Forms;

    /// <summary>
    /// The application start
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Application" />
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            ServiceRegister.Instance.Build();

            this.MainPage = new Login();
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
        /// Application developers override this method to perform actions when the application resumes from a sleeping state.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}