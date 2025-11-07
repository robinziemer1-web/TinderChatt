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
        public static List<string> messageHistory { get; set; }

       async public static Task ConnectToServer()
        {

        var url = "wss://api.leetcode.se";

        //Pathway /sys25d
        var _chatClient = new SocketIO(url, new SocketIOOptions
        {

            Path = Path

        });
       
        //Event name is "message".
        //Response, getting a data from the servern and convert that to string.
        _chatClient.On("message", response =>
        {
           
            var incomingMessage = response.GetValue<string>();

            Console.WriteLine($"You got message: {incomingMessage}");

        });

        _chatClient.OnConnected += (sender, args) =>
            {

                Console.WriteLine("Connected!");
            };

        _chatClient.OnDisconnected += (sender, args) =>
        {

            Console.WriteLine("Disconnected!");
        };
        
        //Connecting to servern.
        await _chatClient.ConnectAsync();

        Console.WriteLine($"Connected {_chatClient.Connected}");

    }

    
    }

