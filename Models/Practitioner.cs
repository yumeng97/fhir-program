using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace project.Models
{
    public class Practitioner : IPractitioner
    {
        public string Id { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }
        public List<string> MonitoredPatients { get; set; }
        public DateTime LastUpdated { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
    }
}
