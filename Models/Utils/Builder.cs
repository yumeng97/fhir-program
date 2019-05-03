using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models

{
    /// <summary>
    /// Builder for Patient
    /// </summary>
    public class PatientBuilder
    {
        private IPatient _patient = new Patient();

        public PatientBuilder SetId(string id)
        {
            _patient.Id = id;
            return this;
        }
        public PatientBuilder SetGender(string gender)
        {
            _patient.Gender = gender;
            return this;
        }
        public PatientBuilder SetLastUpdated(DateTime lastUpdated)
        {
            _patient.LastUpdated = lastUpdated;
            return this;
        }
        public PatientBuilder SetBirthDate(DateTime birthDate)
        {
            _patient.BirthDate = birthDate;
            return this;
        }

        public PatientBuilder SetName(string familyName, string givenName)
        {
            Name name = new Name(familyName, givenName);
            _patient.Name = name;
            return this;
        }

        public PatientBuilder SetAddress(string line, string city, string state, string postalCode, string country)
        {
            Address address = new Address(line, city, state, postalCode, country);
            _patient.Address = address;
            return this;
        }
        public PatientBuilder SetTelecom(string system, string value, string use)
        {
            Telecom telecom = new Telecom(system, value, use);
            _patient.Telecom = telecom;
            return this;
        }

        public IPatient Build()
        {
            return _patient;
        }
    }

    /// <summary>
    /// Builder for Practitioner
    /// </summary>
    public class PractitionerBuilder
    {
        private IPractitioner _practitioner = new Practitioner();
        public PractitionerBuilder SetId(string id)
        {
            _practitioner.Id = id;
            return this;
        }
        public PractitionerBuilder SetGender(string gender)
        {
            _practitioner.Gender = gender;
            return this;
        }
        public PractitionerBuilder SetActive(bool active)
        {
            _practitioner.Active = active;
            return this;
        }
        public PractitionerBuilder SetLastUpdated(DateTime lastUpdated)
        {
            _practitioner.LastUpdated = lastUpdated;
            return this;
        }
        public PractitionerBuilder SetName(string familyName, string givenName)
        {
            Name name = new Name(familyName, givenName);
            _practitioner.Name = name;
            return this;
        }

        public PractitionerBuilder SetAddress(string line, string city, string state, string postalCode, string country)
        {
            Address address = new Address(line, city, state, postalCode, country);
            _practitioner.Address = address;
            return this;
        }
        public IPractitioner Build()
        {
            return _practitioner;
        }
    }

    /// <summary>
    /// Builder for observation
    /// </summary>
    public class ObservationBuilder
    {
        private Observation _observation = new Observation();

        public ObservationBuilder SetId(string id)
        {
            _observation.PatientId = id;
            return this;
        }
        public ObservationBuilder SetTotalCholesterol(string cholesterol)
        {
            _observation.TotalCholesterol = cholesterol;
            return this;
        }

        public ObservationBuilder SetEffectiveDateTime(DateTime dateTime)
        {
            _observation.EffectiveDateTime = dateTime;
            return this;
        }
        public Observation Build()
        {
            return _observation;
        }
    }

}
