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
            return await practitionerQuery.GetPractitionerAsync(argument);
        }

        public async Task<IEnumerable<IPractitioner>> GetAllAsync()
        {
            return await practitionerQuery.GetPractitionersAsync();
        }
    }
}
