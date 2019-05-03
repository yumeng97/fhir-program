using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Repositories;
using project.Models;

namespace project.Services
{
    /// <summary>
    /// Patient Service, calling from repo to perform heavy/heavier logic
    /// </summary>
    public class PatientService
    {
        private readonly PatientRepository _patientRepository = new PatientRepository();
        private readonly PractitionerRepository _practitionerRepository = new PractitionerRepository();
        private readonly ObservationRepository _observationRepository = new ObservationRepository();

        /// <summary>
        /// Get patient given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> A patient </returns>
        public async Task<IPatient> GetById(string id)
        {
            return await _patientRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Get a collection of patient
        /// </summary>
        /// <returns> A collection of patient</returns>
        public async Task<IEnumerable<IPatient>> GetAll()
        {
            return await _patientRepository.GetAllAsync();
        }

        /// <summary>
        /// Get a collection of patient given practitioner ID,
        /// if monitored false, return a collection of patient that is not being monitored
        /// if true, return a collection of patient that is being monitored
        /// </summary>
        /// <param name="practitionerId"> Practitioner ID</param>
        /// <param name="monitored"> bool </param>
        /// <returns> A collection of Patient </returns>
        public async Task<IEnumerable<IPatient>> GetByPractitionerId(string practitionerId, bool monitored = false)
        {
            var practitioner = await _practitionerRepository.GetByIdAsync(practitionerId);
            if (monitored) // Get observations of patients that is being monitored
            {
                var patients = new List<IPatient>();
                foreach (string id in practitioner.MonitoredPatients)
                {
                    var patient = await _patientRepository.GetByIdAsync(id);
                    patient.Observations = (List<Observation>) await GetObservationById(id);
                    patient.Observations.Sort((x, y) => DateTime.Compare(x.EffectiveDateTime, y.EffectiveDateTime));
                    patients.Add(patient);
                }
                return patients;
            } else
            {
                var patients = await _patientRepository.GetAllAsync();
                return patients.Where(patient => !practitioner.MonitoredPatients.Contains(patient.Id));
            }
        }

        /// <summary>
        /// Get a collection of observation given patient id
        /// </summary>
        /// <param name="id"> Patient ID </param>
        /// <returns> A collection of Observation </returns>
        public async Task<IEnumerable<Observation>> GetObservationById(string id)
        {
            return await _observationRepository.GetByPatientAndTotalCholesterol(id);
        }
    }
}
