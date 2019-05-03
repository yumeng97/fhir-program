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
    /// Controller for Patient
    /// </summary>
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        private readonly PatientService patientService = new PatientService();

        /// <summary>
        /// Display a collection of IPatient
        /// </summary>
        /// <returns> A collection of IPatient </returns>
        [HttpGet("[action]")]
        public async Task<IEnumerable<IPatient>> ShowAll()
        {
            return await patientService.GetAll();
        }

        /// <summary>
        /// Display a collection of IPatient that is not being monitored
        /// </summary>
        /// <param name="practitionerId"> Practitioner ID </param>
        /// <returns> A collection of IPatient </returns>
        [HttpGet("[action]/{practitionerId}")]
        public async Task<IEnumerable<IPatient>> ShowNotMonitored(string practitionerId)
        {
            return await patientService.GetByPractitionerId(practitionerId);
        }

        /// <summary>
        /// Display a collection of IPatient that is being monitored
        /// </summary>
        /// <param name="practitionerId"> Practitioner ID </param>
        /// <returns> A collection of IPatient </returns>
        [HttpGet("[action]/{practitionerId}")]
        public async Task<IEnumerable<IPatient>> ShowMonitored(string practitionerId)
        {
            return await patientService.GetByPractitionerId(practitionerId, true);
        }
    }
}
