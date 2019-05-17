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

        public string PatientId { get; set; }
        public string Value { get; set; }
        public ObservationType Type { get; set; }
        public DateTime EffectiveDateTime { get; set; }

        public Observation(string patientId, string value, ObservationType type, DateTime dateTime)
        {
            this.PatientId = patientId;
            this.Value = value;
            this.EffectiveDateTime = dateTime;
            this.Type = type;
        }
    }
}
