using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TinderChatt.Services
{
    public class EventService
    {

        public static List<Message> Events { get; set; } = new();

        private static readonly string HistoricFile = "chat_history.json";

        public static void savingMessages() 
        {

            var json = JsonSerializer.Serialize(Events, new JsonSerializerOptions
            {

                WriteIndented = true

            });

            File.WriteAllText(HistoricFile, json);

        
        }

        public static void loadingMessages() 
        {


                var json = File.ReadAllText(HistoricFile);

                var loaded = JsonSerializer.Deserialize<List<Message>>(json);

           




             }
         

        public static void StoreEvent(Message ev) 
        {

            Events.Add(ev);
        
        }
    
    }
}
