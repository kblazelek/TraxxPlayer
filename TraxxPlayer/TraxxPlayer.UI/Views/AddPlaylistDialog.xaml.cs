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
            PlaylistService.AddPlaylist(new PlaylistToAdd() { Name = txtBoxPlaylistName.Text, UserID = App.User.id });
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
