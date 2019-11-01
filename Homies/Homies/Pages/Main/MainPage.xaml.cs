using Common.ApiModels.FoodModels;
using Common.Models;
using Homies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Homies.Pages.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        ViewModels.MainModels.HomePageModel PageModel = new ViewModels.MainModels.HomePageModel();

        public MainPage()
        {
            InitializeComponent();

            BindingContext = PageModel;

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (PageModel.Foods.Count == 0)
                PageModel.LoadItemsCommand.Execute(null);
        }

        async void Handle_ItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FoodApiModel;
            if (item == null)
                return;

            await Navigation.PushModalAsync(new Foods.FoodDetail(item.Id.ToString()), true);

            // Manually deselect item.
            ((ListView)sender).SelectedItem = null;

        }
    }
}