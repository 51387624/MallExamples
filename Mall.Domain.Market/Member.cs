using Mall.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Domain.Market
{
    public class Member :ValueObject
    {
        public Guid Id { get;  }
        public string Name { get;  }
        public decimal AvailableBalance { get; }

        public Member(Guid id, string name, decimal availableBalance)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("参数不能为Guid.Empty", "Member.Id");
            this.Id = id;
            this.Name = name;
            this.AvailableBalance = availableBalance;
        }

    }
}
