using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookAPI.Models
{
    public class Facebook
    {
        public class User
        {
            public string id { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string link { get; set; }
            public string username { get; set; }
            public string gender { get; set; }
            public string locate { get; set; }
        }

        public class Json_Token
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public float expires_in { get; set; }
        }
    }
}