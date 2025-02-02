﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Homies.Droid.Services;
using Homies.Services.Interface;

[assembly: Xamarin.Forms.Dependency(typeof(ToastMessageAndroid))]
namespace Homies.Droid.Services
{
    public class ToastMessageAndroid : IToastMessage
    {

        static Context _context;

        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }

        public void ShowSnackbar(string message, int duration)
        {
            if (MainActivity.Instance != null)
            {
                var htmlMessage = Android.Text.Html.FromHtml($"<b><h4>{message}</h4></b>", Android.Text.FromHtmlOptions.ModeCompact);
                var view = ((Activity)MainActivity.Instance).FindViewById(Android.Resource.Id.Content);
                Android.Support.Design.Widget.Snackbar.Make(view, htmlMessage, duration).Show();
            }
               
        }
    }
}