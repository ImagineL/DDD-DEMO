using Demo.Libs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
namespace Demo.Domain
{
    /// <summary>
    /// 吃货吃糕点的事实，会触发的事件处理器
    /// </summary>
    [HandlesAsynchronously]
    public class EatCakeHandler : IEventHandler<EatCakeEvent>
    {
        public void Handle(EatCakeEvent evt)
        {

            lock (Program.objLock)
            {
                if (Program.TotalCount <= 0)
                {
                    if (Program.IsStopService)
                    {
                        var cooker = Program.cookers.Where(p => !p.State).FirstOrDefault();
                        if (cooker != null)
                        {
                            cooker.State = true;
                            Logger.StartOne($"厨师：{cooker.ID} 恢复制作包子啦。年假都不够你们吃！");
                            Program.IsStopService = false;
                        }
                    }
                    else
                    {
                        Program.IsStopService = true;
                        Logger.Stop("店里没包子了，大家伙等我一会");
                        //定时器，停止所有吃货，在三秒内的吃包子行为
                        System.Timers.Timer ts = new System.Timers.Timer(Constant.ServerStopStep);
                        ts.Enabled = true;
                        ts.AutoReset = false;
                        ts.Elapsed += Ts_Disposed;
                    }
                }
                else if (Program.IsStopService)
                {
                    Program.IsStopService = true;
                }
            }
        }

        private void Ts_Disposed(object sender, EventArgs e)
        {
            Logger.Stop("宵禁解除！大家可以开始吃了！");
            //锁
            lock (Program.objLock)
            {
                if (Program.TotalCount <= 10)
                {
                    var cooker = Program.cookers.Where(p => !p.State).FirstOrDefault();
                    if (cooker != null)
                    {
                        cooker.State = true;
                        Logger.StartOne($"厨师：{cooker.ID} 恢复制作包子啦。年假都不够你们吃！");
                        Program.IsStopService = false;
                    }
                    else if(Program.IsStopCook)
                    {
                        Logger.Stop($"厨师因为刚才生产太多，去休息了");
                    }
                    else
                    {
                        Logger.Stop($"所有厨师都上了！还不够吃");
                    }
                }
                Program.IsStopService = false;
            }
        }
    }
}
