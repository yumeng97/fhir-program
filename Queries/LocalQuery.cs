using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Models;

namespace project.Queries
{
    /// <summary>
    /// Local cache for monitoring pratient
    /// </summary>
    public static class PractitionerMonitorCollection
    {
        private static Dictionary<string, List<string>> practitionerMonitor = new Dictionary<string, List<string>>();

        /// <summary>
        /// Check if a practitioner is monitoring patients
        /// </summary>
        /// <param name="practitionerId"> practitioner id </param>
        /// <returns> true if monitoring, else false </returns>
        public static bool Exist(string practitionerId)
        {
            return practitionerMonitor.ContainsKey(practitionerId);
        }

        /// <summary>
        /// Get the monitor given practitioner id
        /// </summary>
        /// <param name="practitionerId"> practitioner id</param>
        /// <returns> a list of patient id </returns>
        public static List<string> Get(string practitionerId)
        {
            return practitionerMonitor[practitionerId];
        }
        /// <summary>
        /// Update the monitor with another list
        /// </summary>
        /// <param name="practitionerId"> practitioner ID </param>
        /// <param name="patientId"> a list of patient id </param>
        public static void Update(string practitionerId, List<string> patientId)
        {
            practitionerMonitor[practitionerId] = patientId;
        }
    }
}
