using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataShaping
{
    public interface IDataShaperFactory
    {
        IDataShaper<T> Create<T>() where T : class;
    }
}
