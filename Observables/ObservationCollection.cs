using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Models;

namespace project.Observables
{
    public static class ObservationCollection
    {
        public static Dictionary<string, Dictionary<string, List<Observation>>> Observations = new Dictionary<string, Dictionary<string, List<Observation>>>();
        public static Dictionary<string, ObservationMonitor> ObservationMonitors = new Dictionary<string, ObservationMonitor>();
        public static Dictionary<string, Dictionary<string, ObservationReporter>> ObservationReporters = new Dictionary<string, Dictionary<string, ObservationReporter>>();
        public static Dictionary<string, List<string>> MonitoredPatientsByPractitioner = new Dictionary<string, List<string>>();

    }
}
