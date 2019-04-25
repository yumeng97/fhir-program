using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class Clinician : IClinician
    {
        public string Id { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Active { get; set; }
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
