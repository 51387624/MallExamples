using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Core.Events
{
    /// <summary>
    /// 事件订阅者
    /// </summary>
    public interface IEventSubscriber : IDisposable
    {
        void Subscribe<TEvent, TEventHandler>()
        where TEvent : IEvent
        where TEventHandler : IEventHandler<TEvent>;
    }
}
