using Microsoft.AspNetCore.SignalR;

namespace SocketServer.SignalRApp;

public class ChatHub : Hub<IChatClient>
{
    public override async Task OnConnectedAsync()
    {
        Console.WriteLine("Connected: " + Context.ConnectionId);
        if (true)
        {
            Context.Abort();
        }
        Console.WriteLine("Connected: " + Context.ConnectionId);
        await Clients.All.ReceiveMessage($"{Context.ConnectionId} has joined");
    }
    
    public async Task SendMessage(string user, string message)
    {
        Console.WriteLine("Message received: " + message);
        var cId = Context.ConnectionId;
        await Clients.All.ReceiveMessage($"{Context.ConnectionId}: {message}");
        await Clients.Clients(cId).ReceiveMessage("message-dummy");
    }
    
    public override async Task OnDisconnectedAsync(Exception exception)
    {
        await Clients.All.ReceiveMessage($"{Context.ConnectionId} has left");
    }
    
    public async Task SendPrivateMessage(string user, string message)
    {
        await Clients.User(user).ReceiveMessage($"{Context.ConnectionId}: {message}");
    }
    
    public async Task ReceiveMessage(string message)
    {
        await Clients.All.ReceiveMessage(message);
    }
}