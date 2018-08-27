using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Domain
{
    /// <summary>
    /// 业务固定值
    /// </summary>
    public class Constant
    {
        /// <summary>
        /// 制造包子的间隔时长
        /// </summary>
        public const int CookStep = 1000;
        /// <summary>
        /// 吃包子的间隔时长
        /// </summary>
        public const int EatStep = 1000;
        /// <summary>
        /// 厨师休息间隔时长
        /// </summary>
        public const int CookerRelexStep = 3000;
        /// <summary>
        /// 停止服务间隔时长
        /// </summary>
        public const int ServerStopStep = 3000;
    }
}
