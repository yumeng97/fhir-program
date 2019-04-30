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
    public class YeetController : Controller
    {
        private readonly PractitionerService practitionerService = new PractitionerService();

        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<IPractitioner>> Yeeting(int id)
        {
            return await practitionerService.GetAll();
        }
    }
}
