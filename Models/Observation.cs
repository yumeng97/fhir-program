using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class Observation
    {
        public enum ObservationType
        {
            Cholesterol, BloodPressure, Tobacco, DiastolicBloodPressure, SystolicBloodPressure
        }

        public static readonly string CHOLESTEROL = "Cholesterol";
        public static readonly string SYSTOLIC = "Systolic Blood Pressure";
        public static readonly string DIASTOLIC = "Diastolic Blood Pressure";
        public static readonly string TOBACCO = "Tobacco";
        public static readonly string BLOOD_PRESSURE = "Blood Pressure";

        public string Id { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public DateTime EffectiveDateTime { get; set; }

        public static string GetTypeByCode(string c)
        {
            if (c == "0")
            {
                return CHOLESTEROL;
            }
            else if (c == "1")
            {
                return TOBACCO;
            }
            else if (c == "2")
            {
                return DIASTOLIC;
            }
            else
            {
                return SYSTOLIC;
            }
        }

        public Observation(string id, string value, string type, DateTime dateTime)
        {
            Id = id;
            Value = value;
            EffectiveDateTime = dateTime;
            Type = type;
        }
    }
}
