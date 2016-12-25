using System;
using Template10.Mvvm;

namespace TraxxPlayer.UI.ViewModels
{
    public class AboutPageViewModel : CommonViewModel
    {
        public VersionPartViewModel VersionPartViewModel { get; } = new VersionPartViewModel();
    }

    public class VersionPartViewModel : ViewModelBase
    {
        public Uri Logo => Windows.ApplicationModel.Package.Current.Logo;

        public string DisplayName => Windows.ApplicationModel.Package.Current.DisplayName;

        public string Publisher => Windows.ApplicationModel.Package.Current.PublisherDisplayName;

        public string Version
        {
            get
            {
                var v = Windows.ApplicationModel.Package.Current.Id.Version;
                return $"{v.Major}.{v.Minor}.{v.Build}.{v.Revision}";
            }
        }
    }
}

