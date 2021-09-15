using Autofac;
using RemoteDesktop.Common;
using RemoteDesktop.Grpc.Client.Core;
using RemoteDesktop.Grpc.WpfClient.ViewModels;
using RemoteDesktop.Grpc.WpfClient.Views;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace RemoteDesktop.Grpc.WpfClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Fields

        private static IContainer _container;

        private StartupScreen _startupScreen;

        private MainScreen _mainScreen;

        #endregion

        public static IContainer Container => _container;


        #region Constructors

        public App()
        {
        }

        #endregion


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _container = Configure();

            if (_container.IsRegistered(typeof(StartupScreenViewModel)))
            {
                using (var scope = _container.BeginLifetimeScope())
                {
                    _startupScreen = new StartupScreen();
                    var startupScreenViewModel = scope.Resolve<StartupScreenViewModel>();
                    startupScreenViewModel.CloseRequest += OnStartupScreenCloseRequest;
                    _startupScreen.DataContext = startupScreenViewModel;
                    _startupScreen.ShowDialog();
                    startupScreenViewModel.CloseRequest -= OnStartupScreenCloseRequest;
                }
            }
        }

        private void OnStartupScreenCloseRequest(object sender, System.EventArgs e)
        {
            if (_container.IsRegistered(typeof(MainScreenViewModel)))
            {
                using (var scope = _container.BeginLifetimeScope())
                {
                    _mainScreen = new MainScreen();
                    var mainScreenViewModel = scope.Resolve<MainScreenViewModel>();
                    _mainScreen.DataContext = mainScreenViewModel;
                    _startupScreen.DialogResult = true;
                    App.Current.MainWindow = _mainScreen;
                    _mainScreen.ShowDialog();
                }
            }
        }

        private IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<GrpcClient>().As<IGrpcClient>();
            builder.RegisterInstance(new StartupScreenViewModel());
            builder.RegisterType<MainScreenViewModel>().AsSelf();
            builder.RegisterType<Logger>().As<ILogger>();

            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(RemoteDesktop.Grpc.WpfClient.Core)))
            //    .Where(t => t.Namespace.Contains(nameof(RemoteDesktop.Grpc.WpfClient.Core.Pocos)))
            //    .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            //builder.Register <>

            return builder.Build();
        }
    }
}
