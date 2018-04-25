using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mall.Core.Events
{
    public abstract class BaseEventBus : IEventBus
    {

        protected readonly IEventHandlerExecutionContext eventHandlerExecutionContext;

        protected BaseEventBus(IEventHandlerExecutionContext eventHandlerExecutionContext)
        {
            this.eventHandlerExecutionContext = eventHandlerExecutionContext;
        }

        internal protected void b() { }
        private protected void a() { }

        public abstract Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) 
            where TEvent : IEvent;

        public abstract void Subscribe<TEvent, TEventHandler>()
            where TEvent : IEvent
            where TEventHandler : IEventHandler<TEvent>;

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 将大型字段设置为 null。
                disposedValue = true;
            }
        }
        
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
