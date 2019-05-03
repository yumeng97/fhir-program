using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace project.Models
{
    public class ObservationParser
    {
        private ObservationBuilder ObservationBuilder = new ObservationBuilder();
        public Observation Parse(JObject jObject)
        {
            var addressObject = jObject["address"][0];
            var nameObject = jObject["name"][0];
            ObservationBuilder.SetId(jObject["id"].ToString())
                .SetTotalCholesterol(jObject["cholesterol"].ToString());
                
            return ObservationBuilder.Build();
        }
            
    }
}
