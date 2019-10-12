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
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel
            {
                Destinations = new List<Destination>() {
                 new Destination
                 {
                     Title = "Coffee",
                     ImageUrl = "coffee.jpeg",
                     Rating = 4.4f,
                     Votes = 3829
                 },
                 new Destination
                 {
                     Title = "Bean Plant",
                     ImageUrl = "plant.jpeg",
                     Rating = 4.9f,
                     Votes = 9783
                 }
                }
            };
        }
    }
}