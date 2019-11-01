using Homies.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Homies.ViewModels.MainModels
{
    public class HomePageModel : PageModelBase
    {
        private bool isBusy;

        public HomePageModel()
        {
            this.Foods = new ObservableCollection<Common.ApiModels.FoodModels.FoodApiModel>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }
        public ObservableCollection<Common.ApiModels.FoodModels.FoodApiModel> Foods { get; set; }

        public Command LoadItemsCommand { get; set; }


        public bool IsRefreshing
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }


        protected bool SetProperty<T>(ref T backingStore, T value,
           [CallerMemberName]string propertyName = "",
           Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        async Task ExecuteLoadItemsCommand()
        {
            if (IsRefreshing)
                return;

            IsRefreshing = true;

            try
            {
                Foods.Clear();
                var apiService = new Services.ApiService.ApiService();
                var foods = await apiService.GetAllFoodsAsync();
                foreach (var c in foods)
                    Foods.Add(c);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsRefreshing = false;
            }
        }

    
    }
}
