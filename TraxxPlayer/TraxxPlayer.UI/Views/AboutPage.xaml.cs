using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace TraxxPlayer.UI.Views
{
    public sealed partial class AboutPage : Page
    {
        Template10.Services.SerializationService.ISerializationService _SerializationService;

        public AboutPage()
        {
            InitializeComponent();
            _SerializationService = Template10.Services.SerializationService.SerializationService.Json;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var index = int.Parse(_SerializationService.Deserialize(e.Parameter?.ToString()).ToString());
            MyPivot.SelectedIndex = index;
        }
    }
}
