using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mall.Core.Events
{
    /// <summary>
    /// 事件执行上下文
    /// </summary>
    public interface IEventHandlerExecutionContext
    {
        void RegisterHandler<TEvent, THandler>()
           where TEvent : IEvent
           where THandler : IEventHandler<TEvent>;

        void RegisterHandler(Type eventType, Type handlerType);

        bool HandlerRegistered<TEvent, THandler>()
            where TEvent : IEvent
            where THandler : IEventHandler<TEvent>;

        bool HandlerRegistered(Type eventType, Type handlerType);

        Task HandleEventAsync(IEvent @event, CancellationToken cancellationToken = default);
    }
}
