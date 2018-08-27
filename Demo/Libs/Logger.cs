using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Libs
{
    /// <summary>
    /// 极其简单的美观Console显示类
    /// </summary>
    public class Logger
    {
        static readonly string _Formart = "当前时间：{0},包子数量：{1}，消息：{2}";
        /// <summary>
        /// 厨师专用色号
        /// </summary>
        /// <param name="Msg"></param>
        public static void Cooker(string Msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Formart(Msg));
        }
        /// <summary>
        /// 消费者专用色号
        /// </summary>
        /// <param name="Msg"></param>
        public static void Eat(string Msg)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Formart(Msg));
        }
        /// <summary>
        /// 厨师群体放假/恢复色号
        /// </summary>
        /// <param name="Msg"></param>
        public static void Relax(string Msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(Formart(Msg));
        }
        /// <summary>
        /// 被吃到关门的事件色号
        /// </summary>
        /// <param name="Msg"></param>
        public static void Stop(string Msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Formart(Msg));
        }
        /// <summary>
        /// 单独炒掉一个厨师的色号
        /// </summary>
        /// <param name="Msg"></param>
        public static void StopOne(string Msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Formart(Msg));
        }
        /// <summary>
        /// 单独恢复一个厨师的色号--同拆掉同色
        /// </summary>
        /// <param name="Msg"></param>
        public static void StartOne(string Msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Formart(Msg));
        }
        private static string Formart(string Msg)
        {
            return string.Format(_Formart, DateTime.Now.ToString("HH:mm:ss"), Program.TotalCount, Msg);
        }
    }
}
