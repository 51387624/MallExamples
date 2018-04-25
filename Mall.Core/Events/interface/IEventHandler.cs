using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mall.Core.Events
{
    
    /// <summary>
    /// 事件处理者
    /// </summary>
    public interface IEventHandler
    {
        Task<bool> HandleAsync(IEvent @event, CancellationToken cancellationToken = default);
        bool CanHandle(IEvent @event);
    }

    public interface IEventHandler<in T> : IEventHandler
        where T : IEvent
    {
        Task<bool> HandleAsync(T @event, CancellationToken cancellationToken = default);
    }
   
}
