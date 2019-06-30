using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TestModel;

namespace ConsoleApp1.LinqPratice
{
    class ReversePartice
    {
        public static void Main()
        {

            //How do you reverse a given string in place?
            // n = 100000
            var randomString = GetRandomString(100000);
            
            testFunc(() => reverseString(randomString), "reverseString: O(n)");
            
            testFunc(() => reverseStringCase2(randomString), "Use_reverseStringCase2: O(n/2)");
            
            testFunc(() => reverseStringCase3(randomString), "Use_stringReverse");


            Console.WriteLine("Brake point.");
        }

        #region reverse

        /// <summary>
        /// 暴力轉換, O(n)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string reverseString(string s)
        {
            string result = string.Empty;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                result += s[i];
            }

            return result;
        }

        /// <summary>
        /// 頭尾的文字互相對調位置, O(n/2)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string reverseStringCase2(string s)
        {
            char[] c = s.ToArray();

            for (int i = 0, j = s.Length - 1; i < c.Length / 2; i++, j--)
            {
                var temp = c[i];
                c[i] = c[j];
                c[j] = temp;
            }

            return string.Join("", c);
        }

        /// <summary>
        /// C# string原生字串反轉, 複雜度??? 應該會是效能最好的
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string reverseStringCase3(string s)
        {
            return string.Join("", s.Reverse());
        }

        /// <summary>
        /// Get Seed Data
        /// </summary>
        /// <param name="length">字串長度</param>
        /// <returns></returns>
        public static string GetRandomString(int length)
        {
            var str = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var next = new Random(Guid.NewGuid().GetHashCode());
            var builder = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                builder.Append(str[next.Next(0, str.Length)]);
            }
            return builder.ToString();
        }

        #endregion

        /// <summary>
        /// 測試Action的執行時間
        /// </summary>
        /// <param name="action">函式</param>
        /// <param name="methodName">函式名稱</param>
        static void testFunc(Action action, string methodName)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            action();
            sw.Stop();
            Console.WriteLine("Duration: {0:N0}ms,TestName:{1}", sw.ElapsedMilliseconds, methodName);
        }
    }
}
