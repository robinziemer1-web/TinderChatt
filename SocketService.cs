namespace TinderChatt;

using Microsoft.VisualBasic;
using SocketIOClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TinderChatt;
using TinderChatt.Models;

public class SocketService
    {

        private static SocketIO _chatClient;
        private static readonly string Path = "/sys25d";

    //Stores all the received chat messages during the session.
    public static List<string> messageHistory { get; set; } = new();







    async public static Task ConnectToServer(Message user)
    {

        var url = "wss://api.leetcode.se";


        _chatClient = new SocketIO(url, new SocketIOOptions
        {

            Path = Path

        });


     

        _chatClient.On("komapojkenMsg", response =>
        {

            Message incomingMessage = new Message();

            try
            {
               incomingMessage = response.GetValue<Message>();
                ConsoleUI.ShowEvent(incomingMessage);

             
            
            } catch 
            {

                Console.WriteLine("Error! Could not deserialize a incoming message.");
            
            }

            if (incomingMessage == null || incomingMessage.Name == null || incomingMessage.Text == null)
            {

                Console.WriteLine("Error! Invalid Message was received, with another datatype.");
                return;

            }

        });




        _chatClient.OnConnected += async (sender, args) =>
        {

            Console.WriteLine($" {user.Name} Connecting...!");

            var sysMsg = new SystemMessage
            {
                Name = "System",
                EventInfo = $"{user.Name} has joined the chat",
                TimeStamp = DateTime.Now
            };

            ConsoleUI.ShowEvent(sysMsg);

            await _chatClient.EmitAsync("message", new
            {
                name = user.Name,
                text = $"{user.Name} joined the chat",
                timeStamp = DateTime.Now
            });

        };


        _chatClient.OnDisconnected += (sender, args) =>
        {

            Console.WriteLine("Disconnected!");
        };

        //await for the server connection to complete before continue.

        await _chatClient.ConnectAsync();

        await Task.Delay(2000);


        Console.WriteLine($"Connected {_chatClient.Connected}!");

      

       
        
    }
    public static async Task SendMessage(Message msg)
    {
        if (_chatClient == null || !_chatClient.Connected)
        {
            Console.WriteLine("You are not connected to server, please try again");
            return;
        }

        await _chatClient.EmitAsync("message", new
        {
            name = msg.Name,
            text = msg.Text,
            timeStamp = msg.TimeStamp
        });

       
        ConsoleUI.ShowEvent(msg);
    }


}

