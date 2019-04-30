using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public interface IPractitioner : IUser
    {
        bool Active { get; set; }
        List<string> MonitoredPatients { get; set; }
        void AddToMonitored(string id);
        void RemoveFromMonitored(string id);
    }
}
