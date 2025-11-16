using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinderChatt.Models;

namespace TinderChatt
{
    public class ConsoleUI
    {
   
     public static void ShowEvent(Message ev)  //Prints a chat message or a system message.
        {

           if(ev is SystemMessage sysMsg) 
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                char lineChar = '\u2500';

                string line = new string(lineChar, 40);
                Console.WriteLine(line);
                
                Console.WriteLine($"[{ev.TimeStamp:HH:mm}] {sysMsg.EventInfo}");
                Console.WriteLine(line);

                Console.ResetColor();
            }
           else 
            {

                Console.WriteLine($"[{ev.TimeStamp:HH:mm}] {ev.Name}: {ev.Text}");
            
            }
        
        }

        

    


           //Make input prompt on the bottom of the console window.
        public static void DrawInputPrompt(string inputPrompt = "Write your message: ")
        {
            int bottom = Console.WindowHeight - 1;

            
            char lineChar = '\u2500';

            string line = new string(lineChar, 40);

            Console.SetCursorPosition(0, bottom);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, bottom);


            Console.WriteLine(line);
            Console.Write(inputPrompt);
            
        }

        

        public static void ReplaceInputWithMessage(Message msg) //Replaces the users input line with formatted chat message.
        {
           
            int line = Console.CursorTop - 1;
            if (line < 0) line = 0;

           
            ClearLine(line);
            ShowEvent(msg);
        }
          
        public static void ClearLine(int line)  //Overwriting console line with spaces.
        {
            
            Console.SetCursorPosition(0, line);

            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, line);
            
        }           
        public static void ClearInputLine() => ClearLine(Console.WindowHeight - 1); //Clears the bottom input line.

    }
}
