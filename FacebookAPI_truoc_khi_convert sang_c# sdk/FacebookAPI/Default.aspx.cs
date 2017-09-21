using FacebookAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacebookAPI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSumbit_Click(object sender, EventArgs e)
        {
            //FbAPI fbapi = new FbAPI();
            //string token = fbapi.GetToken(txtUsername.Text, txtPassword.Text, Request.ServerVariables["SERVER_NAME"], Request.ServerVariables["SERVER_PORT"]);
            Response.Redirect("https://www.facebook.com/v2.10/dialog/oauth/?client_id=" + txtUsername.Text + "&redirect_uri=http://" + Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + "/admin/ThongKe.aspx&response_type=code&state=1");
            //if(token != null && token != String.Empty)
            //{
            //    string token_extended = fbapi.GetTokenExtended(token);
            //}
        }
    }
}