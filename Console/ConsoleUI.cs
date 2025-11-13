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

                Console.WriteLine($"[{ev.TimeStamp:HH:mm}] {sysMsg.EventInfo}");
            
            }
           else 
            {

                Console.WriteLine($"[{ev.TimeStamp:HH:mm}] {ev.Name}: {ev.Text}");
            
            }
        
        }

    }
}
