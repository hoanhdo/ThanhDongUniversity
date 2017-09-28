using FacebookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook;
using System.IO;

namespace FacebookAPI.Admin
{
    public partial class ChiaSeHinhAnh : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            divthongbao.Visible = false;
            ClearData();
        }
        protected void btnChiaSeHinhAnh_Click(object sender, EventArgs e)
        {
            FbAPI fbapi = new FbAPI();
            if (txtPhotoLink.Text != string.Empty)
            {
                if (!Common.CheckURLValid(txtPhotoLink.Text))
                {
                    ThongBaoLoi("Link chia sẻ không đúng định dạng");
                    return;
                }
                else
                {
                    bool response = fbapi.PostImage(txtPhotoLink.Text, txtMota.Text, Session["token_extended"].ToString());
                    if (response)
                    {
                        ThongBaoThanhCong("Chia sẻ hình ảnh thành công");
                    }
                    else
                    {
                        ThongBaoLoi("Chia sẻ hình ảnh không thành công");
                    }
                }
            }
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
                        ContentType = "image/jpeg"
                    };
                    var path = Path.Combine(Server.MapPath("~/upload_photos"), filename);
                    FileUpload1.PostedFile.SaveAs(path);

                    byte[] img = System.IO.File.ReadAllBytes(path);
                    media.SetValue(img);
                    postparameters["source"] = media;
                    postparameters["access_token"] = Session["token_extended"].ToString();
                    dynamic result = client.Post("/me/photos", postparameters);
                    if (result != null)
                    {
                        if (result.id != null && result.post_id != null)
                        {
                            ClearData();
                            ThongBaoThanhCong("Chia sẻ hình ảnh thành công");
                        }
                    }
                }
            }
            catch (Exception)
            {
                ThongBaoLoi("Chia sẻ hình ảnh không thành công");
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
            txtMota.Text = "";
            txtPhotoLink.Text = "";
        }
    }
}