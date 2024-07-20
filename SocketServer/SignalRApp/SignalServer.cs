using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SocketServer.SignalRApp;

public class SignalServer
{
    public static SignalServer instance;
    
    private WebApplication App {get; set; }
    
    public static SignalServer getInstance()
    {
        if (instance == null)
        {
            instance = new SignalServer();
            return instance;
        }

        return instance;
    }
    
    public async Task Start(string[] args)
    {
        Console.WriteLine("Starting SignalR Server ");
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddSignalR();

        App = builder.Build();
        
        // App.MapPost("broadcast", async (string message, IHubContext<ChatHub, IChatClient> context) =>
        // {
        //     await context.Clients.All.ReceiveMessage($"Msg received in SignalR {message}");
        //     
        //     Console.WriteLine("Message received: " + message);
        //
        //     return Results.NoContent();
        // });
        // App.UseHttpsRedirection();

        App.MapHub<ChatHub>("/chatHub");

        App.MapGet("/", () => "Hello, World!");

        App.MapGet("/greet/{name}", (string name) => $"Hello, {name}!");
        
        Console.WriteLine("SignalR Server started");

        await App.RunAsync();
        
        Console.WriteLine("SignalR Server started 2");

    }
}