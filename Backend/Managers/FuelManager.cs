using Backend.Core;
using Backend.Domain;
using Backend.Variables;
using Backend.Interfaces;

namespace Backend.Managers
{
    public class FuelManager : BaseObjectManager<Fuel>, IFuelManager
    {
        public FuelManager(DatabaseCore databaseCore) : base(databaseCore, TableNames.Fuel) { }


        protected override Queryset<R> Related<R>(string query)
        {
            return base.Related<R>(query);
        }

        public Queryset<Isotope> RelatedIsotopes(int id)
        {
            string query = 
                $"SELECT i.id, i.name, iif.amount, iif.id relation_id " +
                $"FROM {TableNames.Isotope} i " +
                $"INNER JOIN {TableNames.IsotopeInFuel} iif ON i.id = iif.id_1 " +
                $"WHERE iif.id_2 = {id} ";

            return base.Related<Isotope>(query);
        }

        public override void Delete(int id)
        {
            base.Delete(id);
            string query = $"DELETE FROM isotope_in_fuel WHERE id_2 = {id}";
            dbCore.OpenConnection();
            dbCore.ExecuteSQL(query);
            dbCore.CloseConnection();
        }
    }
}
