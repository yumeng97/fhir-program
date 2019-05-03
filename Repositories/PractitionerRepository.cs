using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Models;
using project.Queries;

namespace project.Repositories
{
    /// <summary>
    /// Access practitioner data only
    /// </summary>
    public class PractitionerRepository
    {
        private readonly PractitionerQuery PractitionerQuery = new PractitionerQuery();
        private readonly string ArgumentStart = "?";

        /// <summary>
        /// Get practitioner by id, if monitoring, add them to an instance var of practitioner from "cache"
        /// </summary>
        /// <param name="id"> practitioner id </param>
        /// <returns> A practitioner </returns>
        public async Task<IPractitioner> GetByIdAsync(string id)
        {
            string argument = ArgumentStart + "_id=" + id;
            var practitioners = await PractitionerQuery.GetPractitionersAsync(argument);
            var practitioner = practitioners.ElementAt(0);
            if (PractitionerMonitorCollection.Exist(id))
            {
                practitioner.MonitoredPatients = PractitionerMonitorCollection.Get(id);
            }
            return practitioner;
        }

        /// <summary>
        /// Get a collection of practitioner
        /// </summary>
        /// <returns> a collection of practitioner </returns>
        public async Task<IEnumerable<IPractitioner>> GetAllAsync()
        {
            return await PractitionerQuery.GetPractitionersAsync();
        }


        /// <summary>
        /// Update the cache monitor patient
        /// </summary>
        /// <param name="id"> practitioner id </param>
        /// <param name="patientIds"> a list of patient ids </param>
        public void UpdateMonitorByIdAndPatientIdList(string id, List<string> patientIds)
        {
            PractitionerMonitorCollection.Update(id, patientIds);
        }
    }
}
