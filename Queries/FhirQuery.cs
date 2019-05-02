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
        private readonly string PATIENT_PAGE = "http://hapi-fhir.erc.monash.edu:8080/baseDstu3/Patient";

        public async Task<IEnumerable<IPatient>> GetPatientsAsync(string para = "")
        {
            var responseString = await client.GetStringAsync(PATIENT_PAGE + para);
            var jObject = JObject.Parse(responseString);
            var patients = new List<IPatient>();
            var array = jObject["entry"].Children<JObject>();
            foreach (var o in array)
            {
                PatientParser patientParser = new PatientParser();
                var toParse = (JObject)o["resource"];
                patients.Add(patientParser.Parse(toParse));
            }
            return patients;
        }

    }

    public class PractitionerQuery
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string PRACTITIONER_PAGE = "http://hapi-fhir.erc.monash.edu:8080/baseDstu3/Practitioner";

        public async Task<IEnumerable<IPractitioner>> GetPractitionersAsync(string para = "")
        {
            var responseString = await client.GetStringAsync(PRACTITIONER_PAGE + para);
            var jObject = JObject.Parse(responseString);
            var practitioners = new List<IPractitioner>();
            var array = jObject["entry"].Children<JObject>();
            foreach (var o in array)
            {
                PractitionerParser practitionerParser = new PractitionerParser();
                var toParse = (JObject) o["resource"];
                var checkProperty = toParse.ContainsKey("address");
                if (checkProperty)
                {
                    practitioners.Add(practitionerParser.Parse(toParse));
                }
            }
            return practitioners;
        }

    }

    public class DiagnosticReportQuery
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string REPORT_PAGE = "http://hapi-fhir.erc.monash.edu:8080/baseDstu3/DiagnosticReport";

        //just going to try and see if i am able to get a response from server

    }
}
