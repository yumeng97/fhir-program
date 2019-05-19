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
            var practitioner = await PractitionerRepository.GetByIdAsync(practitionerId);
            return practitioner.MonitoredPatients.Select(id => PatientRepository.GetByIdAsync(id))
                                                 .Select(p => p.Result);
        }

        /// <summary>
        /// Get a collection of patient given practitioner ID that is not being monitored
        /// </summary>
        /// <param name="practitionerId"> Practitioner ID</param>
        /// <returns> A collection of Patient </returns>
        public async Task<IEnumerable<IPatient>> GetNotMonitoredByPractitionerId(string practitionerId)
        {
            var practitioner = await PractitionerRepository.GetByIdAsync(practitionerId);
            var patients = await PatientRepository.GetAllAsync();
            return patients.Where(patient => !practitioner.MonitoredPatients.Contains(patient.Id));
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
            Console.WriteLine(observations);
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
