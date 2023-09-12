using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Backend.Variables;

namespace Backend.Domain
{
    public class IsotopeInFuel : BaseManyToMany
    {
        protected float amount;
        public readonly static string IsotobeTableName = TableNames.Isotope;
        public readonly static string FuelTableName = TableNames.Fuel;
          
        public float Amount { get {  return amount; } set { amount = value; } }


        public IsotopeInFuel(int IsotopeID, int FuelID, float amount) : base(IsotopeID, FuelID)
        {
            this.amount = amount;
        }
    }
}
