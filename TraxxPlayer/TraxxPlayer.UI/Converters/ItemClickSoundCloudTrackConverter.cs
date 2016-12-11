using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraxxPlayer.Common.Models;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace TraxxPlayer.UI.Converters
{
    public class ItemClickSoundCloudTrackConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var args = (ItemClickEventArgs)value;
            return (SoundCloudTrack)args.ClickedItem;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
