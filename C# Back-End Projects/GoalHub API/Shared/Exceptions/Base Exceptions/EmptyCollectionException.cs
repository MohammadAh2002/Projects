using Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class EmptyCollectionException : NotFoundException
    {
        public EmptyCollectionException(string message) : base(message)
        {
        }
    }
}
