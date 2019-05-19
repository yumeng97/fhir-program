using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models.Utils
{
    public class ObservationFactory
    {
        private string diastolicSubId = "/1";
        private string systolicSubId = "/2";
        public Observation[] CreateBloodPressure(string id, string[] values, DateTime dateTime)
        {
            Observation diastolic = new Observation(id + diastolicSubId, values[0], Observation.DIASTOLIC, dateTime);
            Observation systolic = new Observation(id + systolicSubId, values[1], Observation.SYSTOLIC, dateTime);
            Observation[] bloodPressure = new Observation[] { diastolic, systolic };
            return bloodPressure;
        }

        public Observation CreateCholesterol(string id, string value, DateTime dateTime)
        {
           return new Observation(id, value, Observation.CHOLESTEROL, dateTime);
        }

        public Observation CreateTobacco(string id, string value, DateTime dateTime)
        {
            return new Observation(id, value, Observation.TOBACCO, dateTime);
        }
    }
}
