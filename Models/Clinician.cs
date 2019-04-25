using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace project.Models
{
    public class Clinician : IClinician
    {
        public string id { get; set; }
        public DateTime lastUpdated { get; set; }
        public bool active { get; set; }
        public string gender { get; set; }
        public List<string> monitoredPatients { get; set; }
        public struct Name
        {
            public string family { get; set; }
            public string given { get; set; }
            public string prefix { get; set; }

            public Name(string familyName, string givenName, string prefix)
            {
                this.family = familyName;
                this.given = givenName;
                this.prefix = prefix;
            }
        }
        public struct Address
        {
            public string line { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string postalCode { get; set; }
            public string country { get; set; }

            public Address(string line, string city, string state, string postalCode, string country)
            {
                this.line = line;
                this.city = city;
                this.state = state;
                this.postalCode = postalCode;
                this.country = country;
            }
        }
    }
}
