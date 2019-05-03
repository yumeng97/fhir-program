using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public interface IPatient : IUser
    {
        DateTime BirthDate { get; set; }
        Telecom Telecom { get; set; }
        List<Observation> Observations { get; set; }
    }
}
