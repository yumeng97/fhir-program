using project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using project.Queries;

namespace project.Repositories
{
    /// <summary>
    /// Access patient data only
    /// </summary>
    public class PatientRepository
    {
        private readonly PatientQuery PatientQuery = new PatientQuery();
        private readonly string ArgumentStart = "?";

        /// <summary>
        /// Get patient by id
        /// </summary>
        /// <param name="id"> practitioner id </param>
        /// <returns> A patient </returns>
        public async Task<IPatient> GetByIdAsync(string id)
        {
            string argument = ArgumentStart + "_id=" + id;
            var patient = await PatientQuery.GetPatientsAsync(argument);
            return patient.ElementAt(0);
        }

        /// <summary>
        /// Get a collection of patient
        /// </summary>
        /// <returns> A collection of patient </returns>
        public async Task<IEnumerable<IPatient>> GetAllAsync()
        {
            return await PatientQuery.GetPatientsAsync();
        }
    }
}
