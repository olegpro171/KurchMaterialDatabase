using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain
{
    public class Fuel : BaseMaterial
    {
        public string Color { get; set; }

        public Fuel(string name, string description, float density, string color) : base(name, description, density)
        {
            Color = color;
        }

        public Fuel() : base()
        {
            Color = String.Empty;
        }
    }
}
