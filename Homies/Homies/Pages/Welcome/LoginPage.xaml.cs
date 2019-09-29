using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Homies.Pages.Welcome
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Main");
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            var apiService = new Services.ApiService.ApiService();
            var tokenResponse = await apiService.GetTokenAsync(EmailEntry.Text, PasswordEntry.Text);
            if (string.IsNullOrEmpty(tokenResponse.access_token))
                await DisplayAlert("Error", "Incorrect usename or password", "Alright");
            else
            {
                await Shell.Current.GoToAsync("//Main", true);
            }
        }
    }
}