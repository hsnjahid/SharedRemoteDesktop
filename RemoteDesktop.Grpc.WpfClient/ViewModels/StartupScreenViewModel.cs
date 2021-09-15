using Autofac;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RemoteDesktop.Grpc.WpfClient.ViewModels
{

    public class Server
    {
        #region Properties

        public string IpAddress { get; set; }
        public uint Port { get; set; }
        public string Name => $"{IpAddress}/{Port}";
        #endregion
    }
    public sealed class StartupScreenViewModel : ViewModelBase
    {
        #region Properties

        public Server SelectedServer { get; set; }

        public ObservableCollection<Server> AvailablServers { get; set; } = new ObservableCollection<Server>();

        public RelayCommand OnServerSelectionCommand { get; set; }

        #endregion

        #region Events

        public event EventHandler CloseRequest;
        
        #endregion


        public StartupScreenViewModel()
        {
            AvailablServers.Add(new Server() { IpAddress = "localhost", Port = 5001 });
            OnServerSelectionCommand = new RelayCommand(ConnectServer);
        }

        private void ConnectServer()
        {
            var address = $"https://{SelectedServer.IpAddress}:{SelectedServer.Port}";

            //using(var scope = App.Container.BeginLifetimeScope())
            //{
            //    App.Current.MainWindow.DataContext = scope.Resolve<IRemoteComputersViewModel>();
            //}

            CloseRequest.Invoke(this, null);            
        }

    }
}
