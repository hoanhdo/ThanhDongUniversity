using FacebookAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook;

namespace FacebookAPI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSumbit_Click(object sender, EventArgs e)
        {
            try
            {
                //FbAPI fbapi = new FbAPI();
                //string token = fbapi.GetToken(txtUsername.Text, txtPassword.Text, Request.ServerVariables["SERVER_NAME"], Request.ServerVariables["SERVER_PORT"]);
                //Response.Redirect("https://www.facebook.com/v2.10/dialog/oauth/?client_id=" + txtUsername.Text + "&redirect_uri=http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/admin/ThongKe.aspx&response_type=code&state=1");
                FacebookClient fb = new FacebookClient(); // tạo object facebook client
                var loginUrl = fb.GetLoginUrl(new 
                {
                    client_id = txtUsername.Text,
                    redirect_uri = "http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/admin/ThongKe.aspx",
                    response_type = "code",
                    scope = "publish_actions,user_friends,user_posts,read_custom_friendlists,pages_show_list,manage_pages" // Add other permissions as needed
                });// Thông tin đường link xác thực facebook bao gồm client_id, link sẽ redirect về, và các quyền của app
                Session["app_id"] = txtUsername.Text;// gắn app id vào session để sử dụng 
                Session["app_secret"] = txtPassword.Text; //gắn app secret vào session để sử dụng
                Response.Redirect(loginUrl.AbsoluteUri); // redirect đến link xác thực , xác thực thành công sẽ redirect về trang Admin

                //if(token != null && token != String.Empty)
                //{
                //    string token_extended = fbapi.GetTokenExtended(token);
                //}
            }
            catch (Exception)
            {
                
            }
        }
    }
}