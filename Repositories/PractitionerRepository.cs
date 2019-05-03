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
            var practitioners = await practitionerQuery.GetPractitionersAsync(argument);
            var practitioner = practitioners.ElementAt(0);
            if (PractitionerMonitorCollection.Exist(id))
            {
                practitioner.MonitoredPatients = PractitionerMonitorCollection.Get(id);
            }
            return practitioner;
        }

        public async Task<IEnumerable<IPractitioner>> GetAllAsync()
        {
            return await practitionerQuery.GetPractitionersAsync();
        }

        public void AddMonitorByIdAndPatientId(string id, string patientId)
        {
            PractitionerMonitorCollection.Add(id, patientId);
        }

        public void DeleteMonitorByIdAndPatientId(string id, string patientId)
        {
            PractitionerMonitorCollection.Delete(id, patientId);
        }
    }
}
