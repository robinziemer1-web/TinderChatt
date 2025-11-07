namespace TinderChatt;
using SocketIOClient;
  

  public class Program
    {

    private static SocketIO _chatClient;



    static void Main(string[] args)
        {


        var chat = new SocketService();

        SocketService.ConnectToServer();


        }
    }

