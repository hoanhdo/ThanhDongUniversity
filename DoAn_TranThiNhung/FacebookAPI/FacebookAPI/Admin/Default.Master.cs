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
            FacebookClass.Me me = new FacebookClass.Me();// Tạo object me
            me.username = Session["username"].ToString();// lấy thông tin của username 
            me.user_id = Session["user_id"].ToString();// lấy thông tin user_id
            List<FacebookClass.Me> list_me = new List<FacebookClass.Me>();
            list_me.Add(me);
            ListView1.DataSource = list_me;
            ListView1.DataBind();// bind data vào tring listview
        }

        public string GetActive()
        {
            return System.IO.Path.GetFileNameWithoutExtension(System.Web.HttpContext.Current.Request.Url.AbsolutePath).ToLower();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["token_extended"] != null)
            {
                GetUserData(Session["token_extended"].ToString());//lấy thông tin của user
            }
            else if (Request.QueryString["code"] != null)
            {
                try
                {
                    string accessCode = Request.QueryString["code"].ToString();//lấy code từ query string
                    var fb = new FacebookClient();// khởi tạo class FacebookClient
                    // throws OAuthException 
                    dynamic result = fb.Post("oauth/access_token", new
                    {
                        client_id = Session["app_id"].ToString(),
                        client_secret = Session["app_secret"].ToString(),
                        redirect_uri = "http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/admin/ThongKe.aspx",
                        code = accessCode
                    });// tạo post request lấy access_token
                    var accessToken = result.access_token;
                    var expires = result.expires;
                    // Store the access token in the session
                    Session["token_extended"] = accessToken;// gắn access_token vào session
                    GetUserData(Session["token_extended"].ToString());// lấy thông tin người dùng
                }
                catch (Facebook.FacebookOAuthException)
                {
                    //Nếu đăng nhập sai thì chuyển hướng về trang Default.aspx
                    Response.Redirect("http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "Default.aspx");
                }
            }
            else
            {
                //Nếu k có code gửi lấy được từ querystring thì điều hướng về trang default
                Response.Redirect("http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "Default.aspx");
            }
        }

        private void GetUserData(string token)
        {
            FacebookClient fb = new FacebookClient(token);// tạo object facebook client
            dynamic me = fb.Get("me?fields=first_name,last_name,gender,locale,link");// Lấy ra thông tin của người dùng
            Session["username"] = me.first_name + " " + me.last_name;//lấy ra tên người dùng
            Session["user_id"] = me.id;//lấy ra id người dùng

            //láy ra app token
            dynamic app_token = fb.Get("oauth/access_token?client_id=" + Session["app_id"].ToString() + "&client_secret=" + Session["app_secret"].ToString() + "&grant_type=client_credentials");
            Session["app_token"] = app_token.access_token;
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            var fb = new FacebookClient();//khởi tạo object facebook client
            var logoutUrl = fb.GetLogoutUrl(new
            {
                access_token = Session["token_extended"],
                next = "redirect_uri"

            });// logout facebook 
            Session.RemoveAll();//Xóa tất cả các biến trong session
            Response.Redirect(logoutUrl.AbsoluteUri);// điều hướng về link logout facebook và trả lại link default
        }
    }
}