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
        private readonly PractitionerRepository _practitionerRepository = new PractitionerRepository();

        /// <summary>
        /// Get practitioner given id
        /// </summary>
        /// <param name="id"> Practitioner ID </param>
        /// <returns> A practitioner</returns>
        public async Task<IPractitioner> GetById(string id)
        {
            return await _practitionerRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Get a collection of Practitioner
        /// </summary>
        /// <returns> a collection of Practitioner </returns>
        public async Task<IEnumerable<IPractitioner>> GetAll()
        {
            return await _practitionerRepository.GetAllAsync();
        }

        /// <summary>
        /// Add to monitor
        /// </summary>
        /// <param name="id"> Practitioner ID </param>
        /// <param name="patientId"> Patient ID </param>
        public void AddPatientMonitor(string id, string patientId)
        {
            _practitionerRepository.AddMonitorByIdAndPatientId(id, patientId);
        }

        /// <summary>
        /// Remove from monitor
        /// </summary>
        /// <param name="id"> Practitioner ID </param>
        /// <param name="patientId"> Patient ID </param>
        public void DeletePatientMonitor(string id, string patientId)
        {
            _practitionerRepository.DeleteMonitorByIdAndPatientId(id, patientId);
        }
    }
}
