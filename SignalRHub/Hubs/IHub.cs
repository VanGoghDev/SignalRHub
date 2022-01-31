using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHub.Hubs
{
    public interface IHub
    {
        Task SendMessage(string userFrom, string message);
    }
}
