using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook;

namespace FacebookAPI
{
    public partial class Default1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSumbit_Click(object sender, EventArgs e)
        {
            ////FbAPI fbapi = new FbAPI();
            ////string token = fbapi.GetToken(txtUsername.Text, txtPassword.Text, Request.ServerVariables["SERVER_NAME"], Request.ServerVariables["SERVER_PORT"]);
            ////Response.Redirect("https://www.facebook.com/v2.10/dialog/oauth/?client_id=" + txtUsername.Text + "&redirect_uri=http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/admin/ThongKe.aspx&response_type=code&state=1");
            //FacebookClient fb = new FacebookClient();
            //var loginUrl = fb.GetLoginUrl(new
            //{
            //    client_id = txtUsername.Text,
            //    redirect_uri = "http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/admin/ThongKe.aspx",
            //    response_type = "code",
            //    scope = "publish_actions,user_friends,user_posts,read_custom_friendlists" // Add other permissions as needed
            //});
            //Session["app_id"] = txtUsername.Text;
            //Session["app_secret"] = txtPassword.Text;
            //Response.Redirect(loginUrl.AbsoluteUri);

            ////if(token != null && token != String.Empty)
            ////{
            ////    string token_extended = fbapi.GetTokenExtended(token);
            ////}
        }
    }
}