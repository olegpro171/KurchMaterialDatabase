using Backend.Domain;
using Backend.Managers;

namespace Backend.Interfaces
{
    public interface IIsotopeManager
    {
        public void Create(Isotope newObject);
        public Queryset<Isotope> Get(int id);
        public Queryset<Isotope> List();
        public Queryset<Isotope> Filter<F>(string colName, F value, bool exact = false);
        public void Update(int id, Isotope newObject);
        public void Delete(int id);
        public Queryset<Fuel> RelatedMaterials(int id);
        public void CreateTable();
    }
}
