using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class Observation
    {
        public string PatientId { get; set; }
        public string TotalCholesterol { get; set; } 
        public DateTime EffectiveDateTime { get; set; }
    }
}
