using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.API.Models.Hubs
{
    public class ChatModel
    {
        public string userId { get; set; }
        public string message { get; set; }
        public DateTime messageDatetime { get; set; }
        public string groupId { get; set; }
    }
}
