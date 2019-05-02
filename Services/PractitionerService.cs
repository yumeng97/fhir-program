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
        private readonly PractitionerRepository _practitionerRepository = new PractitionerRepository();

        public async Task<IPractitioner> GetById(string id)
        {
            return await _practitionerRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<IPractitioner>> GetAll()
        {
            return await _practitionerRepository.GetAllAsync();
        }

        public async Task<IPractitioner> AddPatientMonitor(string practitionerId, string patientId)
        {
            var practitioner = await _practitionerRepository.GetByIdAsync(practitionerId);
            practitioner.AddToMonitored(patientId);
            return practitioner;
        }
    }
}
