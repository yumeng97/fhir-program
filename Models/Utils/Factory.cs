using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models.Utils
{
    public class ObservationFactory
    {
        public static readonly string CHOLESTEROL = "Cholesterol";
        public static readonly string SYSTOLIC = "Systolic Blood Pressure";
        public static readonly string DIASTOLIC = "Diastolic Blood Pressure";
        public static readonly string TOBACCO = "Tobacco";
        public Observation[] CreateBloodPressure(string id, string[] values, DateTime dateTime)
        {
            Observation diastolic = new Observation(id, values[0], DIASTOLIC, dateTime);
            Observation systolic = new Observation(id, values[1], SYSTOLIC, dateTime);
            Observation[] bloodPressure = new Observation[] { diastolic, systolic };
            return bloodPressure;
        }

        public Observation CreateCholesterol(string id, string value, DateTime dateTime)
        {
           return new Observation(id, value, CHOLESTEROL, dateTime);
        }

        public Observation CreateTobacco(string id, string value, DateTime dateTime)
        {
            return new Observation(id, value, TOBACCO, dateTime);
        }
    }
}
