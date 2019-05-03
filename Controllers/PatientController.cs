using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project.Models;
using project.Services;

namespace project.Controllers
{
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        private readonly PatientService patientService = new PatientService();

        [HttpGet("[action]")]
        public async Task<IEnumerable<IPatient>> ShowAll()
        {
            return await patientService.GetAll();
        }

        [HttpGet("[action]/{practitionerId}")]
        public async Task<IEnumerable<IPatient>> ShowNotMonitored(string practitionerId)
        {
            return await patientService.GetByPractitionerId(practitionerId);
        }

        [HttpGet("[action]/{practitionerId}")]
        public async Task<IEnumerable<IPatient>> ShowMonitored(string practitionerId)
        {
            return await patientService.GetByPractitionerId(practitionerId, true);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IPatient> Get(string id)
        {
            return await patientService.GetById(id);
        }
    }
}
