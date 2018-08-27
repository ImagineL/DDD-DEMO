using Demo.Libs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Domain
{
    /// <summary>
    /// 吃货们客户
    /// </summary>
    public partial class Consumer
    {
        public Consumer()
        {

        }
        public Consumer(int id)
        {
            ID = id;
        }
        /// <summary>
        /// 序号
        /// </summary>
        public int ID { get; set; }
    }
    /// <summary>
    /// 充血模型
    /// </summary>
    public partial class Consumer
    {
       /// <summary>
       /// 吃包子行为是吃货的基本能力，不应该被踢出在类外
       /// </summary>
       /// <returns>异步</returns>
        public Task<int> Eat()
        {
            return Task.Run<int>(() =>
            {
                int count = 0;
                //休息吃东西间隔
                Thread.Sleep(Constant.EatStep);
                //锁 避免线程争发
                lock (Program.objLock)
                {
                    if (Program.IsStopService || Program.TotalCount <= 0)
                        return 0;
                    else
                    {
                        //随机吃1-5个包子
                        count = new Random(Guid.NewGuid().GetHashCode()).Next(1, 5);
                        Program.TotalCount -= count;
                        Libs.Logger.Eat($"吃货客人:{ID},一次吃掉包子：{count}个");
                        //告诉场景：我已经吃了这么多个包子，场景看着办，而否糕点师看着办！
                        EventBus.Instance.Publish(new EatCakeEvent()
                        {
                            Count = count
                        });
                    }

                }

                return count;
            });
        }
    }
}
