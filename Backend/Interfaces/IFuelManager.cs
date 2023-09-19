using Backend.Managers;
using Backend.Domain;

namespace Backend.Interfaces
{
    public interface IFuelManager
    {
        public void Create(Fuel newObject);
        public Queryset<Fuel> Get(int id);
        public Queryset<Fuel> List();
        public Queryset<Fuel> Filter<F>(string colName, F value);
        public void Update(int id, Fuel newObject);
        public void Delete(int id);
        public Queryset<Isotope> RelatedIsotopes(int id);
        public void CreateTable();
    }
}
