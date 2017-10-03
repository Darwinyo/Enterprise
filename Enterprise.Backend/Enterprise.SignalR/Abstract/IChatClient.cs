using Enterprise.API.Models.Hubs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.SignalR.Abstract
{
    public interface IChatClient
    {
        Task SetConnectionId(string connectionId);
        Task Send(ChatModel chatModel);
    }
}
