using FacebookAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacebookAPI.Admin
{
    public partial class ThongKe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Request.QueryString["code"] != "")
            {
                var obj = GetFacebookUserData(Request.QueryString["code"]);
            }
        }

        protected List<FacebookClass.User> GetFacebookUserData(string code)
        {
            if (code != string.Empty) { 
                // Exchange the code for an access token
                Uri targetUri = new Uri("https://graph.facebook.com/oauth/access_token?client_id=" + ConfigurationManager.AppSettings["FacebookAppId"] + "&client_secret=" + ConfigurationManager.AppSettings["FacebookAppSecret"] + "&redirect_uri=http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/admin/ThongKe.aspx&code=" + code);
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
            else
            {
                return new List<FacebookClass.User>();
            }
        }
    }
}