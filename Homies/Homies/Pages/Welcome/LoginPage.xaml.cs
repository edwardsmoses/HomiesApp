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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();


            var viewModel = new ViewModels.AccountModels.LoginPageModel();

            BindingContext = viewModel;

        }

        private async void TapSignUp_TappedAsync(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//SignUp");
        }
    }
}