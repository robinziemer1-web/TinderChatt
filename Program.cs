namespace TinderChatt;

using Microsoft.VisualBasic;
using SocketIOClient;
using TinderChatt.Models;

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

        while (true)
        {

            ConsoleUI.DrawInputPrompt();
           
           
            string textMessage = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(textMessage))
                continue;

            if(textMessage.Trim().ToLower() == "/quit") 
            {
                Console.WriteLine($"{userName} has left the chat.");
                await SocketService.DisconnectFromServer(user);
               
                break;
            
            }
            

            var message = new Message(userName)
            {

                Text = textMessage

            };

            

            await SocketService.SendMessage(message);

        }

 }
    }

