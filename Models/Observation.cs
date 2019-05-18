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
        public string Id { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public DateTime EffectiveDateTime { get; set; }

        public Observation(string id, string value, string type, DateTime dateTime)
        {
            Id = id;
            Value = value;
            EffectiveDateTime = dateTime;
            Type = type;
        }
    }
}
