using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesConsoleApp
{
    public class Badge
    {
        public double ID { get; set; }
        public List<string> AccessibleDoors { get; set; } = new List<string>();
        public Badge(double id, List<string> doors)
        {
            ID = id;
            AccessibleDoors = doors;
        }
    }
}
