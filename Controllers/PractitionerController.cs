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
    }
}
