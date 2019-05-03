using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Models;
using project.Queries;

namespace project.Repositories
{
    /// <summary>
    /// Access observation data only
    /// </summary>
    public class ObservationRepository
    {
        private readonly ObservationQuery ObservationQuery = new ObservationQuery();
        private readonly string ArgumentStart = "?";
        private readonly string TotalCholesterol = "code=http://loinc.org|2093-3";
        private readonly string Patient = "patient=Patient/";

        /// <summary>
        /// Get observations with total cholesterol only by Patient ID
        /// </summary>
        /// <param name="patientId"> Patient ID </param>
        /// <returns> A collection of observation </returns>
        public async Task<IEnumerable<Observation>> GetByPatientAndTotalCholesterol(string patientId)
        {
            string argument = ArgumentStart + TotalCholesterol + "&" + Patient + patientId;
            var observations = await ObservationQuery.GetObservationsAsync(argument);
            return observations;
        }
    }
}
