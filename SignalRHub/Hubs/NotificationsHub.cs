﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHub.Hubs
{
    public class NotificationsHub : Hub
    {
        public async Task SendMessage(string userFrom, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", userFrom, message);
        }
    }
}
