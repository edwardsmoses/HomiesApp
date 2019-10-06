using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Homies.Pages.Welcome
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void SignUpButton_Clicked(object sender, EventArgs e)
        {
            var apiService = new Services.ApiService.ApiService();
            var signUpUserResponse = await apiService.RegisterUserAsync(EmailEntry.Text, PasswordEntry.Text, ConfirmPasswordEntry.Text);
            if (signUpUserResponse)
            {
                //after SignUp, get the token response, and navigate to the Main Page
                var tokenResponse = await apiService.GetTokenAsync(EmailEntry.Text, PasswordEntry.Text);

                if (string.IsNullOrEmpty(tokenResponse.access_token))
                    await Shell.Current.GoToAsync("//Login"); //if you can't get the Token, then go to the Login Page
                else
                {
                    //but if you can then get the Token and store it.
                    await SecureStorage.SetAsync(Common.GlobalConstants.AppAuthToken, "secret-oauth-token-value");
                    await Shell.Current.GoToAsync("//Main", true); //go to the Main Page
                }
            }
            else
                await DisplayAlert("Uh-oh!", "Something went wrong while creating your account.", "Cancel");
        }

        private async void TapSignIn_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Login");
        }
    }
}