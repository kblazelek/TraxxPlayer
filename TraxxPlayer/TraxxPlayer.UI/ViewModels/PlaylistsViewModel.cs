using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Template10.Common;
using Template10.Controls;
using Template10.Mvvm;
using TraxxPlayer.Services;
using TraxxPlayer.Services.Helpers;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TraxxPlayer.UI.Views;
using TraxxPlayer.Common.Exceptions;

namespace TraxxPlayer.UI.ViewModels
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
            if (obj != null)
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
            try
            {
                PlaylistService.DeletePlaylist(obj.id);
                RefreshPlaylists();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
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

        public async Task PlaylistClicked(object sender, ItemClickEventArgs e)
        {
            try
            {
                var playlist = e.ClickedItem as PlaylistToDisplay;
                await App.PlaylistManager.PlayPlaylist(playlist);
            }
            catch (EmptyPlaylistException ex)
            {
                ShowWarningMessage(ex.Message);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            try
            {
                LoadPlaylists();
                return base.OnNavigatedToAsync(parameter, mode, state);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
                return Task.FromException(ex);
            }
        }

        public void RefreshPlaylists()
        {
            try
            {
                if (Playlists.Count > 0)
                {
                    Playlists.Clear();
                }
                LoadPlaylists();
            }
            catch(Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }

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
