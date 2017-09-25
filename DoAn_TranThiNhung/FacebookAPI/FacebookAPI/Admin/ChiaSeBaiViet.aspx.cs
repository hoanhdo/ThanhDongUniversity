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

        protected void Page_Init(object sender, EventArgs e)
        {
            divthongbao.Visible = false;
            ClearData();
        }

        protected void btnChiaSeBaiViet_Click(object sender, EventArgs e)
        {
            FbAPI fbapi = new FbAPI();//tạo object facebook api

            //kiểm tra link chia sẻ có đúng định dạng không
            if (txtLinkChiaSe.Text != string.Empty)
            {
                if(!Common.CheckURLValid(txtLinkChiaSe.Text)) 
                {
                    ThongBaoLoi("Link chia sẻ không đúng định dạng");
                    return;
                }
            }

            //kiểm tra ảnh chia sẻ có đúng định dạng không
            if (txtAnhChiaSe.Text != string.Empty)
            {
                if (!Common.CheckURLValid(txtAnhChiaSe.Text))
                {
                    ThongBaoLoi("Link ảnh chia sẻ không đúng định dạng");
                    return;
                }
            }
            
            //Chia sẻ bài viết
            bool response = fbapi.PostMessage(txtNoiDungCanChiaSe.Text, txtLinkChiaSe.Text, txtAnhChiaSe.Text, Session["token_extended"].ToString());
            if(response)
            {
                ThongBaoThanhCong("Chia sẻ thành công");
            }
            else
            {
                ThongBaoLoi("Chia sẻ không thành công");
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
            txtAnhChiaSe.Text = "";
            txtLinkChiaSe.Text = "";
            txtNoiDungCanChiaSe.Text = "";
        }
    }
}