using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class TokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string username { get; set; }
        public string issued { get; set; }
        public string expires { get; set; }

    }
}
