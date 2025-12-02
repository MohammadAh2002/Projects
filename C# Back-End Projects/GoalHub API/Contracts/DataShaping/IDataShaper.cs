using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataShaping
{
    public interface IDataShaper<T>
    {
        IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> Entities, string FieldsString);
        ExpandoObject ShapeData(T Entity, string FieldsString);
    }
}
