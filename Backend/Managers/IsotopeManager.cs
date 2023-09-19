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
using Backend.Variables;
using Backend.Interfaces;

namespace Backend.Managers
{
    public class IsotopeManager : BaseObjectManager<Isotope>, IIsotopeManager
    {
        public IsotopeManager(IDatabaseCore databaseCore) : base(databaseCore, Variables.TableNames.Isotope)
        {
        }

        protected override Queryset<R> Related<R>(string query)
        {
            return base.Related<R>(query);
        }

        public override void Create(Isotope obj)
        {
            base.Create(obj);
        }

        public Queryset<Fuel> RelatedMaterials(int id)
        {
            string query = 
                $"SELECT fm.id, fm.color, fm.name, fm.description, fm.density, iif.amount " +
                $"FROM {TableNames.Fuel} fm " +
                $"INNER JOIN {TableNames.IsotopeInFuel} iif ON fm.id = iif.id_2 " +
                $"WHERE iif.id_1 = {id} ";
            return base.Related<Fuel>(query);
        }
    }
}
