namespace TinderChatt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketIOClient;


    public class SocketService
    {

        private static SocketIO _chatClient;
        private static readonly string Path = "/sys25d";

    //Stores all the received chat messages during the session.
    public static List<string> messageHistory { get; set; } = new();

       async public static Task ConnectToServer()
        {

        var url = "wss://api.leetcode.se";

        //Initializing Socket.IO client and connecting to server.
         _chatClient = new SocketIO(url, new SocketIOOptions
        {

            Path = Path

        });



       //Listening on incoming messange from the event "message".
        _chatClient.On("message", response =>
        {
            var incomingMessage = response.GetValue<string>();

            Console.WriteLine($"You got message: {incomingMessage}");
       
        });



        _chatClient.OnConnected += (sender, args) =>
            {

                Console.WriteLine("Connecting...");
            };

        _chatClient.OnDisconnected += (sender, args) =>
        {

            Console.WriteLine("Disconnected!");
        };
        
        //await for the server connection to complete before continue.
        await _chatClient.ConnectAsync();

        Console.WriteLine($"Connected {_chatClient.Connected}!");

    }

    
    }

