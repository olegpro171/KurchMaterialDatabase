using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain
{
    public abstract class BaseMaterial
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Density { get; set; }


        public BaseMaterial(string name, string description, float density)
        {
            Name = name;
            Description = description;
            Density = density;
        }

        public BaseMaterial()
        {
            Name = String.Empty;
            Description = String.Empty;
            Density = 0.0f;
        }

        public override string ToString()
        {
            return $"Name={Name, -16}; Dens={Density:F2}; Desc={Description}";
        }
    }
}
