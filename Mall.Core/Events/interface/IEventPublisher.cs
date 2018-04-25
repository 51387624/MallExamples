using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mall.Core.Events
{
    /// <summary>
    /// 事件发布者
    /// </summary>
    public interface IEventPublisher : IDisposable
    {
        Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
            where TEvent : IEvent;
    }
}
