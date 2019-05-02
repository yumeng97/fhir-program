using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Models;
using project.Queries;

namespace project.Repositories
{
    public class PractitionerRepository
    {
        private readonly PractitionerQuery practitionerQuery = new PractitionerQuery();
        private readonly string argumentStart = "?";

        public async Task<IPractitioner> GetByIdAsync(string id)
        {
            string argument = argumentStart + "_id=" + id;
            var practitioner = await practitionerQuery.GetPractitionersAsync(argument);
            return practitioner.ElementAt(0);
        }

        public async Task<IEnumerable<IPractitioner>> GetAllAsync()
        {
            return await practitionerQuery.GetPractitionersAsync();
        }
    }
}
