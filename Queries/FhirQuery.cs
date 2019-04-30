using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using project.Models;


namespace project.WebQuery
{
    public static class PatientQuery
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string HOME_PAGE = "http://hapi-fhir.erc.monash.edu:8080/baseDstu3/";

        //public async Task<Patient> GetPatientAsync(string para)
        //{
        //    if (para == null)
        //    {
        //        para = "";
        //    }
            
        //    var responseString = await client.GetStringAsync(HOME_PAGE + para);
        //    var patient = JObject.Parse(responseString)[]
        //    return JObject.Parse(responseString);
        //}

        //public async Task<IEnumerable<Patient>> GetPatientsAsync(string para)
        //{
        //    if (para == null)
        //    {
        //        para = "";
        //    }

        //    var responseString = await client.GetStringAsync(HOME_PAGE + para);
        //    return JObject.Parse(responseString);
        //}

    }
}
