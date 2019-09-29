using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Homies
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            //Routing.RegisterRoute("Welcome", typeof(Pages.Welcome.WelcomePage));
        }

       
    }
}
