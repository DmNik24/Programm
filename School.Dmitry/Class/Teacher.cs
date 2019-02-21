using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class Teacher:IHuman
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public long PhoneNumber { get; set; }
        public string Direction { get; set; }
    }
}
