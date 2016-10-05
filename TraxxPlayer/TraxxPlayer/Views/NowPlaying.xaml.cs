using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using BackgroundAudioShared.Messages;
using BackgroundAudioShared;
using System.Threading;
using Windows.ApplicationModel;
using Windows.Media.Playback;
using Windows.UI.Core;
using TraxxPlayer.ViewModels;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TraxxPlayer.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NowPlaying : Page
    {
        public NowPlaying()
        {
            this.InitializeComponent();
        }
    }
}
