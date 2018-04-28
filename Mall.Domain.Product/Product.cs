using Mall.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Domain.Product
{
    public class Product : AggregateRootWithEventSourcing<long>
    {
        protected Product(long id) : 
            base(id)
        {

        }
    }
}
