using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRHub.Hubs
{
    public class NotificationsHub : Hub, IHub
    {
        public async Task SendMessage(string userFrom, string message)
        {
            //await Clients.All.SendAsync("ReceiveMessage", userFrom, message);
            await Clients.Group("'bob@mail.com'").SendAsync("ReceiveMessage", userFrom, message);
        }

        public override Task OnConnectedAsync()
        {
            var username = Context.GetHttpContext().Request.Query["username"];
            if (!string.IsNullOrEmpty(username))
                Groups.AddToGroupAsync(Context.ConnectionId, username);
            UserHandler.ConnectedIds.Add(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }

    public static class UserHandler
    {
        public static HashSet<string> ConnectedIds = new HashSet<string>();
    }

}
