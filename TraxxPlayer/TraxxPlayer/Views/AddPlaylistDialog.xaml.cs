using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Template10.Common;
using Template10.Controls;
using TraxxPlayer.Services;
using TraxxPlayer.Services.Helpers;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace TraxxPlayer.Views
{
    public sealed partial class AddPlaylistDialog : UserControl
    {
        public delegate void ClosingDelegate();
        public event ClosingDelegate Closing;

        public AddPlaylistDialog()
        {
            this.InitializeComponent();
        }
        // TODO: Add validation
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            PlaylistService.AddPlaylist(new PlaylistToAdd() { Name = txtBoxPlaylistName.Text, UserID = App.SCUser.id });
            CloseDialog();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            CloseDialog();
        }

        private void CloseDialog()
        {
            Closing();
            WindowWrapper.Current().Dispatcher.Dispatch(() =>
            {
                var modal = Window.Current.Content as ModalDialog;
                modal.IsModal = false;
                modal.ModalContent = null;
                modal.ModalBackground = new SolidColorBrush(Colors.Transparent);
            });
        }
    }
}
