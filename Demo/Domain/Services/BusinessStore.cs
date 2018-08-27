using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Concurrent;

namespace Demo.Domain
{
    /// <summary>
    /// 解决关于包子制作于消费问题的服务
    /// </summary>
    public class BusinessStore
    {
        /// <summary>
        /// 糕点师开始生产包子
        /// </summary>
        public void BeginCooker(ConcurrentBag<Cooker> cookers)
        {
            if (cookers == null || cookers.Count == 0)
                return;
            Task.WaitAll(cookers.Select(o => o.Cook()).ToArray());
        }
        /// <summary>
        /// 客人开始吃包子
        /// </summary>
        /// <param name="conserms"></param>
        public void BeginConsumer(ConcurrentBag<Consumer> conserms)
        {
            if (conserms == null || conserms.Count == 0)
                return;
            Task.WaitAll(conserms.Select(o => o.Eat()).ToArray());
        }
    }
}
