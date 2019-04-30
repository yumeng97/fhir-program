using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models

{
    public class PatientBuilder
    {
        private IPatient Patient = new Patient();

        public PatientBuilder SetId(string id)
        {
            Patient.Id = id;
            return this;
        }

        public PatientBuilder SetMaritalStatus(string maritalStatus)
        {
            Patient.MaritalStatus = maritalStatus;
            return this;
        }
        public PatientBuilder SetGender(string gender)
        {
            Patient.Gender = gender;
            return this;
        }
        public PatientBuilder SetLastUpdated(DateTime lastUpdated)
        {
            Patient.LastUpdated = lastUpdated;
            return this;
        }
        public PatientBuilder SetDeceasedDateTime(DateTime deceasedDateTime)
        {
            Patient.DeceasedDateTime = deceasedDateTime;
            return this;
        }
        public PatientBuilder SetBirthDate(DateTime birthDate)
        {
            Patient.BirthDate = birthDate;
            return this;
        }

        public PatientBuilder SetName(string familyName, string givenName, string prefix)
        {
            Name name = new Name(familyName, givenName, prefix);
            Patient.Name = name;
            return this;
        }

        public PatientBuilder SetAddress(string line, string city, string state, string postalCode, string country)
        {
            Address address = new Address(line, city, state, postalCode, country);
            Patient.Address = address;
            return this;
        }
        public PatientBuilder SetTelecom(string system, string value, string use)
        {
            Telecom telecom = new Telecom(system, value, use);
            Patient.Telecom = telecom;
            return this;
        }

        public IPatient Build()
        {
            return Patient;
        }
    }

    public class PractitionerBuilder
    {
        private IPractitioner Practitioner = new Practitioner();
        public PractitionerBuilder SetId(string id)
        {
            Practitioner.Id = id;
            return this;
        }
        public PractitionerBuilder SetGender(string gender)
        {
            Practitioner.Gender = gender;
            return this;
        }
        public PractitionerBuilder SetActive(bool active)
        {
            Practitioner.Active = active;
            return this;
        }
        public PractitionerBuilder SetLastUpdated(DateTime lastUpdated)
        {
            Practitioner.LastUpdated = lastUpdated;
            return this;
        }
        public PractitionerBuilder SetName(string familyName, string givenName, string prefix)
        {
            Name name = new Name(familyName, givenName, prefix);
            Practitioner.Name = name;
            return this;
        }

        public PractitionerBuilder SetAddress(string line, string city, string state, string postalCode, string country)
        {
            Address address = new Address(line, city, state, postalCode, country);
            Practitioner.Address = address;
            return this;
        }
        public IPractitioner Build()
        {
            return Practitioner;
        }
    }
}
