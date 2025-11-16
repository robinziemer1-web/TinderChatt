namespace TinderChatt;

using Microsoft.VisualBasic;
using SocketIOClient;
using TinderChatt.Models;
using TinderChatt.Services;

public class Program
    {

    async static Task Main(string[] args)
        {

        var userName = "";
        Console.WriteLine("Welcome to the TinderChatt Program!");

        while (true)
        {
            
            Console.Write("Write your username here: ");
            userName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userName))
            {

                Console.WriteLine("Error! You cant type empty name.");

            }

            else break;

        }
        Message user = new Message(userName);

        
        await SocketService.ConnectToServer(user);
        ConsoleUI.DrawInputPrompt();


        while (true)
        {
            ConsoleUI.DrawInputPrompt();
            string textMessage = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(textMessage))
                continue;

          
            if (textMessage.Equals("/quit", StringComparison.OrdinalIgnoreCase))
            {
                await SocketService.DisconnectFromServer(user);
                Environment.Exit(0);
            }
         

            var message = new Message(user.Name)
            {
                Text = textMessage
            };

            await SocketService.SendMessage(message);
        }

    }
    }

