using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using EH = Enterprise.API.Helpers;
using Enterprise.SignalR.Interfaces;

namespace Enterprise.SignalR.Hubs
{
    public class ChatHub:Hub<IChatHub>
    {
        public override Task OnConnected()
        {
            return Clients.Client(Context.ConnectionId).SetConnectionId(Context.ConnectionId);
        }
        public Task Subscribe(string groupName)
        {
            return Groups.Add(Context.ConnectionId, groupName);
        }
        public Task Unsubscribe(string groupName)
        {
            return Groups.Remove(Context.ConnectionId, groupName);
        }
    }
}
