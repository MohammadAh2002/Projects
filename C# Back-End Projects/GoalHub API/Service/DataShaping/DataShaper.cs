using Contracts.DataShaping;
using System.Dynamic;
using System.Reflection;

namespace Service.DataShaping
{
    public class DataShaper<T> : IDataShaper<T> where T : class
    {
        public PropertyInfo[] Properties { get; set; }

        public DataShaper()
        {
            Properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        public IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> Entities, string FieldsString)
        {
            IEnumerable<PropertyInfo> requiredProperties = GetRequiredProperties(FieldsString);

            return FetchData(Entities, requiredProperties);
        }

        public ExpandoObject ShapeData(T Entity, string FieldsString)
        {
            IEnumerable<PropertyInfo> requiredProperties = GetRequiredProperties(FieldsString);

            return FetchData(Entity, requiredProperties);
        }

        private IEnumerable<PropertyInfo> GetRequiredProperties(string FieldsString)
        {
            List<PropertyInfo> requiredProperties = new List<PropertyInfo>();

            if (!string.IsNullOrWhiteSpace(FieldsString))
            {
                string[] fields = FieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

                foreach (string field in fields)
                {
                    PropertyInfo? property = Properties
                        .FirstOrDefault(pi => pi.Name.Equals(field.Trim(), StringComparison.InvariantCultureIgnoreCase));

                    if (property == null)
                        continue;

                    requiredProperties.Add(property);
                }
            }
            else
            {
                requiredProperties = Properties.ToList();
            }

            return requiredProperties;
        }

        private IEnumerable<ExpandoObject> FetchData(IEnumerable<T> entities, IEnumerable<PropertyInfo> requiredProperties)
        {
            List<ExpandoObject> shapedData = new List<ExpandoObject>();

            foreach (T entity in entities)
            {
                ExpandoObject shapedObject = FetchData(entity, requiredProperties);
                shapedData.Add(shapedObject);
            }

            return shapedData;
        }

        private ExpandoObject FetchData(T entity, IEnumerable<PropertyInfo> requiredProperties)
        {
            ExpandoObject shapedObject = new ExpandoObject();

            foreach (PropertyInfo property in requiredProperties)
            {
                object? objectPropertyValue = property.GetValue(entity);
                
                shapedObject.TryAdd(property.Name, objectPropertyValue);
            }

            return shapedObject;
        }
    }
}
