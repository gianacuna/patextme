using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Keen.Core;

namespace patext.me.App_Interface
{
    public class PublicController : ApiController
    {
        [HttpPost]
        public async void Notify()
        {
            var text = await Request.Content.ReadAsStringAsync();

            var projSettings = new ProjectSettingsProvider("5a402d20c9e77c0001ff1a04", writeKey: "EF4BE1AF9688F1B19D207932A0E6F1726EDA4E0E17F523F23953EE2D2BAEAE0213F1EC16A1D4CD32D5DE570F259FFFDAC0ED5639866329B98FC7B1C63D4B7F8675C56E6437F574E64B40B45120846C8637FADD43F34F2E4B77FB5EC4FDB82DDF");
            var cli = new KeenClient(projSettings);
            cli.AddEvent("Notify", new {
                data = text
            });
        }
    }
}