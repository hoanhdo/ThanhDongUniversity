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

        string page_token = "EAABq4gZAin0MBACdUdH4WFLPaqywkSFfjKnwZAv5s2yZBnWh4DakoPutKhgFOjBdFDxUs5z89LUkqWt235TFVUjHZBXuR7ZA5LyfpUy2cje1Vfwdf1DLUWnt4CTvEGS2KtVmTz7JJUlLkvXC1Jh1pCS1qHcoT6FavbWxRYzKaZCKPZAAWWFqsbO";
        public HttpResponseMessage Get()
        {
            var querystrings = Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);
            if (querystrings["hub.verify_token"] == "helloworld")
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(querystrings["hub.challenge"], Encoding.UTF8, "text/plain")
                };
            }
            return new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post()
        {
            try
            {
                //var signature = Request.Headers.GetValues("X-Hub-Signature").FirstOrDefault().Replace("sha1=", "");
                string body = await Request.Content.ReadAsStringAsync();
                dynamic value = JsonConvert.DeserializeObject<WebhookModel>(body);
                if (value._object != "page") {
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                foreach (var item in value.entry[0].messaging)
                {
                    if (item.message == null && item.postback == null)
                        continue;
                    else
                        await SendMessage(GetMessageTemplate(item.message.text, item.sender.id));
                }

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                string fullSavePath = HttpContext.Current.Server.MapPath("~/log_error.txt");
                using (StreamWriter writer = new StreamWriter(fullSavePath, true))
                {
                    writer.WriteLine(ex.ToString());
                    writer.Close();
                }
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
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
