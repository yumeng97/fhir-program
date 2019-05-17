using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models.Utils
{
    public class ObservationFactory
    {
        public static readonly string CHOLESTEROL = "2093-3";
        public static readonly string SYSTOLIC = "8480-6";
        public static readonly string DIASTOLIC = "8462-4";
        public static readonly string TOBACCO = "72166-2";
        public Observation[] CreateBloodPressure(string patientId, string[] values, DateTime dateTime)
        {
            Observation diastolic = new Observation(patientId, values[0], Observation.ObservationType.DiastolicBloodPressure, dateTime);
            Observation systolic = new Observation(patientId, values[1], Observation.ObservationType.SystolicBloodPressure, dateTime);
            Observation[] bloodPressure = new Observation[] { diastolic, systolic };
            return bloodPressure;
        }

        public Observation CreateCholesterol(string patientId, string value, DateTime dateTime)
        {
           return new Observation(patientId, value, Observation.ObservationType.Cholesterol, dateTime);
        }

        public Observation CreateTobacco(string patientId, string value, DateTime dateTime)
        {
            return new Observation(patientId, value, Observation.ObservationType.Tobacco, dateTime);
        }
    }
}
