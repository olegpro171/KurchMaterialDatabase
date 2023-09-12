using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Backend.Variables;

namespace Backend.Domain
{
    public class IsotopeInFuel : BaseM2MRelation
    {
        public float Amount { get; set; }


        public IsotopeInFuel(int IsotopeID, int FuelID, float amount) : base(IsotopeID, FuelID)
        {
            Amount = amount;
        }

        public IsotopeInFuel() : base()
        {
            Amount = 0.0f;
        }
    }
}
