using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Template10.Common;
using Template10.Controls;
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
