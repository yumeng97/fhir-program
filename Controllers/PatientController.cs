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
        private readonly PatientService PatientService = new PatientService();

        /// <summary>
        /// To display a collection of IPatient
        /// </summary>
        /// <returns> A collection of IPatient </returns>
        [HttpGet("[action]")]
        public async Task<IEnumerable<IPatient>> ShowAll()
        {
            return await PatientService.GetAll();
        }

        /// <summary>
        /// To display a collection of IPatient that is not being monitored
        /// </summary>
        /// <param name="practitionerId"> Practitioner ID </param>
        /// <returns> A collection of IPatient </returns>
        [HttpGet("[action]/{practitionerId}")]
        public async Task<IEnumerable<IPatient>> ShowNotMonitored(string practitionerId)
        {
            return await PatientService.GetNotMonitoredByPractitionerId(practitionerId);
           // return await PatientService.GetPatientsWithObservations(patients);
        }

        /// <summary>
        /// To display a collection of IPatient that is being monitored
        /// </summary>
        /// <param name="practitionerId"> Practitioner ID </param>
        /// <returns> A collection of IPatient </returns>
        [HttpGet("[action]/{practitionerId}")]
        public async Task<IEnumerable<IPatient>> ShowMonitored(string practitionerId)
        {
            var patients = await PatientService.GetMonitoredByPractitionerId(practitionerId);
            Console.WriteLine(patients);
            return patients;
            //return await PatientService.GetPatientsWithObservations(patients);
        }
    }
}
