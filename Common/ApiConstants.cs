using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class ApiConstants
    {
        private const string OnlineClientUrl = "";
        private const string ApiClientUrlForAndroidEmulator = "https://localhost:44355/";
        public static string ApiClientUrl => ApiClientUrlForAndroidEmulator;
    }
}
