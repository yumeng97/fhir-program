using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Repositories;
using project.Models;

namespace project.Services
{
    public class PatientService
    {
        private readonly PatientRepository _patientRepository = new PatientRepository();

        public async Task<IPatient> GetById(string id)
        {
            return await _patientRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<IPatient>> GetAll()
        {
            return await _patientRepository.GetAllAsync();
        }
    }
}
