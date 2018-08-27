using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Domain
{
    /// <summary>
    /// 事件处理接口--事件处理程序基于事件本身，可通过继承异步Attribute：HandlesAsynchronously 实现异步处理。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEventHandler<T>
        where T : IEvent
    {
        /// <summary>
        /// 处理过程
        /// </summary>
        /// <param name="t">事件发生时的参与对象状态</param>
        void Handle(T t);
    }
}
