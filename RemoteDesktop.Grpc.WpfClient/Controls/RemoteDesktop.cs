using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RemoteDesktop.Grpc.WpfClient.Controls
{
    public class RemoteDesktop : Control
    {
        static RemoteDesktop()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RemoteDesktop), new FrameworkPropertyMetadata(typeof(RemoteDesktop)));
        }

        #region DP - RemoteMachineName

        public static readonly DependencyProperty RemoteMachineNameProperty
            = DependencyProperty.Register(nameof(RemoteMachineName), typeof(string), typeof(RemoteDesktop));
        public string RemoteMachineName
        {
            get { return (string)GetValue(RemoteMachineNameProperty); }
            set { SetValue(RemoteMachineNameProperty, value); }
        }

        #endregion

        #region DP - UserName

        public static readonly DependencyProperty UserNameProperty
            = DependencyProperty.Register(nameof(UserName), typeof(string), typeof(RemoteDesktop));
        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        #endregion

        #region DP - IsBusy

        public static readonly DependencyProperty IsBusyProperty
            = DependencyProperty.Register(nameof(IsBusy), typeof(string), typeof(RemoteDesktop));
        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }

        #endregion
    }
}