using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mall.Core.Events
{
    public interface IEvent
    {
        Guid Id { get; }
        DateTime Timestamp { get; }
    }
}
