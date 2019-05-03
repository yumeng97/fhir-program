using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using project.Models;


namespace project.Queries
{
    /// <summary>
    /// Request patient data from monash fhir
    /// </summary>
    public class PatientQuery
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string PatientPage = "http://hapi-fhir.erc.monash.edu:8080/baseDstu3/Patient";

        /// <summary>
        /// Get a collection of patient given parameter
        /// </summary>
        /// <param name="para"> a string of content to be filtered </param>
        /// <returns> a collection of patient </returns>
        public async Task<IEnumerable<IPatient>> GetPatientsAsync(string para = "")
        {
            var responseString = await client.GetStringAsync(PatientPage + para);
            var jObject = JObject.Parse(responseString);
            var patients = new List<IPatient>();
            var array = jObject["entry"].Children<JObject>();
            // Parsing the data in each json entry and add them into the patient list
            foreach (var o in array)
            {
                PatientParser patientParser = new PatientParser();
                var toParse = (JObject)o["resource"];
                // Certain practitioner does not have address so only include those have address
                var checkProperty = toParse.ContainsKey("address");
                if (checkProperty)
                {
                    patients.Add(patientParser.Parse(toParse));
                }
            }
            return patients;
        }

    }

    /// <summary>
    /// Request practitioner data from monash fhir
    /// </summary>
    public class PractitionerQuery
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string PRACTITIONER_PAGE = "http://hapi-fhir.erc.monash.edu:8080/baseDstu3/Practitioner";

        /// <summary>
        /// Get a collection of practitioner given parameter
        /// </summary>
        /// <param name="para"> a string of content to be filtered </param>
        /// <returns> a collection of practitioner </returns>
        public async Task<IEnumerable<IPractitioner>> GetPractitionersAsync(string para = "")
        {
            var responseString = await client.GetStringAsync(PRACTITIONER_PAGE + para);
            var jObject = JObject.Parse(responseString);
            var practitioners = new List<IPractitioner>();
            var array = jObject["entry"].Children<JObject>();
            // Parsing the data in each json entry and add them into the practitioner list
            foreach (var o in array)
            {
                PractitionerParser practitionerParser = new PractitionerParser();
                var toParse = (JObject) o["resource"];
                // Certain practitioner does not have address so only include those have address
                var checkProperty = toParse.ContainsKey("address");
                if (checkProperty)
                {
                    practitioners.Add(practitionerParser.Parse(toParse));
                }
            }
            return practitioners;
        }

    }

    /// <summary>
    /// Request observation data from monash fhir
    /// </summary>
    public class ObservationQuery
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string ObservationPage = "http://hapi-fhir.erc.monash.edu:8080/baseDstu3/Observation";


        /// <summary>
        /// Get a collection of observation given parameter
        /// </summary>
        /// <param name="para"> a string of content to be filtered </param>
        /// <returns> a collection of observation </returns>
        public async Task<IEnumerable<Observation>> GetObservationsAsync(string para = "")
        {
            var responseString = await client.GetStringAsync(ObservationPage + para);
            var jObject = JObject.Parse(responseString);
            var observations = new List<Observation>();
            // Some patients may not have observations
            if (jObject.ContainsKey("entry"))
            {
                var array = jObject["entry"].Children<JObject>();
                foreach (var o in array)
                {
                    ObservationParser observationParser = new ObservationParser();
                    var toParse = (JObject)o["resource"];
                    observations.Add(observationParser.Parse(toParse));
                }
            }
            return observations;
        }

    }
}
