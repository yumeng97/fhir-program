using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace project.Models
{
    public class Practitioner : IPractitioner
    {
        public Practitioner()
        {
            this.MonitoredPatients = new List<string>();
        }
        public string Id { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }
        public List<string> MonitoredPatients { get; set; }
        public DateTime LastUpdated { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public void AddToMonitored(string id)
        {
            if (!MonitoredPatients.Contains(id))
            {
                MonitoredPatients.Add(id);
            }
        }
        public void RemoveFromMonitored(string id)
        {
            if ((MonitoredPatients.Contains(id)))
            {
                MonitoredPatients.Remove(id);
            }
        }
    }
}
