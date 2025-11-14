using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderChatt.Models
{
     public class SystemMessage : Message
    {
   
       public string EventInfo { get; set; }


        public SystemMessage() : base() 
        {
        

        
        }

        public SystemMessage(string aEventInfo, string aName) : base(aName)
        {

            EventInfo = aEventInfo;
        
        }
    
    }
}
