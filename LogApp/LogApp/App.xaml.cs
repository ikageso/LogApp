using Prism;
using Prism.Ioc;
using LogApp.ViewModels;
using LogApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Logging;
using LogApp.DependencyServices;
using LogApp.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LogApp
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<PrismContentPage1, PrismContentPage1ViewModel>();

            containerRegistry.RegisterSingleton<ILoggerService, LoggerService>();

            containerRegistry.RegisterInstance<ILoggerFacade>(DependencyService.Get<ILoggerFacade>());
            containerRegistry.RegisterInstance<IStorageService>(DependencyService.Get<IStorageService>());
        }
    }
}
