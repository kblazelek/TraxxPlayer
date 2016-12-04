using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace TraxxPlayer.UI.ViewModels
{
    public class MeViewModel : CommonViewModel
    {
        #region private
        private string _userName;
        private bool? _isDefault;
        private ImageSource _profilePhoto;
        #endregion
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(nameof(UserName)); }
        }
        public bool? IsDefault
        {
            get { return _isDefault; }
            set { _isDefault = value; OnPropertyChanged(nameof(IsDefault)); }
        }
        public ImageSource ProfilePhoto
        {
            get { return _profilePhoto; }
            set { _profilePhoto = value; OnPropertyChanged(nameof(ProfilePhoto)); }
        }

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            ProfilePhoto = new BitmapImage(new Uri("ms-appx:///Assets/Person.jpg"));
            if (App.User != null)
            {
                UserName = App.User.username;
                IsDefault = App.User.isDefault;
            }
            return base.OnNavigatedToAsync(parameter, mode, state);
        }
    }
}
