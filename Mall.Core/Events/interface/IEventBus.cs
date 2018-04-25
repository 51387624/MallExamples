using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Core.Events
{
    /// <summary>
    /// 事件驱动总线
    /// </summary>
    public interface IEventBus : IEventSubscriber, IEventPublisher
    {

    }
}
