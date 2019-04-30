using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public struct Name
    {
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string Prefix { get; set; }

        public Name(string familyName, string givenName, string prefix)
        {
            FamilyName = familyName;
            GivenName = givenName;
            Prefix = prefix;
        }
    }

    public struct Address
    {
        public string Line { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public Address(string line, string city, string state, string postalCode, string country)
        {
            Line = line;
            City = city;
            State = state;
            PostalCode = postalCode;
            Country = country;
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
}
