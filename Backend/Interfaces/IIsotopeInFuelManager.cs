using Backend.Domain;
using Backend.Managers;

namespace Backend.Interfaces
{
    public interface IIsotopeInFuelManager
    {
        public void Create(IsotopeInFuel newObject);
        public Queryset<IsotopeInFuel> Get(int id);
        public Queryset<IsotopeInFuel> List();
        public Queryset<IsotopeInFuel> Filter<F>(string colName, F value);
        public void Update(int id, IsotopeInFuel newObject);
        public void Delete(int id);
        public void CreateTable();
    }
}
