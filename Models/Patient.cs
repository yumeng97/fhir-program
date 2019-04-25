using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace project.Models
{
    public class Patient
    {
        public string Id { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeceasedDateTime { get; set; }
        public string MartialStatus { get; set; }
        public string Gender { get; set; }

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
        public struct Telecom
        {
            public string System, Value, Use;

            public Telecom(string system, string value, string use)
            {
                System = system;
                Value = value;
                Use = use;
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
