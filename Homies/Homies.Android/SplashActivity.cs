﻿using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace Homies.Droid
{
    [Activity(
        Label = "@string/appName",
        Icon = "@mipmap/icon",
        Theme = "@style/SplashTheme",
        MainLauncher = false,
        NoHistory = true,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}
