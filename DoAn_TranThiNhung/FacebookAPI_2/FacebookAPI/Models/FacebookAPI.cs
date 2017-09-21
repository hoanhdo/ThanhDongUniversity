using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace FacebookAPI.Models
{
    public class FbAPI
    {
        public string GetToken(string app_id, string app_secret)
        {
            // Exchange the code for an access token
            Uri targetUri = new Uri("https://graph.facebook.com/oauth/access_token?client_id=" + app_id + "&client_secret=" + app_secret);
            HttpWebRequest at = (HttpWebRequest)HttpWebRequest.Create(targetUri);

            System.IO.StreamReader str = new System.IO.StreamReader(at.GetResponse().GetResponseStream());
            string json_token = str.ReadToEnd().ToString();
            return json_token;
        }

        public string GetTokenExtended(string app_id, string app_secret)
        {
            string token = GetToken(app_id, app_secret);

            Uri eatTargetUri = new Uri("https://graph.facebook.com/oauth/access_token?grant_type=fb_exchange_token&client_id=" + ConfigurationManager.AppSettings["FacebookAppId"] + "&client_secret=" + ConfigurationManager.AppSettings["FacebookAppSecret"] + "&fb_exchange_token=" + token);
            HttpWebRequest eat = (HttpWebRequest)HttpWebRequest.Create(eatTargetUri);

            StreamReader eatStr = new StreamReader(eat.GetResponse().GetResponseStream());
            string eatToken = eatStr.ReadToEnd().ToString().Replace("access_token=", "");

            JavaScriptSerializer js = new JavaScriptSerializer();
            Facebook.Json_Token oJsonTokenExtended = js.Deserialize<Facebook.Json_Token>(eatToken);
            string extendedAccessToken = oJsonTokenExtended.access_token;
            return extendedAccessToken;
        }

    }
}