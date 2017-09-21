using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookAPI.Models
{
    public class FacebookClass
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

        public class Result_Post_Id
        {
            public string id { get; set; }
        }

        public class Result_Post_Image
        {
            public string id { get; set; }
            public string post_id { get; set; }
        }

        public class Taggable_Friends
        {
            public User_Info[] data;
        }

        public class User_Info{
            public string id { get; set; }
            public string name { get; set; }
            public Picture picture { get; set; }
        }
        public class Picture
        {
            public Data data { get; set; }
        }

        public class Data
        {
            public bool is_silhouette { get; set; }
            public string url { get; set; }
        }

        public class User_Info_Display
        {
            public int num { get; set; }
            public string name { get; set;}
            public string picture_link { get; set; }
        }
    }
}