using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Repositories;
using project.Models;
using project.Observables;

namespace project.Services
{
    /// <summary>
    /// Patient Service, calling from repo to perform heavy/heavier logic
    /// </summary>
    public class PatientService
    {
        private readonly PatientRepository PatientRepository = new PatientRepository();
        private readonly PractitionerRepository PractitionerRepository = new PractitionerRepository();
        private readonly ObservationRepository ObservationRepository = new ObservationRepository();

        /// <summary>
        /// Get patient given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> A patient </returns>
        public async Task<IPatient> GetById(string id)
        {
            return await PatientRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Get a collection of patient
        /// </summary>
        /// <returns> A collection of patient</returns>
        public async Task<IEnumerable<IPatient>> GetAll()
        {
            return await PatientRepository.GetAllAsync();
        }

        /// <summary>
        /// Get a collection of patient given practitioner ID that is being monitored
        /// </summary>
        /// <param name="practitionerId"> Practitioner ID</param>
        /// <returns> A collection of Patient </returns>
        public async Task<IEnumerable<IPatient>> GetMonitoredByPractitionerId(string practitionerId)
        {
            List<IPatient> patients = new List<IPatient>();
            if (ObservationCollection.MonitoredPatientsByPractitioner.ContainsKey(practitionerId))
            {
                foreach (var patientId in ObservationCollection.MonitoredPatientsByPractitioner[practitionerId])
                {
                    var p = await PatientRepository.GetByIdAsync(patientId);
                    patients.Add(p);
                }
                foreach (var p in patients)
                {
                    p.Observations = ObservationCollection.Observations[p.Id][practitionerId];
                }
            }

            return patients;
        }

        /// <summary>
        /// Get a collection of patient given practitioner ID that is not being monitored
        /// </summary>
        /// <param name="practitionerId"> Practitioner ID</param>
        /// <returns> A collection of Patient </returns>
        public async Task<IEnumerable<IPatient>> GetNotMonitoredByPractitionerId(string practitionerId)
        {
            var patients = await PatientRepository.GetAllAsync();
            var newPatients = new List<IPatient>();
            foreach (var p in patients)
            {
                if (! (ObservationCollection.Observations.ContainsKey(p.Id)))
                {
                    newPatients.Add(p);
                }
                else
                {
                    if (! (ObservationCollection.Observations[p.Id].ContainsKey(practitionerId)))
                    {
                        newPatients.Add(p);
                    }
                }
            }
            return newPatients;
        }

            /// <summary>
            /// Get a collection of observation given patient id
            /// </summary>
            /// <param name="id"> Patient ID </param>
            /// <returns> A collection of Observation </returns>
        public async Task<IEnumerable<Observation>> GetObservationById(string id)
        {
            List<Observation> observations = (List<Observation>) await ObservationRepository.GetByPatientAndBloodPressure(id);
            observations.AddRange(await ObservationRepository.GetByPatientAndTotalCholesterol(id));
            observations.AddRange(await ObservationRepository.GetByPatientAndTobacco(id));
            return observations;
        }

        /// <summary>
        /// Get a collection of patient with their respectives observations given a collection of patient
        /// </summary>
        /// <param name="patients"> a collection of patients</param>
        /// <returns> a collection of patients </returns>
        public async Task<IEnumerable<IPatient>> GetPatientsWithObservations(IEnumerable<IPatient> patients)
        {
            List<IPatient> patientsWithObservations = new List<IPatient>();
            foreach (IPatient patient in patients)
            {
                patient.Observations = (List<Observation>)await GetObservationById(patient.Id);
                patient.Observations.Sort((x, y) => DateTime.Compare(x.EffectiveDateTime, y.EffectiveDateTime));
                patientsWithObservations.Add(patient);
            }
            return patientsWithObservations;
        }
    }
}
