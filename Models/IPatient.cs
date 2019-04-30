using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public interface IPatient : IUser
    {
        string MaritalStatus { get; set; }
        DateTime BirthDate { get; set; }
        DateTime DeceasedDateTime { get; set; }
        Telecom Telecom { get; set; }
    }
}
