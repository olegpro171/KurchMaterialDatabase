using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain
{
    public class Isotope
    {
        public string Name { get; set; }
        public Isotope(string name)
        {
            this.Name = name;
        }

        public Isotope() 
        {
            Name = "-default-";
        }

        public override string ToString()
        {
            return $"Name={Name}";
        }
    }
}
