using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public sealed partial class EditPlaylistDialog : UserControl, INotifyPropertyChanged
    {
        public delegate void ClosingDelegate();
        public event ClosingDelegate Closing;
        public PlaylistToDisplay Playlist { get; set; }
        string newPlaylistName = "";
        public string NewPlaylistName
        {
            get { return newPlaylistName; }
            set { newPlaylistName = value; OnPropertyChanged(nameof(NewPlaylistName)); }
        }
        new public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public EditPlaylistDialog(PlaylistToDisplay p)
        {
            this.DataContext = this;
            Playlist = p;
            NewPlaylistName = p.Name;
            this.InitializeComponent();
        }
        // TODO: Add validation
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if(NewPlaylistName != Playlist.Name && !String.IsNullOrEmpty(NewPlaylistName))
            {
                Playlist.Name = NewPlaylistName;
                PlaylistService.ModifyPlaylist(Playlist);
            }
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
