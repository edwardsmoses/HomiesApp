using Homies.ViewModels.FoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Homies.Pages.Foods
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodDetail : ContentPage
    {
        private readonly string id;
        private double _pageHeight;


        FoodDetailModel PageModel = new FoodDetailModel();

        public FoodDetail(string id)
        {
            InitializeComponent();

            BindingContext = PageModel;
            this.id = id;
        }

        protected override async void OnAppearing()
        {
            await cakeDetail.TranslateTo(0, header.Y, 500, Easing.SinOut);
            await header.FadeTo(1);
            base.OnAppearing();

            var apiService = new Services.ApiService.ApiService();
            PageModel.Food = await apiService.GetFoodAsync(id);
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            _pageHeight = height;
            cakeDetail.TranslationY = _pageHeight * .65;
            header.FadeTo(0, 0);
            base.OnSizeAllocated(width, height);
        }

        async void Handle_Tapped(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}