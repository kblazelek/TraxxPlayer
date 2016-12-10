using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace TraxxPlayer.UI.Converters
{
    public class AutoSuggestBoxSuggestionChosenParameterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var args = (AutoSuggestBoxSuggestionChosenEventArgs)value;
            return (string)args.SelectedItem;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
