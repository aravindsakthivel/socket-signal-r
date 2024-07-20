using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace SocketServer.myCarterApp;

public class Routes : ICarterModule
{
    public static ICarterModule Instance;
    
    
    public static ICarterModule getInstance()
    {
        if (Instance == null)
        {
            Instance = new Routes();
            return Instance;
        }

        return Instance;
    }
    
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/", () => "Hello from Carter!");
    }
}