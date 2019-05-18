using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Observables
{
    public static class ObservationCollection
    {
        public static Dictionary<string, ObservationMonitor> observationMonitors = new Dictionary<string, ObservationMonitor>();
    }
}
