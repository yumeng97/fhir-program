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
            ObservationBuilder.SetId(jObject["id"].ToString())
                .SetTotalCholesterol(jObject["valueQuantity"]["value"].ToString())
                .SetEffectiveDateTime(jObject["effectiveDateTime"].ToObject<DateTime>());
                
            return ObservationBuilder.Build();
        }
            
    }
}
