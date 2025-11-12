using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderChatt.Models
{
    public class Message
    {
    
     public string Name { get; set; }
     public string Text { get; set; } = "";
     public Guid Id { get; set; } = Guid.NewGuid();
     public DateTime TimeStamp { get; set; } = DateTime.Now;

        public Message(string aName) 
        {

            Name = aName;
        
        }

     
    }
}
