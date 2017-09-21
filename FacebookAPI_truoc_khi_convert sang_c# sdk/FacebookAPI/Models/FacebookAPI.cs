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
        public string GetToken(string app_id, string app_secret, string server, string port)
        {
            // Exchange the code for an access token
            Uri targetUri = new Uri("https://graph.facebook.com/oauth/access_token?client_id=" + app_id + "&client_secret=" + app_secret + "&redirect_uri=http://" + server + ":" + port + "/account/user.aspx");
            HttpWebRequest at = (HttpWebRequest)HttpWebRequest.Create(targetUri);

            System.IO.StreamReader str = new System.IO.StreamReader(at.GetResponse().GetResponseStream());
            string json_token = str.ReadToEnd().ToString();
            return json_token;
        }

        public string GetTokenExtended(string app_id, string app_secret, string server, string port)
        {
            string token = GetToken(app_id, app_secret, server, port);

            Uri eatTargetUri = new Uri("https://graph.facebook.com/oauth/access_token?grant_type=fb_exchange_token&client_id=" + ConfigurationManager.AppSettings["FacebookAppId"] + "&client_secret=" + ConfigurationManager.AppSettings["FacebookAppSecret"] + "&fb_exchange_token=" + token);
            HttpWebRequest eat = (HttpWebRequest)HttpWebRequest.Create(eatTargetUri);

            StreamReader eatStr = new StreamReader(eat.GetResponse().GetResponseStream());
            string eatToken = eatStr.ReadToEnd().ToString().Replace("access_token=", "");

            JavaScriptSerializer js = new JavaScriptSerializer();
            FacebookClass.Json_Token oJsonTokenExtended = js.Deserialize<FacebookClass.Json_Token>(eatToken);
            string extendedAccessToken = oJsonTokenExtended.access_token;
            return extendedAccessToken;
        }

        public string GetTokenExtended(string token)
        {
            Uri eatTargetUri = new Uri("https://graph.facebook.com/oauth/access_token?grant_type=fb_exchange_token&client_id=" + ConfigurationManager.AppSettings["FacebookAppId"] + "&client_secret=" + ConfigurationManager.AppSettings["FacebookAppSecret"] + "&fb_exchange_token=" + token);
            HttpWebRequest eat = (HttpWebRequest)HttpWebRequest.Create(eatTargetUri);

            StreamReader eatStr = new StreamReader(eat.GetResponse().GetResponseStream());
            string eatToken = eatStr.ReadToEnd().ToString().Replace("access_token=", "");

            JavaScriptSerializer js = new JavaScriptSerializer();
            FacebookClass.Json_Token oJsonTokenExtended = js.Deserialize<FacebookClass.Json_Token>(eatToken);
            string extendedAccessToken = oJsonTokenExtended.access_token;
            return extendedAccessToken;
        }

        public string GetAllFriends(string user_id, string token)
        {
            Uri targetUserUri = new Uri("https://graph.facebook.com/" + user_id + "/taggable_friends" + "?access_token=" + token);
            HttpWebRequest user = (HttpWebRequest)HttpWebRequest.Create(targetUserUri);

            // Read the returned JSON object response
            StreamReader userInfo = new StreamReader(user.GetResponse().GetResponseStream());
            string jsonResponse = string.Empty;
            jsonResponse = userInfo.ReadToEnd();

            return jsonResponse;
        }

        public string GetAllFriendsUseApp(string user_id, string token)
        {
            Uri targetUserUri = new Uri("https://graph.facebook.com/" + "me/friends" + "?access_token=" + token);
            HttpWebRequest user = (HttpWebRequest)HttpWebRequest.Create(targetUserUri);

            // Read the returned JSON object response
            StreamReader userInfo = new StreamReader(user.GetResponse().GetResponseStream());
            string jsonResponse = string.Empty;
            jsonResponse = userInfo.ReadToEnd();

            return jsonResponse;
        }

        public HttpWebRequest CreateRequest(string param, string method)
        {
            Uri targetUri = new Uri("https://graph.facebook.com/" + param);
            HttpWebRequest hwrq = (HttpWebRequest)HttpWebRequest.Create(targetUri);
            hwrq.Method = method;
            return hwrq;
        }

        public string GetResponse(HttpWebRequest httpwebreq)
        {
            StreamReader userInfo = new StreamReader(httpwebreq.GetResponse().GetResponseStream());
            string jsonResponse = string.Empty;
            jsonResponse = userInfo.ReadToEnd();
            return jsonResponse;
        }
        
        public T DeserializeJsonToObject<T>(string jsonToDeserializeToObject)
        {
            JavaScriptSerializer sr = new JavaScriptSerializer();
            var serializedJson = sr.Deserialize<T>(jsonToDeserializeToObject);
            return serializedJson;
        }

        public bool PostMessage(string message, string link, string picture_link, string token)
        {
            string post = "me/feed" + "?message=" + message + "&link=" + link + "&picture=" + picture_link + "&access_token=" + token; 
            HttpWebRequest post_request = CreateRequest(post, WebRequestMethods.Http.Post);
            string response = GetResponse(post_request);
            FacebookClass.Result_Post_Id result = DeserializeJsonToObject<FacebookClass.Result_Post_Id>(response);
            if (result.id != null)
            {
                return true;
            }
            return false;
        }

        public bool PostImage(string image_url,string caption, string token)
        {
            string post = "me/photos" + "?url=" + image_url + "&caption=" + caption + "&access_token=" + token;
            HttpWebRequest post_request = CreateRequest(post, WebRequestMethods.Http.Post);
            string response = GetResponse(post_request);
            FacebookClass.Result_Post_Image result = DeserializeJsonToObject<FacebookClass.Result_Post_Image>(response);
            if (result.id != null)
            {
                return true;
            }
            return false;
        }
    }
}