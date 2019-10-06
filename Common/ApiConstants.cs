using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class ApiConstants
    {
        private const string OnlineClientUrl = "http://homiesapi.tra-pp.com";
        private const string ApiClientUrlForAndroidEmulator = "https://localhost:44355/";

        public static string ApiClientUrl => OnlineClientUrl;
        public static string HomiesApiUrl => $"{OnlineClientUrl}/api";

    }
}
