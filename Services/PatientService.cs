using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Repositories;
using project.Models;

namespace project.Services
{
    public class PatientService
    {
        private readonly PatientRepository patientRepository = new PatientRepository();
        private readonly PractitionerRepository practitionerRepository = new PractitionerRepository();
        private readonly ObservationRepository observationRepository = new ObservationRepository();

        public async Task<IPatient> GetById(string id)
        {
            return await patientRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<IPatient>> GetAll()
        {
            return await patientRepository.GetAllAsync();
        }

        public async Task<IEnumerable<IPatient>> GetByPractitionerId(string practitionerId, Boolean monitored = false)
        {
            var practitioner = await practitionerRepository.GetByIdAsync(practitionerId);
            if (monitored)
            {
                var patients = new List<IPatient>();
                foreach (string id in practitioner.MonitoredPatients)
                {
                    var patient = await patientRepository.GetByIdAsync(id);
                    patient.Observations = (List<Observation>) await GetObservations(id);
                    patient.Observations.Sort((x, y) => DateTime.Compare(x.EffectiveDateTime, y.EffectiveDateTime));
                    patients.Add(patient);
                }
                return patients;
            } else
            {
                var patients = await patientRepository.GetAllAsync();
                foreach (var o in patients.Where(patient => !practitioner.MonitoredPatients.Contains(patient.Id)))
                {
                    Console.WriteLine("not");
                    Console.WriteLine(o.Id);
                }
                return patients.Where(patient => !practitioner.MonitoredPatients.Contains(patient.Id));
            }
        }

        public async Task<IEnumerable<Observation>> GetObservations(string patientId)
        {
            return await observationRepository.GetByPatientAndTotalCholesterol(patientId);
        }
    }
}
