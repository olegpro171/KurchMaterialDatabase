using Backend.Exceptions;
using System.Reflection;

namespace Backend.Managers
{
    public class Queryset<T>
    {
        public List<ObjectWrapper<T>> Data { get; set; }

        public Queryset(List<ObjectWrapper<T>> list)
        {
            Data = list;
        }

        public Queryset()
        {
            Data = new List<ObjectWrapper<T>>();
        }

        public Queryset<T> Filter<F>(string colName, F value)
        {
            if (colName.ToLower() == "id")
            {
                var resultQueryset = new Queryset<T>();
                switch (value)
                {
                    case int intValue:
                        foreach (var item in Data)
                        {
                            if (item.Id == intValue)
                            {
                                resultQueryset.Data.Add(item);
                            }
                        }
                        return resultQueryset;

                    default:
                        throw new WrongColumnTypeException($"Property \"{colName}\" of {typeof(T).FullName} is {typeof(int).FullName} but filter parameter of type {typeof(F).FullName} provided");
                }
            }
            else
            {
                var searchProperty = typeof(T).GetProperty(colName)
                    ?? throw new WrongColumnNameException($"Property \"{colName}\" not present in type \"{typeof(T).FullName}\"");

                if (searchProperty.PropertyType != typeof(F))
                {
                    throw new WrongColumnTypeException($"Property \"{colName}\" of {typeof(T).FullName} is {searchProperty.PropertyType} but filter parameter of type {typeof(F).FullName} provided");
                }

                var resultQueryset = new Queryset<T>();
                foreach (var item in Data)
                {
                    var propertyValue = searchProperty.GetValue(item.Obj, null);
                    if (propertyValue != null && propertyValue.Equals(value))
                    {
                        resultQueryset.Data.Add(item);
                    }
                }
                return resultQueryset;
            }
        }


    }
}

