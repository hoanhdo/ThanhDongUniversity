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

        protected void btnChiaSeHinhAnh_Click(object sender, EventArgs e)
        {
            FbAPI fbapi = new FbAPI();
            bool response = fbapi.PostImage(txtPhotoLink.Text, txtMota.Text, Session["token_extended"].ToString());
            if (response)
            {

            }

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
                var result = client.Post("/me/photos", postparameters);
                if (result != string.Empty)
                {

                }
            }
        }

    }
}