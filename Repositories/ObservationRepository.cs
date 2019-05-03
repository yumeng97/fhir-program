using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Models;
using project.Queries;

namespace project.Repositories
{
    public class ObservationRepository
    {
        private readonly ObservationQuery observationQuery = new ObservationQuery();
        private readonly string argumentStart = "?";

        public async Task<Observation> GetByIdAsync(string id)
        {
            string argument = argumentStart + "_id=" + id;
            var observation = await observationQuery.GetObservationsAsync(argument);
            return observation.ElementAt(0);
        }

        public async Task<IEnumerable<Observation>> GetAllAsync()
        {
            return await observationQuery.GetObservationsAsync();
        }
    }
}
