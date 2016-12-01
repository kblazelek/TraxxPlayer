using Template10.Common;
using Template10.Controls;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace TraxxPlayer.UI.Views
{
    public sealed partial class WarningDialog : UserControl
    {
        public WarningDialog()
        {
            this.InitializeComponent();
        }

        public WarningDialog(string warningMessage) : this()
        {
            this.txtBoxWarningMessage.Text = warningMessage;
        }

        private void CloseDialog()
        {
            WindowWrapper.Current().Dispatcher.Dispatch(() =>
            {
                var modal = Window.Current.Content as ModalDialog;
                modal.IsModal = false;
                modal.ModalContent = null;
                modal.ModalBackground = new SolidColorBrush(Colors.Transparent);
            });
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            CloseDialog();
        }
    }
}
