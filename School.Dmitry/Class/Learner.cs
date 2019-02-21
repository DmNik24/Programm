using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class Learner:IHuman
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public long PhoneNumber { get; set; }
        public bool InClass { get; set; }
    }
}
