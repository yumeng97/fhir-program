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
            public string Family, Given, Prefix;

            public Name(string familyName, string givenName, string prefix)
            {
                Family = familyName;
                Given = givenName;
                Prefix = prefix;
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
            public string Line, City, State, PostalCode, Country;

            public Address(string line, string city, string state, string postalCode, string country)
            {
                Line = line;
                City = city;
                State = state;
                PostalCode = postalCode;
                Country = country;
            }

        }
    }
}
