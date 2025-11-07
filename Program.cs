namespace TinderChatt;
using SocketIOClient;
  

  public class Program
    {

    



    async static Task Main(string[] args)
        {


        var chat = new SocketService();

        await SocketService.ConnectToServer();




        }
    }

