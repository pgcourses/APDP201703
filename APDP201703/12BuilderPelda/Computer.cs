using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace _12BuilderPelda
{
    public class Computer
    {
        public Computer()
        {
            //null object pattern
            Applications = new List<string>();
        }

        public List<string> Applications { get; set; }
        public bool HasDVD { get; set; }
        public bool HasSoundCard { get; set; }
        public bool HasUSB { get; set; }
        public int HDD { get; set; }
        
        //nem az int értékét hanem az enum nevét kérjük a szövegbe
        [JsonConverter(typeof(StringEnumConverter))]  
        public OS OS { get; set; }

        //nem az int értékét hanem az enum nevét kérjük a szövegbe
        [JsonConverter(typeof(StringEnumConverter))]
        public Processor Processor { get; set; }

        public void Display()
        {
            Console.WriteLine(JsonConvert.SerializeObject(this, Formatting.Indented)); //formázva kérjük a szöveget
        }
    }
}