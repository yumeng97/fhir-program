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
        private readonly string TotalCholesterolArg = "code=http://loinc.org|2093-3";
        private readonly string TobaccoArg = "code=http://loinc.org|72166-2";
        private readonly string BloodPressureArg = "code=http://loinc.org|55284-4";
        private readonly string PatientArg = "patient=Patient/";

        /// <summary>
        /// Get observations with total cholesterol only by Patient ID
        /// </summary>
        /// <param name="patientId"> Patient ID </param>
        /// <returns> A collection of observation </returns>
        public async Task<IEnumerable<Observation>> GetByPatientAndTotalCholesterol(string patientId)
        {
            string argument = ArgumentStart + TotalCholesterolArg + "&" + PatientArg + patientId;
            var observations = await ObservationQuery.GetObservationsAsync(Observation.ObservationType.Cholesterol, argument);
            return observations;
        }

        public async Task<IEnumerable<Observation>> GetByPatientAndTobacco(string patientId)
        {
            string argument = ArgumentStart + TobaccoArg + "&" + PatientArg + patientId;
            var observations = await ObservationQuery.GetObservationsAsync(Observation.ObservationType.Tobacco, argument);
            return observations;
        }
        public async Task<IEnumerable<Observation>> GetByPatientAndBloodPressure(string patientId)
        {
            string argument = ArgumentStart + BloodPressureArg + "&" + PatientArg + patientId;
            var observations = await ObservationQuery.GetObservationsAsync(Observation.ObservationType.BloodPressure, argument);
            return observations;
        }
    }
}
