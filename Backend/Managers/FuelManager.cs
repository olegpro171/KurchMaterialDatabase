using Backend.Core;
using Backend.Domain;
using Backend.Variables;

namespace Backend.Managers
{
    public class FuelManager : BaseObjectManager<Fuel>
    {
        public FuelManager(DatabaseCore databaseCore) : base(databaseCore, TableNames.Fuel) { }

        //public override Queryset<Isotope> RelatedIsotopes(int id, string query)
        //{
        
        //}

        protected override Queryset<R> Related<R>(string query)
        {
            return base.Related<R>(query);
        }

        public Queryset<Isotope> RelatedIsotopes(int id)
        {
            string query = @$"SELECT {TableNames.Isotope}.id, {TableNames.Isotope}.name, {TableNames.IsotopeInFuel}.amount
                              FROM {TableNames.Isotope} 
                              INNER JOIN {TableNames.IsotopeInFuel} ON {TableNames.Isotope}.id = {TableNames.IsotopeInFuel}.id_1 
                              WHERE {TableNames.IsotopeInFuel}.id_2 = {id}";
            return base.Related<Isotope>(query);
        }
    }
}
