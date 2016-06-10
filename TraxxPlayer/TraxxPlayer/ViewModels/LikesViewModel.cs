using BackgroundAudioShared;
using BackgroundAudioShared.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace TraxxPlayer.ViewModels
{
    public class LikesViewModel : CommonViewModel
    {
        public ObservableCollection<SoundCloudTrack> Likes { get; set; }
        public LikesViewModel()
        {
            Likes = new ObservableCollection<SoundCloudTrack>(App.likes);
        }
        public void ItemClicked (object sender, ItemClickEventArgs e)
        {
            var song = e.ClickedItem as SoundCloudTrack;
            MessageService.SendMessageToBackground(new TrackChangedMessage(new Uri(song.stream_url)));
        }
    }
}
