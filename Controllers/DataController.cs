using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TwitterSentimentSummaryWeb.Controllers
{
    public class DataController : Controller
    {
        public async Task<IActionResult> Tweets(string id)
        {
            var client = new HttpClient();
            var address = ConfigWrapper.Config["ApiRef"];

            var data = new 
            {
                searchString = id,
                numberTweets = 20
            };
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(address, content);
            return Ok(await response.Content.ReadAsStringAsync());
        }

    }
}
