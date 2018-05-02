using Mall.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Domain.Market.Repertories
{
    public interface ICartRepository: IDomainRepository
    {
        Cart GetOfMember(Guid member);
        
    }
}
