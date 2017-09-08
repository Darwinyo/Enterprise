using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.SignalR.Interfaces
{
    public interface IChatHub
    {
        Task SetConnectionId(string connectionId);
        Task Send(string message);
    }
}
