using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Common;
using Template10.Controls;
using Template10.Mvvm;
using TraxxPlayer.Services;
using TraxxPlayer.Services.Helpers;
using TraxxPlayer.Views;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TraxxPlayer.ViewModels
{
    public class PlaylistsViewModel : CommonViewModel
    {
        public ObservableCollection<PlaylistToDisplay> Playlists { get; set; } = new ObservableCollection<PlaylistToDisplay>();
        DelegateCommand<PlaylistToDisplay> deletePlaylistCommand;
        DelegateCommand<PlaylistToDisplay> editPlaylistCommand;
        public DelegateCommand<PlaylistToDisplay> DeletePlaylistCommand => deletePlaylistCommand ?? (deletePlaylistCommand = new DelegateCommand<PlaylistToDisplay>(DeletePlaylist));
        public DelegateCommand<PlaylistToDisplay> EditPlaylistCommand => editPlaylistCommand ?? (editPlaylistCommand = new DelegateCommand<PlaylistToDisplay>(EditPlaylist));

        private void EditPlaylist(PlaylistToDisplay obj)
        {
            if(obj != null)
            {
                WindowWrapper.Current().Dispatcher.Dispatch(() =>
                {
                    var modal = Window.Current.Content as ModalDialog;
                    var editPlaylistDialog = new EditPlaylistDialog(obj);
                    editPlaylistDialog.Closing += DialogClosed;
                    modal.ModalContent = editPlaylistDialog;
                    modal.IsModal = true;
                    modal.ModalBackground = new SolidColorBrush(Colors.Transparent);
                });
            }
        }

        private void DeletePlaylist(PlaylistToDisplay obj)
        {
            if(obj != null)
            {
                try
                {
                    PlaylistService.DeletePlaylist(obj.id);
                    RefreshPlaylists();
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message); // dodać obsługę wyjątków
                }
            }
        }

        public void ShowAddPlaylistDialog()
        {
            WindowWrapper.Current().Dispatcher.Dispatch(() =>
            {
                var modal = Window.Current.Content as ModalDialog;
                var addPlaylistDialog = new AddPlaylistDialog();
                addPlaylistDialog.Closing += DialogClosed;
                modal.ModalContent = addPlaylistDialog;
                modal.IsModal = true;
                modal.ModalBackground = new SolidColorBrush(Colors.Transparent);
            });
        }

        private void DialogClosed()
        {
            RefreshPlaylists();
        }

        public void PlaylistClicked(object sender, ItemClickEventArgs e)
        {
            var playlist = e.ClickedItem as PlaylistToDisplay;
        }

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            LoadPlaylists();
            return base.OnNavigatedToAsync(parameter, mode, state);
        }

        public void RefreshPlaylists()
        {
            if(Playlists.Count > 0)
            {
                Playlists.Clear();
            }
            LoadPlaylists();

        }
        public void LoadPlaylists()
        {
            // Uniezależnić od App
            var tempPlaylists = PlaylistService.GetPlaylists(App.SCUser.id);
            foreach (var playlist in tempPlaylists)
            {
                Playlists.Add(playlist);
            }
        }
    }
}
