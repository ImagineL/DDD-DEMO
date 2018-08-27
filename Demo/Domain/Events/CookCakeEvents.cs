using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Domain
{
    /// <summary>
    /// 糕点师生产糕点的事实
    /// </summary>
    public class CookCakeEvent:IEvent
    {
        /// <summary>
        /// 生产个数
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 生产糕点师ID
        /// </summary>
        public int ID { get; set; }
    }
}
