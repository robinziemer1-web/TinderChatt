using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace TinderChatt
{
    public class Message
    {
        [JsonPropertyName("name")]
     public string Name { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; } = "";
        [JsonPropertyName("timestamp")]
        public DateTime TimeStamp { get; set; } = DateTime.Now;
      
        

        
        public Message() { } //Parameterless constructor for JSON deserialization in SocketService.

        public Message(string aName) 
        {

            Name = aName;
        
        }

     
    }
}
