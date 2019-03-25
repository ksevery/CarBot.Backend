using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBot.Backend.Models
{
    public class BotResponseModel
    {
        public BotResponseModel()
        {
            Responses = new List<BotResponse>();
        }

        public IEnumerable<BotResponse> Responses { get; set; }
    }
}
