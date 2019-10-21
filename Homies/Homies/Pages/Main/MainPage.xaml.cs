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

            var apiService = new Services.ApiService.ApiService();
            var foods = await apiService.GetAllFoodsAsync();
            foreach(var c in foods)
                PageModel.Foods.Add(c);
        }
    }
}