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
    public class PractitionerController : Controller
    {
        private readonly PractitionerService practitionerService = new PractitionerService();

        [HttpGet("[action]")]
        public async Task<IEnumerable<IPractitioner>> ShowAll()
        {
            return await practitionerService.GetAll();
        }

        [HttpGet("[action]/{id}")]
        public async Task<IPractitioner> Get(string id)
        {
            return await practitionerService.GetById(id);
        }

        [HttpPut("[action]/{id}/{patientId}")]
        public async Task<IPractitioner> AddPatientMonitor(string id, string patientId)
        {
            return await practitionerService.AddPatientMonitor(id, patientId);
        }

        [HttpPut("[action]/{id}/{patientId}")]
        public async Task<IPractitioner> DeletePatientMonitor(string id, string patientId)
        {
            return await practitionerService.DeletePatientMonitor(id, patientId);
        }
    }
}
