using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Core.Exception
{
    public class NotFoundException:MallException
    {
        public NotFoundException(string message) 
            : base(message)
        {

        }
    }
}
