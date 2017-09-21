using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Collections;
using System.Configuration;
using FacebookAPI.Models;
using System.Web.Script.Serialization;

namespace FacebookAPI.Account
{
    public partial class user : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get the Facebook code from the querystring
            if (!Page.IsPostBack) 
            { 
                
            }
        }

        protected List<FacebookClass.User> GetFacebookUserData(string code)
        {
            // Exchange the code for an access token
            Uri targetUri = new Uri("https://graph.facebook.com/oauth/access_token?client_id=" + ConfigurationManager.AppSettings["FacebookAppId"] + "&client_secret=" + ConfigurationManager.AppSettings["FacebookAppSecret"] + "&redirect_uri=http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/account/user.aspx&code=" + code);
            HttpWebRequest at = (HttpWebRequest)HttpWebRequest.Create(targetUri);

            System.IO.StreamReader str = new System.IO.StreamReader(at.GetResponse().GetResponseStream());
            string json_token = str.ReadToEnd().ToString();

            JavaScriptSerializer js = new JavaScriptSerializer();
            FacebookClass.Json_Token oJsonToken = js.Deserialize<FacebookClass.Json_Token>(json_token);

            // Split the access token and expiration from the single string
            string accessToken = oJsonToken.access_token;

            // Exchange the code for an extended access token
            Uri eatTargetUri = new Uri("https://graph.facebook.com/oauth/access_token?grant_type=fb_exchange_token&client_id=" + ConfigurationManager.AppSettings["FacebookAppId"] + "&client_secret=" + ConfigurationManager.AppSettings["FacebookAppSecret"] + "&fb_exchange_token=" + accessToken);
            HttpWebRequest eat = (HttpWebRequest)HttpWebRequest.Create(eatTargetUri);

            StreamReader eatStr = new StreamReader(eat.GetResponse().GetResponseStream());
            string eatToken = eatStr.ReadToEnd().ToString().Replace("access_token=", "");

            // Split the access token and expiration from the single string
            //string[] eatWords = accessToken.Split('&');
            //string extendedAccessToken = eatWords[0];
            FacebookClass.Json_Token oJsonTokenExtended = js.Deserialize<FacebookClass.Json_Token>(eatToken);
            string extendedAccessToken = oJsonTokenExtended.access_token;
            Session["token_extended"] = extendedAccessToken;

            // Request the Facebook user information
            Uri targetUserUri = new Uri("https://graph.facebook.com/me?fields=first_name,last_name,gender,locale,link&access_token=" + accessToken);
            HttpWebRequest user = (HttpWebRequest)HttpWebRequest.Create(targetUserUri);

            // Read the returned JSON object response
            StreamReader userInfo = new StreamReader(user.GetResponse().GetResponseStream());
            string jsonResponse = string.Empty;
            jsonResponse = userInfo.ReadToEnd();

            // Deserialize and convert the JSON object to the Facebook.User object type
            JavaScriptSerializer sr = new JavaScriptSerializer();
            string jsondata = jsonResponse;
            FacebookClass.User converted = sr.Deserialize<FacebookClass.User>(jsondata);
            Session["user_id"] = converted.id;

            // Write the user data to a List
            List<FacebookClass.User> currentUser = new List<FacebookClass.User>();
            currentUser.Add(converted);

            // Return the current Facebook user
            return currentUser;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string token_extended = Session["token_extended"].ToString();
            string user_id = Session["user_id"].ToString();

            Uri targetUserUri = new Uri("https://graph.facebook.com/" + user_id + "/friendlists" + "?access_token=" + token_extended);
            HttpWebRequest user = (HttpWebRequest)HttpWebRequest.Create(targetUserUri);

            // Read the returned JSON object response
            StreamReader userInfo = new StreamReader(user.GetResponse().GetResponseStream());
            string jsonResponse = string.Empty;
            jsonResponse = userInfo.ReadToEnd();

            // Deserialize and convert the JSON object to the Facebook.User object type
            JavaScriptSerializer sr = new JavaScriptSerializer();
            string jsondata = jsonResponse;
        }
    }
}