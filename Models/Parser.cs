using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace project.Models
{
    public class PractitionerParser
    {
        private PractitionerBuilder PractitionerBuilder = new PractitionerBuilder();
        public IPractitioner Parse(JObject jObject)
        {
            var addressObject = jObject["address"][0];
            var nameObject = jObject["name"][0];
            PractitionerBuilder.SetId(jObject["id"].ToString())
                .SetGender(jObject["gender"].ToString())
                .SetActive(jObject["active"].ToObject<bool>())
                .SetLastUpdated(DateTime.Parse(jObject["meta"]["lastUpdated"].ToString()))
                .SetAddress(addressObject["line"][0].ToString(), addressObject["city"].ToString(), addressObject["state"].ToString(),
                            addressObject["postalCode"].ToString(), addressObject["country"].ToString())
                .SetName(nameObject["family"].ToString(), nameObject["given"][0].ToString(), nameObject["prefix"][0].ToString());
            return PractitionerBuilder.Build();
        }
            
    }
}
