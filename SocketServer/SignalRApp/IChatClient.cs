namespace SocketServer.SignalRApp;

public interface IChatClient
{
    Task ReceiveMessage(string message);
    
    Task SendAsync(string method, string user, string message);
}