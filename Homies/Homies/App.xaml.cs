using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Homies.Services;
using Homies.Views;

namespace Homies
{
    public partial class App : Application
    {

        public static double ScreenWidth;
        public static double ScreenHeight;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            MainPage = new Carousel.WelcomePage();
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
