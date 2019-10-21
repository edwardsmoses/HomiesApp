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

            var viewModel = new ViewModels.AccountModels.SignUpPageModel();

            BindingContext = viewModel;

            EmailEntry.Completed += (object sender, EventArgs e) => {
                PasswordEntry.Focus();
            };

            PasswordEntry.Completed += (object sender, EventArgs e) => {
                ConfirmPasswordEntry.Focus();
            };

            ConfirmPasswordEntry.Completed += (object sender, EventArgs e) => {
                viewModel.SignUpCommand.Execute(null);
            };

        }

        private async void TapSignIn_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Login");
        }
    }
}