using System;

namespace Demo.Domain
{
    /// <summary>
    /// 委托处理器
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    internal class ActionDelegatedEventHandler<TEvent> : IEventHandler<TEvent> where TEvent : class, IEvent
    {
        private Action<TEvent> eventHandlerFunc;

        public ActionDelegatedEventHandler(Action<TEvent> eventHandlerFunc)
        {
            this.eventHandlerFunc = eventHandlerFunc;
        }

        public void Handle(TEvent t)
        {
            throw new NotImplementedException();
        }
    }
}