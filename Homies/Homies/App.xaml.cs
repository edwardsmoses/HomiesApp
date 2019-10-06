using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Homies.Services;
using Homies.Views;
using Xamarin.Essentials;

namespace Homies
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            MainPage = new AppShell();

            CheckIfUserIsLoggedIn();

        }

        private async void CheckIfUserIsLoggedIn()
        {
            //if the Access Token stored is not empty
            if (!string.IsNullOrWhiteSpace(await SecureStorage.GetAsync(Common.GlobalConstants.AppAuthToken)))
            {
                await Shell.Current.GoToAsync("//Main", true); //go to the Main Page
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
