using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entity)
        :base("${entity} not found")
        { }
    }
}
