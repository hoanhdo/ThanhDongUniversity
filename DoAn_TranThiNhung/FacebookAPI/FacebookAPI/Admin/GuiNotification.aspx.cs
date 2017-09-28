using Facebook;
using FacebookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacebookAPI.Admin
{
    public partial class GuiNotification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            divthongbao.Visible = false;
            ClearData();
        }
        protected void btnGuiThongBao_Click(object sender, EventArgs e)
        {
            try
            {
                //FacebookClient client = new FacebookClient();
                string post_notification = "/" + Session["user_id"].ToString() + "/notifications?"+ "access_token=" + Session["app_token"].ToString();
                if(txtNoiDungCanThongBao.Text != string.Empty)
                {
                    post_notification += "&template=" + txtNoiDungCanThongBao.Text;
                }
                if (txtLink.Text != string.Empty)
                {
                    if (!Common.CheckRelativeURLValid(txtLink.Text))
                    {
                        ThongBaoLoi("Link thông báo không đúng định dạng");
                        return;
                    }
                    else 
                    { 
                        post_notification += "&href=" + txtLink.Text;
                    }
                }

                //dynamic friendListData = client.Post(post_notification);

                FbAPI fbapi = new FbAPI();
                bool result = fbapi.PostNotification(post_notification);
                if (result)
                {
                    ClearData();
                    ThongBaoThanhCong("Gửi thông báo thành công");
                }
                else
                {
                    ThongBaoLoi("Gửi thông báo không thành công");
                }
            }
            catch (Exception)
            {
                ThongBaoLoi("Gửi thông báo không thành công");
            }
        }

        private void ThongBaoLoi(string message)
        {
            divthongbao.Visible = true;
            txtThongBao.Text = message;
            divthongbao.Attributes["class"] = "alert alert-danger";
        }

        private void ThongBaoThanhCong(string message)
        {
            divthongbao.Visible = true;
            txtThongBao.Text = message;
            divthongbao.Attributes["class"] = "alert alert-success";
        }
        private void ClearData()
        {
            txtLink.Text = "";
            txtNoiDungCanThongBao.Text = "";
        }
    }
}