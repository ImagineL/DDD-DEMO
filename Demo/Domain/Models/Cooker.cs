using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Domain
{
    /// <summary>
    /// 糕点师实例
    /// </summary>
    public partial class Cooker
    {
        public Cooker()
        {
            State = true;
        }
        public Cooker(int id) : this()
        {
            ID = id;
        }
        /// <summary>
        /// 序号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 工作状态，True:工作中，Flase:停止工作
        /// </summary>
        public bool State { get; set; }
    }
    /// <summary>
    /// 充血模型的部分类
    /// </summary>
    public partial class Cooker
    {
        /// <summary>
        /// 作为糕点师，能够制作糕点，是基本能力，不应该剥离在糕点师这个对象之外！
        /// </summary>
        /// <returns>返回异步任务</returns>
        public Task<int> Cook()
        {
            return Task.Run<int>(() =>
            {
                //休息间隔时间
                Thread.Sleep(Constant.EatStep);
                //生产随机数
                int count = new Random(Guid.NewGuid().GetHashCode()).Next(9, 10);
                //锁 避免多线程争发
                lock (Program.objLock)
                {
                    //如果全体糕点师没有休息且当前糕点师也没有休息
                    if (!Program.IsStopCook && State)
                    {
                        //包子总数+
                        Program.TotalCount += count;
                        Libs.Logger.Cooker($"厨师:{ID},正常生产包子：{count}个");
                        //告诉这个惨景：我已经生产了这么多个包子。其他我不管
                        EventBus.Instance.Publish(new CookCakeEvent()
                        {
                            ID = ID,
                            Count = count
                        });
                    }
                    else
                    {
                        //不生产
                        return 0;
                    }
                }
                return count;
            });
        }
    }
}
