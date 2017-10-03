using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Enterprise.SignalR.Abstract;

namespace Enterprise.SignalR.Hubs
{
    public class ChatHub:Hub<IChatClient>
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
