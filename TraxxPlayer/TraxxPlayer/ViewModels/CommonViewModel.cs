using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Template10.Common;
using Template10.Controls;
using Template10.Mvvm;
using TraxxPlayer.Views;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace TraxxPlayer.ViewModels
{
    public class CommonViewModel : ViewModelBase, INotifyPropertyChanged
    {
        new public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ShowErrorMessage(string errorMessage)
        {
            WindowWrapper.Current().Dispatcher.Dispatch(() =>
            {
                var modal = Window.Current.Content as ModalDialog;
                var errorDialog = new ErrorDialog(errorMessage);
                modal.ModalContent = errorDialog;
                modal.IsModal = true;
                modal.ModalBackground = new SolidColorBrush(Colors.Transparent);
            });
        }

        public void ShowWarningMessage(string warningMessage)
        {
            WindowWrapper.Current().Dispatcher.Dispatch(() =>
            {
                var modal = Window.Current.Content as ModalDialog;
                var warningDialog = new WarningDialog(warningMessage);
                modal.ModalContent = warningDialog;
                modal.IsModal = true;
                modal.ModalBackground = new SolidColorBrush(Colors.Transparent);
            });
        }
    }
}
