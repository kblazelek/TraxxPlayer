using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Template10.Common;
using Template10.Controls;
using TraxxPlayer.Services;
using TraxxPlayer.Services.Helpers;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace TraxxPlayer.UI.Views
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
        public event PropertyChangedEventHandler PropertyChanged;
        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
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
