using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CarBot.Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBot.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private const string BotUrl = "http://localhost:3000";
        private const string BotId = "carbot";
        private HttpClient _httpClient;

        public ChatController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BotUrl);
        }

        [HttpPost("")]
        public async Task<string> PostMessage([FromQuery]string userId, [FromBody]MessageModel message)
        {
            var requestUrl = $"/api/v1/bots/{BotId}/converse/{userId}";
            var postObj = new
            {
                type = "text",
                text = message.Message
            };

            var postObjJson = JsonConvert.SerializeObject(postObj);
            var postContent = new StringContent(postObjJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(requestUrl, postContent);
            var responseJson = await response.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<BotResponseModel>(responseJson);
            var botMessage = responseObj.Responses.FirstOrDefault(r => r.Type == "text")?.Text;

            return $"Bot said: {botMessage}";
        }
    }
}