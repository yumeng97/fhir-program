using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project.Models;
using project.Services;

namespace project.Controllers
{
    /// <summary>
    /// Controller for Practitioner
    /// </summary>
    [Route("api/[controller]")]
    public class PractitionerController : Controller
    {
        private readonly PractitionerService _practitionerService = new PractitionerService();

        /// <summary>
        /// To display a collection of IPractitioner
        /// </summary>
        /// <returns> A collection of IPractitioner </returns>
        [HttpGet("[action]")]
        public async Task<IEnumerable<IPractitioner>> ShowAll()
        {
            return await _practitionerService.GetAll();
        }

        /// <summary>
        /// Get practitioner given id, will route to a new page
        /// </summary>
        /// <param name="id"> Practitioner ID </param>
        /// <returns> IPractitioner </returns>
        [HttpGet("[action]/{id}")]
        public async Task<IPractitioner> Get(string id)
        {
            return await _practitionerService.GetById(id);
        }

        /// <summary>
        /// Monitor a patient
        /// </summary>
        /// <param name="id"> Practitioner ID </param>
        /// <param name="patientId"> Patient ID </param>
        [HttpPut("[action]/{id}/{patientId}")]
        public void AddPatientMonitor(string id, string patientId)
        {
            _practitionerService.AddPatientMonitor(id, patientId);
        }

        /// <summary>
        /// Stop monitoring a patient
        /// </summary>
        /// <param name="id"> Practitioner ID </param>
        /// <param name="patientId"> Patient ID </param>
        [HttpPut("[action]/{id}/{patientId}")]
        public void DeletePatientMonitor(string id, string patientId)
        {
            _practitionerService.DeletePatientMonitor(id, patientId);
        }
    }
}
