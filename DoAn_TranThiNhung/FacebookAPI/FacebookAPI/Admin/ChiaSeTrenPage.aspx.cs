using Facebook;
using FacebookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacebookAPI.Admin
{
    public partial class ChiaSeTrenPage : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            divthongbao.Visible = false;
            ClearData();

            FacebookClient client = new FacebookClient(Session["token_extended"].ToString());//tạo object facebook client
            var friendListData = client.Get("/" + Session["user_id"] + "/accounts"); //gọi facebook api lấy thông tin bạn bè tag được
            JavaScriptSerializer sr = new JavaScriptSerializer();
            FacebookClass.ResultAccounts serializedJson = sr.Deserialize<FacebookClass.ResultAccounts>(friendListData.ToString());
            List<FacebookClass.AccountAdmin> all_account = new List<FacebookClass.AccountAdmin>();
            if (serializedJson.data.Count > 0)
            {
                all_account = serializedJson.data;
            }
            cblAccounts.DataSource = all_account;
            cblAccounts.DataTextField = "name";
            cblAccounts.DataValueField = "id";
            cblAccounts.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

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
            txtNoiDungCanChiaSe.Text = "";
            txtThongBao.Text = "";
            txtLinkChiaSe.Text = "";
        }

        protected void btnChiaSeBaiViet_Click(object sender, EventArgs e)
        {
            string message = "";
            for (int i = 0; i < cblAccounts.Items.Count; i++)
            {
                
                if (cblAccounts.Items[i].Selected)
                {
                    string page_id = cblAccounts.Items[i].Value;

                    FacebookClient clientGet = new FacebookClient(Session["token_extended"].ToString());//tạo object facebook client
                    dynamic resultGetToken = clientGet.Get(page_id + "?fields=access_token"); //gọi facebook api lấy thông tin bạn bè tag được
                    if (resultGetToken.access_token != null)
                    {
                        FacebookClient client = new FacebookClient(resultGetToken.access_token);//tạo object facebook client
                        var postparameters = new Dictionary<string, object>();
                        if (txtNoiDungCanChiaSe.Text != string.Empty)
                        {
                            postparameters["message"] = txtNoiDungCanChiaSe.Text;
                        }
                        if (txtLinkChiaSe.Text != string.Empty)
                        {
                            postparameters["link"] = txtLinkChiaSe.Text;
                        }
                        postparameters["published"] = "true";
                        try
                        {
                            dynamic result = client.Post("/" + cblAccounts.Items[i].Value + "/feed", postparameters);
                            if (result.id != null)
                            {
                                message += "Chia sẻ lên page " + cblAccounts.Items[i].Text + "thành công</br>";
                            }
                            else
                            {
                                message += "Chia sẻ lên page " + cblAccounts.Items[i].Text + "không thành công</br>";
                            }
                        }
                        catch (Exception)
                        {
                            message += "Chia sẻ lên page " + cblAccounts.Items[i].Text + "không thành công</br>";
                        }
                    }
                }
            }
            ClearData();
            ThongBaoThanhCong(message);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
        }
    }
}