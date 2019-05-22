using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using SQLOperate;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace testSqlCom
{
    class Program
    {
        static void Main(string[] args)
        {           
            //注意对表进行sqlModifyTabCol()修改都要先刷新一次看下修改成啥样了
            //否则把列名改成了类型名，然后不知道结果一直犯逻辑错误
            //数据库都得刷新一下才能看到更改后的效果！！！！我感觉VS优化不好
            //sqlOperate.dataSource = @"DESKTOP-O6555DI\SQLEXPRESS";
            int i,a=1,b=0;
            string str;
            str = testTryBlock(out i,a,b);
            //DateTime date = new DateTime(2008, 5, 1, 8, 30, 52);
            //ArrayList dataArrary = new ArrayList { date, "NULL", "NULL", "Five", true };
            //List<ArrayList> dataList = new List<ArrayList>();
            //for (int i = 0; i < 5; i++)
            //{
            //    dataList.Add(dataArrary);
            //}
            //Console.WriteLine(dataArrary);
            //sqlOperate.sqlRecord("master", "logRecTab", dataList);

            //Stopwatch stopwatch = new Stopwatch();            
            //stopwatch.Start(); //  开始监视代码运行时间
            ////  需要测试的代码            
            //stopwatch.Stop(); //  停止监视
            //TimeSpan timespan = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
            //Console.WriteLine(timespan);
            //stopwatch.Reset();            
            //Console.WriteLine(date.TimeOfDay.ToString());

            //sqlOperate.sqlGetList("master", "logRecTab", "userName"); 

            //MD5 md5 = new MD5CryptoServiceProvider();
            //byte[] b = md5.ComputeHash(Encoding.Default.GetBytes("123456789"));
            //Console.WriteLine(ToHexString(b));
            Console.ReadKey();
        }

        static char[] hexDigits = {
        '0', '1', '2', '3', '4', '5', '6', '7',
        '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};

        public static string ToHexString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length * 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                int b = bytes[i];
                chars[i * 2] = hexDigits[b >> 4];
                chars[i * 2 + 1] = hexDigits[b & 0xF];
            }
            return new string(chars);
        }

        static string testTryBlock(out int i,int a,int b)
        {
            try
            {
                i = a / b;
                return i.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                i = 1;
            }
        }
    }
}//最后删除}在打上}让整体的程序重新排列一下
