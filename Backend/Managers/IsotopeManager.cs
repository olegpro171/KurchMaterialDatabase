using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Backend.Domain;
using Backend.Core;
using Backend.Managers;
using System.Data;
using System.Xml.Linq;

namespace Backend.Managers
{
    public class IsotopeManager : BaseObjectManager<Isotope>
    {
        public IsotopeManager(DatabaseCore databaseCore) : base(databaseCore, Variables.TableNames.Isotope)
        {
        }

        //public override Queryset<Isotope> RelatedIsotopes(int id, string query)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
