using Demo.Domain;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo
{
    /// <summary>
    /// 主程序
    /// </summary>
    class Program
    {
        /// <summary>
        /// 当前总包子数
        /// </summary>
        public static int TotalCount = 0;
        /// <summary>
        /// 供应能力是否国足
        /// </summary>
        internal static bool IsOverWorker = false;
        /// <summary>
        /// 是否停止全部糕点师工作
        /// </summary>
        internal static bool IsStopCook = false;
        /// <summary>
        /// 是否停止对客人销售服务
        /// </summary>
        internal static bool IsStopService = false;

        /// <summary>
        /// 锁
        /// </summary>
        internal static object objLock = new object();

        /// <summary>
        /// 并发安全类--厨师集合初始化
        /// </summary>
        public static ConcurrentBag<Cooker> cookers = new ConcurrentBag<Cooker>()
        {
            new Cooker (1),new Cooker (2),new Cooker (3)
        };
        /// <summary>
        /// 并发安全类--吃货集合初始化
        /// </summary>
        public static ConcurrentBag<Consumer> consumers = new ConcurrentBag<Consumer>()
        {
            new Consumer (1),new Consumer (2),new Consumer (3),new Consumer(4),new Consumer (5)
        };
        
        static void Main(string[] args)
        {
            //初始化全局事件
            InitEvents();
            BusinessStore store = new BusinessStore();
            while (true)
            {
                //同时启动制作包子和吃包子
                Task.WaitAll(
                    //制作包子
                    Task.Run(() => store.BeginCooker(cookers)),
                    //吃包子
                    Task.Run(() => store.BeginConsumer(consumers))
                );
            }
        }

        /// <summary>
        /// 初始化事件监听与事件处理器---划重点，事件驱动设计的精髓
        /// </summary>
        static void InitEvents()
        {
            //注入生产蛋糕会触发的事件
            EventBus.Instance.Subscribe(new CookCakeHandler());
            //注入用户吃包子时会触发的事件
            EventBus.Instance.Subscribe(new EatCakeHandler());
        }

    }
}
