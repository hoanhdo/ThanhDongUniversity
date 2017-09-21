using Facebook;
using FacebookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacebookAPI.Admin
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FacebookClass.Me me = new FacebookClass.Me();
            me.username = Session["username"].ToString();
            me.user_id = Session["user_id"].ToString();
            List<FacebookClass.Me> list_me = new List<FacebookClass.Me>();
            list_me.Add(me);
            ListView1.DataSource = list_me;
            ListView1.DataBind();
        }

        public string GetActive()
        {
            return System.IO.Path.GetFileNameWithoutExtension(System.Web.HttpContext.Current.Request.Url.AbsolutePath).ToLower();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["token_extended"] != null)
            {
                GetUserData(Session["token_extended"].ToString());
            }
            else if (Request.QueryString["code"] != null)
            {
                try
                {
                    string accessCode = Request.QueryString["code"].ToString();
                    var fb = new FacebookClient();
                    // throws OAuthException 
                    dynamic result = fb.Post("oauth/access_token", new
                    {
                        client_id = Session["app_id"].ToString(),
                        client_secret = Session["app_secret"].ToString(),
                        redirect_uri = "http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/admin/ThongKe.aspx",
                        code = accessCode
                    });
                    var accessToken = result.access_token;
                    var expires = result.expires;
                    // Store the access token in the session
                    Session["token_extended"] = accessToken;
                    GetUserData(Session["token_extended"].ToString());
                }
                catch (Facebook.FacebookOAuthException)
                {
                    Response.Redirect("http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "Default.aspx");
                }
            }
            else
            {
                Response.Redirect("http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "Default.aspx");
            }
        }

        private void GetUserData(string token)
        {
            FacebookClient fb = new FacebookClient(token);
            dynamic me = fb.Get("me?fields=first_name,last_name,gender,locale,link");
            Session["username"] = me.first_name + " " + me.last_name;
            Session["user_id"] = me.id;

            dynamic app_token = fb.Get("oauth/access_token?client_id=" + Session["app_id"].ToString() + "&client_secret=" + Session["app_secret"].ToString() + "&grant_type=client_credentials");
            Session["app_token"] = app_token.access_token;
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            var fb = new FacebookClient();
            var logoutUrl = fb.GetLogoutUrl(new
            {
                access_token = Session["token_extended"],
                next = "redirect_uri"

            });
            Session.RemoveAll();
            Response.Redirect(logoutUrl.AbsoluteUri);
        }
    }
}