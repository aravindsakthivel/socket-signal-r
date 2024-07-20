using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace SocketServer.myCarterApp;


public class ApiServer
{
    public static ApiServer Instance;
    public WebApplication App {get; private set; }

    public static ApiServer getInstance()
    {
        if (Instance == null)
        {
            Instance = new ApiServer();
            return Instance;
        }

        return Instance;
    }
    
    public void Setup(string[] args)
    {
        var port = 9000; // Replace with your desired port number

        var builder = WebApplication.CreateBuilder(args);
        
        
        builder.Services.AddCarter();

        App = builder.Build();

        App.MapCarter();
        
        App.Run("http://localhost:" + port);
    }
    
}