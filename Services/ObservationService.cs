using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Repositories;
using project.Models;

namespace project.Services
{
    public class ObservationService
    {
        private readonly ObservationRepository _observationRepository = new ObservationRepository();

        public async Task<Observation> GetById(string id)
        {
            return await _observationRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Observation>> GetAll()
        {
            return await _observationRepository.GetAllAsync();
        }
    }
}
