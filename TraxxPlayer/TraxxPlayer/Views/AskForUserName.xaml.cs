using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TraxxPlayer.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AskForUserName : Page
    {
        public AskForUserName()
        {
            this.InitializeComponent();
            this.Loaded += AskForUserName_Loaded;
        }

        private void AskForUserName_Loaded(object sender, RoutedEventArgs e)
        {
            autoSuggestBoxUserName.Focus(FocusState.Programmatic);
            autoSuggestBoxUserName.Focus(FocusState.Keyboard);
            autoSuggestBoxUserName.Focus(FocusState.Pointer);
        }

        private void autoSuggestBoxUserName_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                ViewModel.AddSoundCloudUser();
            }
        }
    }
}
