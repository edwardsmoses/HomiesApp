using Homies.ViewModels.Base;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Homies.ViewModels.AccountModels
{
    public class SignUpPageModel : PageModelBase
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

        private string _ConfirmPassword;

        public string ConfirmPassword
        {
            get { return _ConfirmPassword; }
            set
            {
                _ConfirmPassword = value;
                OnPropertyChanged();
            }
        }




        private bool _isValid;
        private bool _isEnabled;

        public SignUpPageModel()
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




        public Command SignUpCommand
        {
            get
            {
                return new Command(async () =>
               {
                   IsBusy = true;

                   if (Connectivity.NetworkAccess.Equals(NetworkAccess.ConstrainedInternet) || Connectivity.NetworkAccess.Equals(NetworkAccess.Internet))
                   {
                       var apiService = new Services.ApiService.ApiService();
                       var signUpUserResponse = await apiService.RegisterUserAsync(Email, Password, ConfirmPassword);
                       if (signUpUserResponse)
                       {
                           //after SignUp, get the token response, and navigate to the Main Page
                           var tokenResponse = await apiService.GetTokenAsync(Email, Password);

                           if (string.IsNullOrEmpty(tokenResponse.access_token))
                               await Shell.Current.GoToAsync("//Login"); //if you can't get the Token, then go to the Login Page
                           else
                           {
                               //but if you can then get the Token and store it.
                               await SecureStorage.SetAsync(Common.GlobalConstants.AppAuthToken, tokenResponse.access_token);
                               await Shell.Current.GoToAsync("//Main", true); //go to the Main Page
                           }
                       }

                       //To-Do
                       //Show Snackbar Message saying something went wrong
                       IsBusy = false;
                   }

                   //To-Do 
                   //Show Snackbar Message saying There Is No Internet
                   IsBusy = false;

               });
            }
        }



    }
}

