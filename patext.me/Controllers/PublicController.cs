using Keen.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace patext.me.Controllers
{
    public class PublicController : Controller
    {
        // GET: Public
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Landing()
        {
            if (Request.QueryString.HasKeys() && !String.IsNullOrEmpty(Request.QueryString[0]))
            {
                AuthTokenRequest request = new AuthTokenRequest
                {
                    code = Request.QueryString[0]
                };

                HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(request));
                var result = await client.PostAsync("https://developer.globelabs.com.ph/oauth/access_token?app_id=" + request.app_id + "&app_secret=" + request.app_secret + "&code=" + request.code, content);
                var resultContent = await result.Content.ReadAsStringAsync();

                AuthTokenResult response = JsonConvert.DeserializeObject<AuthTokenResult>(resultContent);

                if (response != null)
                {
                    SMSSendRequest sms = new SMSSendRequest
                    {
                        outboundSMSMessageRequest = new SMSSendRequestBody
                        {
                            clientCorrelator = "1",
                            senderAddress = "3667",
                            outboundSMSTextMessage = new SMSMessage
                            {
                                message = "the quick brown fox jumps over the lazy dog. the quick brown fox jumps over the lazy dog. the quick brown fox jumps over the lazy dog. the quick brown fox jump 160 hello this is the second message"
                            },
                            address = "tel:+639155018529"
                        }
                    };

                    //content = new StringContent(JsonConvert.SerializeObject(sms), Encoding.UTF8, "application/json");
                    //result = await client.PostAsync("https://devapi.globelabs.com.ph/smsmessaging/v1/outbound/" + "3667" + "/requests?access_token=" + response.access_token, content);
                    //resultContent = await result.Content.ReadAsStringAsync();

                    var projSettings = new ProjectSettingsProvider("5a402d20c9e77c0001ff1a04", writeKey: "EF4BE1AF9688F1B19D207932A0E6F1726EDA4E0E17F523F23953EE2D2BAEAE0213F1EC16A1D4CD32D5DE570F259FFFDAC0ED5639866329B98FC7B1C63D4B7F8675C56E6437F574E64B40B45120846C8637FADD43F34F2E4B77FB5EC4FDB82DDF");
                    //var cli = new KeenClient(projSettings);

                    //content = new StringContent(JsonConvert.SerializeObject(new {
                    //}), Encoding.UTF8, "application/json");

                    try
                    {
                        var acc_tok = response.access_token;
                        result = await client.GetAsync("https://devapi.globelabs.com.ph/location/v1/queries/location?access_token=" + response.access_token + "&address=09155018529&requestedAccuracy=100");

                        resultContent = await result.Content.ReadAsStringAsync();
                    }
                    catch(Exception ex)
                    {

                    }
                    

                    //cli.AddEvent("Location", new
                    //{
                    //    message = resultContent
                    //});


                    //cli.AddEvent("Outgoing", new
                    //{
                    //    address = sms.outboundSMSMessageRequest.address,
                    //    message = sms.outboundSMSMessageRequest.outboundSMSTextMessage.message
                    //});
                }
            }

            return View();
        }

        public ActionResult Test()
        {
            String test = "";

            try
            {
                if (HttpRuntime.Cache["Tokens"] != null)
                {
                    test = String.Join(",", (HttpRuntime.Cache["Tokens"] as List<String>).ToArray());
                }
            }
            catch(Exception ex)
            {
                test = ex.Message;
            }

            ViewBag.Test = test;

            return View();
        }
    }

    public class AuthTokenRequest
    {
        public String app_id
        {
            get
            {
                return "xRxyU7ReEgCMLiKyXaceqkCGeRbBUzr7";
            }
        }

        public String app_secret
        {
            get
            {
                return "4f97f098736f94b4c622038c5fd351c7b05ec9a674ba00de379347dccc08157b";
            }
        }

        public String code { get; set; }
    }

    public class AuthTokenResult
    {
        public String access_token { get; set; }
        public String subscriber_number { get; set; }
    }

    public class SMSSendRequest
    {
        public SMSSendRequestBody outboundSMSMessageRequest { get; set; }
    }

    public class SMSSendRequestBody
    {
        public String clientCorrelator { get; set; }
        public String senderAddress { get; set; }
        public SMSMessage outboundSMSTextMessage { get; set; }
        public String address { get; set; }
    }

    public class SMSMessage
    {
        public String message { get; set; }
    }

}