using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Repositories;
using project.Models;

namespace project.Services
{
    public class PractitionerService
    {
        private readonly PractitionerRepository practitionerRepository = new PractitionerRepository();

        public async Task<IPractitioner> GetById(string id)
        {
            return await practitionerRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<IPractitioner>> GetAll()
        {
            return await practitionerRepository.GetAllAsync();
        }

        public async Task<IPractitioner> AddPatientMonitor(string practitionerId, string patientId)
        {
            var practitioner = await practitionerRepository.GetByIdAsync(practitionerId);
            practitioner.AddToMonitored(patientId);
            return practitioner;
        }
    }
}
