using Demo.Libs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
namespace Demo.Domain
{
    /// <summary>
    /// 糕点师生产糕点的事实触发的事件处理器
    /// </summary>
    [HandlesAsynchronously]
    public class CookCakeHandler : IEventHandler<CookCakeEvent>
    {
        public void Handle(CookCakeEvent evt)
        {
            lock (Program.objLock)
            {
                if (Program.TotalCount >= 20)
                {
                    if (Program.IsOverWorker && !Program.IsStopCook)
                    {
                        var cooker = Program.cookers.SingleOrDefault(o => o.ID == evt.ID);
                        cooker.State = false;
                        Program.IsOverWorker = false;
                        Logger.StopOne($"被遗弃的糕点师：{cooker.ID}已经停止工作。");
                    }
                    else
                    {
                        Program.IsOverWorker = true;
                        if (!Program.IsStopCook)
                        {
                            Logger.Relax($"糕点师全员休假三秒钟...");
                            Program.IsStopCook = true;
                            //定时器
                            System.Timers.Timer ts = new System.Timers.Timer(Constant.CookerRelexStep);
                            ts.Enabled = true;
                            ts.AutoReset = false;
                            ts.Elapsed += Ts_Disposed;
                        }
                    }
                }
                else if (Program.IsOverWorker)
                {
                    Program.IsOverWorker = false;
                }
            }
        }

        private void Ts_Disposed(object sender, EventArgs e)
        {
            //锁
            lock (Program.objLock)
            {
                Program.IsStopCook = false;
                Logger.Relax("休息了三秒了！厨师们出来接客咯！");
            }
        }
    }
}
