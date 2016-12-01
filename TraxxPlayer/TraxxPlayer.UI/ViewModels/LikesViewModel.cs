using System;
using System.Collections.ObjectModel;
using TraxxPlayer.Common.Messages;
using TraxxPlayer.Common.Models;
using Windows.UI.Xaml.Controls;

namespace TraxxPlayer.UI.ViewModels
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
