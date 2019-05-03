using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace project.Models
{
    /// <summary>
    /// Given a jObject, create a practitioner from it
    /// </summary>
    public class PractitionerParser
    {
        private PractitionerBuilder _practitionerBuilder = new PractitionerBuilder();

        /// <summary>
        /// Get values through keys in json and build it
        /// </summary>
        /// <param name="jObject"></param>
        /// <returns></returns>
        public IPractitioner Parse(JObject jObject)
        {
            var addressObject = jObject["address"][0];
            var nameObject = jObject["name"][0];
            _practitionerBuilder.SetId(jObject["id"].ToString())
                .SetGender(jObject["gender"].ToString())
                .SetActive(jObject["active"].ToObject<bool>())
                .SetLastUpdated(DateTime.Parse(jObject["meta"]["lastUpdated"].ToString()))
                .SetAddress(addressObject["line"][0].ToString(), addressObject["city"].ToString(), addressObject["state"].ToString(),
                            addressObject["postalCode"].ToString(), addressObject["country"].ToString())
                .SetName(nameObject["family"].ToString(), nameObject["given"][0].ToString());
            return _practitionerBuilder.Build();
        }

    }

    /// <summary>
    /// Given a jObject, create a patient from it
    /// </summary>
    public class PatientParser
    {
        private PatientBuilder _patientBuilder = new PatientBuilder();

        /// <summary>
        /// Get values through keys in json and build it
        /// </summary>
        /// <param name="jObject"></param>
        /// <returns></returns>
        public IPatient Parse(JObject jObject)
        {
            var addressObject = jObject["address"][0];
            var nameObject = jObject["name"][0];
            var telecomObject = jObject["telecom"][0];
            _patientBuilder.SetId(jObject["id"].ToString());
            _patientBuilder.SetGender(jObject["gender"].ToString());
            _patientBuilder.SetLastUpdated(DateTime.Parse(jObject["meta"]["lastUpdated"].ToString()));
            _patientBuilder.SetAddress(addressObject["line"][0].ToString(), addressObject["city"].ToString(), addressObject["state"].ToString(),
                            addressObject["postalCode"].ToString(), addressObject["country"].ToString());
            _patientBuilder.SetName(nameObject["family"].ToString(), nameObject["given"][0].ToString());
            _patientBuilder.SetTelecom(telecomObject["system"].ToString(), telecomObject["value"].ToString(), telecomObject["use"].ToString());
            _patientBuilder.SetBirthDate(DateTime.Parse(jObject["birthDate"].ToString()));
            return _patientBuilder.Build();
        }
    }

    /// <summary>
    /// Given a jObject, create an observation from it
    /// </summary>
    public class ObservationParser
    {
        private ObservationBuilder _observationBuilder = new ObservationBuilder();

        /// <summary>
        /// Get values through keys in json and build it
        /// </summary>
        /// <param name="jObject"></param>
        /// <returns></returns>
        public Observation Parse(JObject jObject)
        {
            _observationBuilder.SetId(jObject["id"].ToString())
                .SetTotalCholesterol(jObject["valueQuantity"]["value"].ToString())
                .SetEffectiveDateTime(jObject["effectiveDateTime"].ToObject<DateTime>());

            return _observationBuilder.Build();
        }

    }
}
