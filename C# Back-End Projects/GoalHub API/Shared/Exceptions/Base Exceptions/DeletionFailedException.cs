using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class DeletionFailedException : Exception
    {
        public DeletionFailedException(string message) : base(message)
        {
        }
    }
}
