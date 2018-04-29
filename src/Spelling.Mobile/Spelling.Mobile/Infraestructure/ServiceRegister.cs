//-----------------------------------------------------------------------
// <copyright file="ServiceRegister.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.Infraestructure
{
    using Autofac;
    using Spelling.Mobile.Sevices;
    using Spelling.Mobile.ViewModels;

    /// <summary>
    /// Service Register
    /// </summary>
    public class ServiceRegister
    {
        /// <summary>
        /// The instance
        /// </summary>
        private static readonly ServiceRegister TheInstance = new ServiceRegister();

        /// <summary>
        /// The container
        /// </summary>
        private IContainer container;

        /// <summary>
        /// The container builder
        /// </summary>
        private ContainerBuilder containerBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRegister"/> class.
        /// </summary>
        protected ServiceRegister()
        {
            this.containerBuilder = new ContainerBuilder();

            this.RegisterDependencies();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static ServiceRegister Instance
        {
            get
            {
                return TheInstance;
            }
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        public void Build()
        {
            this.container = this.containerBuilder.Build();
        }

        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="T">the service type</typeparam>
        /// <returns>the instace of the service</returns>
        public T Resolve<T>()
        {
            return this.container.Resolve<T>();
        }

        /// <summary>
        /// Registers the dependencies.
        /// </summary>
        private void RegisterDependencies()
        {
            //// Services

            this.containerBuilder
                .RegisterType<RestService>()
                .As<IRestService>();

            this.containerBuilder
                .RegisterType<WorkContext>()
                .As<IWorkContext>()
                .SingleInstance();

            //// View Models

            this.containerBuilder
                .RegisterType<LoginViewModel>();

            this.containerBuilder
                .RegisterType<MenuViewModel>();

            this.containerBuilder
                .RegisterType<GroupDetailViewModel>();

            this.containerBuilder
                .RegisterType<NewGameViewModel>();

            this.containerBuilder
                .RegisterType<SummaryGameViewModel>();
        }
    }
}