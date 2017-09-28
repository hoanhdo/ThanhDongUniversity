using Facebook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacebookAPI.Admin
{
    public partial class ChiaSeVideo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            divthongbao.Visible = false;
            ClearData();
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
            txtMota.Text = "";
            txtTieuDe.Text = "";
        }

        protected void btnChiaSeHinhAnh_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    var filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    var client = new FacebookClient(Session["token_extended"].ToString());
                    var postparameters = new Dictionary<string, object>();
                    var media = new FacebookMediaObject
                    {
                        FileName = filename,
                        ContentType = FileUpload1.PostedFile.ContentType
                    };
                    var path = Path.Combine(Server.MapPath("~/upload_videos"), filename);
                    FileUpload1.PostedFile.SaveAs(path);

                    byte[] video = System.IO.File.ReadAllBytes(path);
                    media.SetValue(video);
                    postparameters["source"] = media;
                    postparameters["access_token"] = Session["token_extended"].ToString();
                    if (txtTieuDe.Text != string.Empty)
                    {
                        postparameters["title"] = txtTieuDe.Text;
                    }

                    if (txtTieuDe.Text != string.Empty)
                    {
                        postparameters["description"] = txtMota.Text;
                    }

                    dynamic result = client.Post("/me/videos", postparameters);
                    if (result != null)
                    {
                        if (result.id != null)
                        {
                            ClearData();
                            ThongBaoThanhCong("Chia sẻ video thành công");
                        }
                    }
                }
                else
                {
                    ThongBaoLoi("Cần chọn video để chia sẻ");
                }
            }
            catch (Exception)
            {
                ThongBaoLoi("Chia sẻ video không thành công");
            }
        }
    }
}