using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public interface IUser
    {
        string Gender { get; set; }
        string Id { get; set; }
        Name Name { get; set; }
        Address Address { get; set; }
        DateTime LastUpdated { get; set; }
    }
}
