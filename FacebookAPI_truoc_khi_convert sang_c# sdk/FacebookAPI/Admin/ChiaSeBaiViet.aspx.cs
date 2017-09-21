using FacebookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacebookAPI.Admin
{
    public partial class ChiaSeBaiViet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChiaSeBaiViet_Click(object sender, EventArgs e)
        {
            FbAPI fbapi = new FbAPI();
            bool response = fbapi.PostMessage(txtNoiDungCanChiaSe.Text, txtLinkChiaSe.Text, txtAnhChiaSe.Text, Session["token_extended"].ToString());
            if(response)
            {

            }
        }
    }
}