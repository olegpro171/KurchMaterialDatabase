using Backend.Domain;

namespace Backend.Managers
{
    public class ObjectWrapper<T>
    {
        public T Obj { get; }
        public int Id { get; }
        
        public ObjectWrapper(int id, T obj)
        {
            Id = id;
            Obj = obj;
        }

        public override string ToString()
        {
            return $"ID={Id:D4}; Obj: {Obj}";
        }
    }


    public class RelatedObjectWrapper<T> : ObjectWrapper<T>
    {
        public float Concentration { get; }

        public int Relation_ID { get; }

        public RelatedObjectWrapper(int id, T obj, float concentration, int relation_ID) : base(id, obj)
        {
            Concentration = concentration;
            Relation_ID = relation_ID;
        }

        public override string ToString()
        {
            return $"ID={Id:D4}; Conc={Concentration:F4}; Obj: {Obj}";
        }
    }
}
