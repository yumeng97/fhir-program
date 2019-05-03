using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Repositories;
using project.Models;

namespace project.Services
{
    /// <summary>
    /// Practitioner Service, calling from repo to perform heavy/heavier logic
    /// </summary>
    public class PractitionerService
    {
        private readonly PractitionerRepository PractitionerRepository = new PractitionerRepository();

        /// <summary>
        /// Get practitioner given id
        /// </summary>
        /// <param name="id"> Practitioner ID </param>
        /// <returns> A practitioner</returns>
        public async Task<IPractitioner> GetById(string id)
        {
            return await PractitionerRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Get a collection of Practitioner
        /// </summary>
        /// <returns> a collection of Practitioner </returns>
        public async Task<IEnumerable<IPractitioner>> GetAll()
        {
            return await PractitionerRepository.GetAllAsync();
        }

        /// <summary>
        /// Add to monitor
        /// </summary>
        /// <param name="id"> Practitioner ID </param>
        /// <param name="patientId"> Patient ID </param>
        public async void AddPatientMonitor(string id, string patientId)
        {
            var practitioner = await PractitionerRepository.GetByIdAsync(id);
            practitioner.AddToMonitored(patientId);
            PractitionerRepository.UpdateMonitorByIdAndPatientIdList(id, practitioner.MonitoredPatients);
        }

        /// <summary>
        /// Remove from monitor
        /// </summary>
        /// <param name="id"> Practitioner ID </param>
        /// <param name="patientId"> Patient ID </param>
        public async void DeletePatientMonitor(string id, string patientId)
        {
            var practitioner = await PractitionerRepository.GetByIdAsync(id);
            practitioner.RemoveFromMonitored(patientId);
            PractitionerRepository.UpdateMonitorByIdAndPatientIdList(id, practitioner.MonitoredPatients);
        }
    }
}
