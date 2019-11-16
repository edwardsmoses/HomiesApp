using Homies.ViewModels.Base;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Homies.ViewModels.AccountModels
{
    public class LoginPageModel : PageModelBase
    {

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        private string _Password;

        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                OnPropertyChanged();
            }
        }

        private bool _isValid;
        private bool _isEnabled;

        public LoginPageModel()
        {
        }

        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }




        public Command LoginCommand
        {
            get
            {
                return new Command(async () =>
               {
                   IsBusy = true;

                   if (Connectivity.NetworkAccess.Equals(NetworkAccess.ConstrainedInternet) || Connectivity.NetworkAccess.Equals(NetworkAccess.Internet))
                   {
                       var apiService = new Services.ApiService.ApiService();

                       var tokenResponse = await apiService.GetTokenAsync(Email, Password);

                       if (string.IsNullOrEmpty(tokenResponse.access_token))
                       {
                           //To-Do
                           //Show Snackbar Message letting the User know his UserName/Password is wrong
                           IsBusy = false;

                       }
                       else
                       {
                           //if the Access Details is right
                           //await SecureStorage.SetAsync(Common.GlobalConstants.AppAuthToken, tokenResponse.access_token);

                           //then Go to the Main Page
                           await Shell.Current.GoToAsync("//Main", true);
                       }
                   }


                   //To-Do 
                   //Show Snackbar Message saying There Is No Internet
                   IsBusy = false;

               });
            }
        }



    }
}

