using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Domain
{
    /// <summary>
    /// 吃货的吃包子事件
    /// </summary>
    public class EatCakeEvent : IEvent
    {
        /// <summary>
        /// 吃了多少个
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 因为场景不需要记录具体事件发生的人是谁，所以代码注释。
        /// </summary>
        //public Consumer Consumer{get;set;}
    }
}
