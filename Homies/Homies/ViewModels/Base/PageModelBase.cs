using Homies.Services.Interface;
using System.Collections.Generic;
using System.ComponentModel;

namespace Homies.ViewModels.Base
{
    public class PageModelBase : INotifyPropertyChanged
    {
        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; OnPropertyChanged(); }
        }

        public void LongAlert(string message) => Xamarin.Forms.DependencyService.Get<IToastMessage>().LongAlert(message);
        public void ShortAlert(string message) => Xamarin.Forms.DependencyService.Get<IToastMessage>().ShortAlert(message);
        public void ShowSnackbar(string message, int duration = 800) => Xamarin.Forms.DependencyService.Get<IToastMessage>().ShowSnackbar(message, duration);


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}

