using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace project.Models
{
    public class Patient : IPatient
    {
        public string Id { get; set; }
        public string Gender { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime BirthDate { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public Telecom Telecom { get; set; }
    }
}
