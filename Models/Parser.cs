using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace project.Models
{
    public class PractitionerParser
    {
        private PractitionerBuilder practitionerBuilder = new PractitionerBuilder();
        public IPractitioner Parse(JObject jObject)
        {
            var addressObject = jObject["address"][0];
            var nameObject = jObject["name"][0];
            practitionerBuilder.SetId(jObject["id"].ToString())
                .SetGender(jObject["gender"].ToString())
                .SetActive(jObject["active"].ToObject<bool>())
                .SetLastUpdated(DateTime.Parse(jObject["meta"]["lastUpdated"].ToString()))
                .SetAddress(addressObject["line"][0].ToString(), addressObject["city"].ToString(), addressObject["state"].ToString(),
                            addressObject["postalCode"].ToString(), addressObject["country"].ToString())
                .SetName(nameObject["family"].ToString(), nameObject["given"][0].ToString());
            return practitionerBuilder.Build();
        }

    }

    public class PatientParser
    {
        private PatientBuilder patientBuilder = new PatientBuilder();
        public IPatient Parse(JObject jObject)
        {
            var addressObject = jObject["address"][0];
            var nameObject = jObject["name"][0];
            var telecomObject = jObject["telecom"][0];
            patientBuilder.SetId(jObject["id"].ToString());
            patientBuilder.SetGender(jObject["gender"].ToString());
            patientBuilder.SetLastUpdated(DateTime.Parse(jObject["meta"]["lastUpdated"].ToString()));
            patientBuilder.SetAddress(addressObject["line"][0].ToString(), addressObject["city"].ToString(), addressObject["state"].ToString(),
                            addressObject["postalCode"].ToString(), addressObject["country"].ToString());
            patientBuilder.SetName(nameObject["family"].ToString(), nameObject["given"][0].ToString());
            patientBuilder.SetTelecom(telecomObject["system"].ToString(), telecomObject["value"].ToString(), telecomObject["use"].ToString());
            patientBuilder.SetBirthDate(DateTime.Parse(jObject["birthDate"].ToString()));
            return patientBuilder.Build();
        }
    }
}
