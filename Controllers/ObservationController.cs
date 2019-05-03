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
    public class ObservationController : Controller
    {
        private readonly ObservationService ObservationService = new ObservationService();

        [HttpGet("[action]")]
        public async Task<IEnumerable<Observation>> ShowAll()
        {
            return await ObservationService.GetAll();
        }

        [HttpGet("[action]/{id}")]
        public async Task<Observation> Get(string patientId)
        {
            return await ObservationService.GetById(patientId);
        }
    }
}
