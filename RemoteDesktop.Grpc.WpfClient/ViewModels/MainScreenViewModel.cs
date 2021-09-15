using Autofac;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using RemoteDesktop.Grpc.Client.Core;
using RemoteDesktop.Grpc.Client.Core.Pocos;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RemoteDesktop.Grpc.WpfClient.ViewModels
{
    public class MainScreenViewModel : ViewModelBase
    {
        #region Fields
        private IGrpcClient _grpcClient;
        #endregion

        #region Properties

        public ObservableCollection<RemoteComputerProxy> RemoteComputers { get; private set; } = new ObservableCollection<RemoteComputerProxy>();

        #endregion

        #region Commands

        public RelayCommand StartupCommand { get; private set; }
        #endregion


        #region Constructors

        public MainScreenViewModel(IGrpcClient grpcClient)
        {
            _grpcClient = grpcClient;
            StartupCommand = new RelayCommand(async () => await LoadRemoteComputers());
            StartupCommand.Execute(null);
        }

        #endregion

        #region Constructors

        private async Task LoadRemoteComputers()
        {
            _grpcClient.Build("https://localhost:5001");
            foreach (var remoteComputer in await _grpcClient.GetRemoteComputersAsync("123450"))
            {
                RemoteComputers.Add(remoteComputer);
            }
        }

        #endregion
    }
}
