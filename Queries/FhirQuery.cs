﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using project.Models;


namespace project.Queries
{
    public class PatientQuery
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string HOME_PAGE = "http://hapi-fhir.erc.monash.edu:8080/baseDstu3/";

        //public async Task<Patient> GetPatientAsync(string para)
        //{
        //    if (para == null)
        //    {
        //        para = "";
        //    }

        //    var responseString = await client.GetStringAsync(HOME_PAGE + para);
        //    JObject patient = JObject.Parse(responseString);
        //    return JObject.Parse(responseString);
        //}

        //public async Task<IEnumerable<Patient>> GetPatientsAsync(string para)
        //{
        //    if (para == null)
        //    {
        //        para = "";
        //    }
        //    var responseString = await client.GetStringAsync(HOME_PAGE + para);
        //    return Models.JObject.Parse(responseString);
        //}

    }

    public class PractitionerQuery
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string PRACTITIONER_PAGE = "http://hapi-fhir.erc.monash.edu:8080/baseDstu3/Practitioner";

        public async Task<IPractitioner> GetPractitionerAsync(string para)
        {
            PractitionerParser practitionerParser = new PractitionerParser();
            if (para == null)
            {
                para = "";
            }
            var responseString = await client.GetStringAsync(PRACTITIONER_PAGE + para);
            return practitionerParser.Parse(JObject.Parse(responseString));
        }

        public async Task<IEnumerable<IPractitioner>> GetPractitionersAsync()
        {
            var responseString = await client.GetStringAsync(PRACTITIONER_PAGE);
            var jObject = JObject.Parse(responseString);
            var practitioners = new List<IPractitioner>();
            var array = jObject["entry"].Children<JObject>();
            foreach (var o in array)
            {
                PractitionerParser practitionerParser = new PractitionerParser();
                practitioners.Add(practitionerParser.Parse((JObject) o["resource"]));
            }
            return practitioners;
        }

    }
}
