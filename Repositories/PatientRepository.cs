using project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using project.Queries;

namespace project.Repositories
{
    public class PatientRepository
    {
        private readonly PatientQuery patientQuery = new PatientQuery();
        private readonly string argumentStart = "?";

        public async Task<IPatient> GetByIdAsync(string id)
        {
            string argument = argumentStart + "_id=" + id;
            var patient = await patientQuery.GetPatientsAsync(argument);
            return patient.ElementAt(0);
        }

        public async Task<IEnumerable<IPatient>> GetAllAsync()
        {
            return await patientQuery.GetPatientsAsync();
        }
    }
}
