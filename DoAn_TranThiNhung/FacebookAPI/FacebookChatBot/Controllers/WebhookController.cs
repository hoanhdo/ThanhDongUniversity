using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FacebookChatBot.Models;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.IO;
using System.Web;

namespace FacebookChatBot.Controllers
{
    public class WebhookController : ApiController
    {

        //public IEnumerable<Webhook> GetAllProducts()
        //{
        //    return "helloworld";
        //}

        // page token trong facebook app
        string page_token = "EAABq4gZAin0MBACdUdH4WFLPaqywkSFfjKnwZAv5s2yZBnWh4DakoPutKhgFOjBdFDxUs5z89LUkqWt235TFVUjHZBXuR7ZA5LyfpUy2cje1Vfwdf1DLUWnt4CTvEGS2KtVmTz7JJUlLkvXC1Jh1pCS1qHcoT6FavbWxRYzKaZCKPZAAWWFqsbO";
        public HttpResponseMessage Get() //hàm nhận GET request từ facebook app
        {
            // lấy ra từ điển các querystring và giá trị của nó
            var querystrings = Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);
            if (querystrings["hub.verify_token"] == "helloworld")// kiểm tra nêu đúng verify_token cấu hình trong facebook app
            {
                return new HttpResponseMessage(HttpStatusCode.OK)// trả lại HttpResponseMessage có mã code là 200
                {
                    Content = new StringContent(querystrings["hub.challenge"], Encoding.UTF8, "text/plain")
                };
            }
            return new HttpResponseMessage(HttpStatusCode.Unauthorized);//trả lại HttpResponseMessage có mã code là 401 không đúng xác thực
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post()//
        {
            try
            {
                //var signature = Request.Headers.GetValues("X-Hub-Signature").FirstOrDefault().Replace("sha1=", "");
                string body = await Request.Content.ReadAsStringAsync();// đọc ra nội dung  của request
                dynamic value = JsonConvert.DeserializeObject<WebhookModel>(body); //chuyển đổi từ json sang thành object WebhookModel
                if (value._object != "page") {// kiểm tra xem có phải query đúng định dạng webhook k
                    return new HttpResponseMessage(HttpStatusCode.OK);// nếu không đúng trả về http code là 200
                }
                foreach (var item in value.entry[0].messaging)// duyệt từng phần tử trong value
                {
                    if (item.message == null && item.postback == null)// nếu k có message và k có phản hồi
                        continue;// thì tiếp tục chạy vòng lặp
                    else
                        await SendMessage(GetMessageTemplate(item.message.text, item.sender.id));// Gửi trả lại message
                }

                return new HttpResponseMessage(HttpStatusCode.OK);//trả về status code 200
            }
            catch (Exception ex)
            {
                string fullSavePath = HttpContext.Current.Server.MapPath("~/log_error.txt");// lấy ra đường dẫn log file
                using (StreamWriter writer = new StreamWriter(fullSavePath, true))
                {
                    writer.WriteLine(ex.ToString());//ghi exception xuống file 
                    writer.Close();
                }
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);// trả về lỗi internal server
            }
        }

        /// <summary>
        /// get text message template
        /// </summary>
        /// <param name="text">text</param>
        /// <param name="sender">sender id</param>
        /// <returns>json</returns>
        private JObject GetMessageTemplate(string text, string sender)
        {
            return JObject.FromObject(new
            {
                recipient = new { id = sender },
                message = new { text = text }
            });
        }

        private JObject CreateTestResponse(string body, string convert)
        {
            return JObject.FromObject(new
            {
                request_body = new { body_string = body },
                convert = new { convert_string = convert }
            });
        }

        /// <summary>
		/// send message
		/// </summary>
		/// <param name="json">json</param>
		private async Task SendMessage(JObject json)
		{
			using (HttpClient client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage res = await client.PostAsync("https://graph.facebook.com/v2.10/me/messages?access_token=" + page_token, new StringContent(json.ToString(), Encoding.UTF8, "application/json"));
			}
}
    }
}
