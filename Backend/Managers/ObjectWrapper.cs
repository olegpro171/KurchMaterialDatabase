using Backend.Domain;

namespace Backend.Managers
{
    public class ObjectWrapper<T>
    {
        public T Obj { get; }
        public int Id { get; }

        private float amount;
        public float Amount
        {
            get
            {
                if (typeof(T) == typeof(Isotope)) return amount;
                else throw new NotSupportedException("Only Isotope wrappers can have Amount property");
            }

            set
            {
                if (typeof(T) == typeof(Isotope)) amount = value;
                else throw new NotSupportedException("Only Isotope wrappers can have Amount property");
            }
        }
        

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

        public RelatedObjectWrapper(int id, T obj, float concentration) : base(id, obj)
        {
            Concentration = concentration;
        }

        public override string ToString()
        {
            return $"ID={Id:D4}; Conc={Concentration:F4}; Obj: {Obj}";
        }
    }
}
