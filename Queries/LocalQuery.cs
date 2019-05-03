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

        public static void Update(string practitionerId, List<string> patientId)
        {
            practitionerMonitor[practitionerId] = patientId;
        }
    }
}
