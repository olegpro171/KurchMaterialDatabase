using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return $"ID={Id:D4}; Obj={Obj}";
        }
    }
}
