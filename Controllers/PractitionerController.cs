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

        [HttpPut("[action]/{id}/{paId}")]
        public async Task<IPractitioner> MonitorPatient(string id, string paId = "1")
        {
            return await practitionerService.AddPatientMonitor(id, paId);
        }
    }
}
