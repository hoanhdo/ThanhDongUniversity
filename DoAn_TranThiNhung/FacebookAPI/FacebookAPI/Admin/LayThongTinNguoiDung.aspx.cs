using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook;
using System.Web.Script.Serialization;
using FacebookAPI.Models;

namespace FacebookAPI.Admin
{
    public partial class LayThongTinNguoiDung : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    FacebookClient client = new FacebookClient(Session["token_extended"].ToString());
                    var friendListData = client.Get("/me/taggable_friends");
                    JavaScriptSerializer sr = new JavaScriptSerializer();
                    FacebookClass.Taggable_Friends serializedJson = sr.Deserialize<FacebookClass.Taggable_Friends>(friendListData.ToString());
                    if (serializedJson.data != null)
                    {
                        FacebookClass.User_Info[] user_infos = serializedJson.data;
                        FacebookClass.User_Info_Display[] list_user_display = new FacebookClass.User_Info_Display[user_infos.Length];
                        for (int i = 0; i < user_infos.Length; i++)
                        {
                            FacebookClass.User_Info user_info = user_infos[i];
                            FacebookClass.User_Info_Display user_display = new FacebookClass.User_Info_Display();
                            user_display.num = i + 1;
                            user_display.name = user_info.name;
                            user_display.picture_link = user_info.picture.data.url;
                            list_user_display[i] = user_display;
                        }
                        ListView1.DataSource = list_user_display;
                        ListView1.DataBind();
                    }
                }
                catch (Exception)
                {
                    ListView1.DataSource = new FacebookClass.User_Info_Display[0];
                    ListView1.DataBind();
                }
            }
        }
    }
}