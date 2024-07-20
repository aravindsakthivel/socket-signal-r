// See https://aka.ms/new-console-template for more information
using System.Threading.Tasks;
using Carter;
using Microsoft.AspNetCore.Builder;
using SocketServer.myCarterApp;
using SocketServer.SignalRApp;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // ApiServer.getInstance().Setup(args);
            // var server = ApiServer.getInstance().App;
            //
            // Routes.getInstance().AddRoutes(server);
            
            await SignalServer.getInstance().Start(args);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}