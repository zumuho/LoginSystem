using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using sqlCommand;
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
            sqlCom.dataSource = "DESKTOP-O6555DI";

            //string[] colName = { "userName", "userPassword"};
            //string[] type = { "varchar", "varchar" };
            //sqlCom.sqlCreateTab("master", "loginTable", colName, type);
            //sqlCom.sqlDropTab("master", "loginTable");

            //string[] colName = { "userName", "userPassword" };
            //string[] type = { "varchar", "varchar" };
            //sqlCom.sqlCreateTab("master", "registerTable", colName, type);
            //sqlCom.sqlDropTab("master", "registerTable");

            string[] colName = { "userName", "userPassword" };
            string[] content = { "aBc", "123" };
            if (sqlCom.sqlContainTab("master", "registerTable", colName, content)=="true")
                Console.WriteLine("登陆成功");
            else
                Console.WriteLine("用户名或密码错误！");

            //sqlCom.sqlRenameTab("master", "操作日志表", "logRecTable");

            //DateTime date = new DateTime(2008, 5, 1, 8, 30, 52);
            //ArrayList dataArrary = new ArrayList { date, "Tow", "3", "4", "Five", true };
            //List<ArrayList> dataList = new List<ArrayList>();
            //for (int i = 0; i < 1; i++)
            //{
            //    dataList.Add(dataArrary);
            //}
            //sqlCom.sqlInsertTabCol("master", "logRecTable", dataList);

            //Stopwatch stopwatch = new Stopwatch();            
            //stopwatch.Start(); //  开始监视代码运行时间
            ////  需要测试的代码            
            //stopwatch.Stop(); //  停止监视
            //TimeSpan timespan = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
            //Console.WriteLine(timespan);
            //stopwatch.Reset();            
            //Console.WriteLine(date.TimeOfDay.ToString());

            //ArrayList str = sqlCom.sqlSelectTabColTop("master", "registerTable", "userName",1);
            //sqlCom.sqlDeleteTabRow("master", "loginTable", "userName","abcd");
            //string[] colName={"userPassword","userName"};
            //string[] content={"asdfefg","AAA"};
            //sqlCom.sqlUpdateTabContent("master", "registerTable", colName, content);

            //ArrayList str = sqlCom.sqlSelectTabColDist("master", "registerTable", "userName");
            //foreach (string element in str)
            //    Console.WriteLine(element); 
            //string[] colName = { "time", "operateobject" };
            //string[] content = { "2019/1/1", "2019/1/9" ,"abc"};
            //List<string[]> list = sqlCom.sqlSelectTabColRange("master", "logRecTable", colName, content);
            //foreach (string[] element in list)
            //    foreach(string subelement in element)
            //        Console.WriteLine(subelement);

            //string count ;            
            //int i1 = 0,i2=1,i3=2,i4=3;
            //ArrayList array = new ArrayList();
            //List<ArrayList> list = new List<ArrayList> { };
            //while (true)
            //{
            //    count = (++i1).ToString();
            //    array.Add(count);
            //    count = (++i2).ToString();
            //    array.Add(count);
            //    count = (++i3).ToString();
            //    array.Add(count);
            //    count = (++i4).ToString();
            //    array.Add(count);
            //    list.Add(array);
            //    Console.WriteLine(list[i1-1].ToString());
            //}

            
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
    }
}//最后删除}在打上}让整体的程序重新排列一下
