using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Models;

namespace project.Queries
{
    public static class PractitionerMonitorCollection
    {
        private static Dictionary<string, List<string>> practitionerMonitor = new Dictionary<string, List<string>>();

        public static bool Exist(string practitionerId)
        {
            return practitionerMonitor.ContainsKey(practitionerId);
        }

        public static List<string> Get(string practitionerId)
        {
            return practitionerMonitor[practitionerId];
        }

        public static void Add(string practitionerId, string patientId)
        {
            if (Exist(practitionerId))
            {
                if (!Get(practitionerId).Contains(patientId))
                {
                    Get(practitionerId).Add(patientId);
                }
            } else
            {
                practitionerMonitor[practitionerId] = new List<string>
                {
                    patientId
                };
            }
        }

        public static void Delete(string practitionerId, string patientId)
        {
            if (Exist(practitionerId))
            {
                if (Get(practitionerId).Contains(patientId))
                {
                    Get(practitionerId).Remove(patientId);
                }
            }
        }
    }
}
