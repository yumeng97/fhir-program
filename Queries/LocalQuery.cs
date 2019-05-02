using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.Models;

namespace project.Queries
{
    public static class PractitionerCollection
    {
        private static List<IPractitioner> practitioners = new List<IPractitioner>();
        private static Dictionary<IPractitioner, DateTime> timeStamp = new Dictionary<IPractitioner, DateTime>();

        public static bool ValidExist(IPractitioner p)
        {
            bool exist = false;
            foreach (IPractitioner _p in practitioners)
            {
                if (_p.Id == p.Id)
                {
                    if (DateTime.Now.Subtract(timeStamp[_p]).TotalMinutes > 60)
                    {
                        exist = true;
                    }
                }
            }
            return exist;
        }

        public static IPractitioner Get(IPractitioner p)
        {
            return practitioners.Where(_p => _p.Id == p.Id).First();
        }

        public static void Add(IPractitioner p)
        {
            practitioners.Add(p);
            timeStamp.Add(p, DateTime.Now);
        }

        public static void Delete(IPractitioner p)
        {
            var _p = Get(p);
            practitioners.Remove(_p);
            timeStamp.Remove(_p);
        }

        public static void Update(IPractitioner p)
        {
            Delete(p);
            practitioners.Add(p);
        }
    }
}
