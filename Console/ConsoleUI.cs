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
   
     public static void ShowEvent(Message ev) 
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

    }
}
