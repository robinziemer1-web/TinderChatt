using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderChatt.Services
{
    public class EventService
    {

        public static List<Message> Events { get; set; } = new();

        public static void StoreEvent(Message ev) 
        {

            Events.Add(ev);
        
        }
    
    }
}
