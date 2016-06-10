using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace TraxxPlayer.ViewModels
{
    public class MeViewModel : CommonViewModel
    {
        #region private
        private string _firstName;
        private string _lastName;
        private string _website;
        private string _city;
        private string _country;
        private string _followers;
        private string _following;
        private ImageSource _profilePhoto;
        #endregion
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
        }
        public string Website
        {
            get { return _website; }
            set { _website = value; OnPropertyChanged(nameof(Website)); }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; OnPropertyChanged(nameof(City)); }
        }
        public string Country
        {
            get { return _country; }
            set { _country = value; OnPropertyChanged(nameof(Country)); }
        }
        public string Followers
        {
            get { return _followers; }
            set { _followers = value; OnPropertyChanged(nameof(Followers)); }
        }
        public string Following
        {
            get { return _following; }
            set { _following = value; OnPropertyChanged(nameof(Following)); }
        }
        public ImageSource ProfilePhoto
        {
            get { return _profilePhoto; }
            set { _profilePhoto = value; OnPropertyChanged(nameof(ProfilePhoto)); }
        }

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (App.SCUser != null)
            {
                FirstName = Convert.ToString(App.SCUser.first_name);
                LastName = Convert.ToString(App.SCUser.last_name);
                Website = Convert.ToString(App.SCUser.website);
                City = Convert.ToString(App.SCUser.city);
                Country = Convert.ToString(App.SCUser.country);
                Followers = Convert.ToString(App.SCUser.followers_count);
                Following = Convert.ToString(App.SCUser.followings_count);
                ProfilePhoto = new BitmapImage(new Uri(App.SCUser.avatar_url));
            }
            else
            {
                ProfilePhoto = new BitmapImage(new Uri("ms-appx:///Assets/Person.jpg"));
            }
            return base.OnNavigatedToAsync(parameter, mode, state);
        }
    }
}
