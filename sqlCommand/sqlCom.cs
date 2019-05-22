using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace sqlCommand
{
    public class sqlCom
    {
        /*必须是public类型才能在其他地方使用
          用静态函数不用实例化*/
        public static string dataSource;

        //连接指定数据库        
        public static SqlConnection sqlCon(string conStr)
        {   
            string str;
            str = "Data Source=" + dataSource + ";Initial Catalog=" + conStr + ";Integrated Security=True;";
            SqlConnection conn = new SqlConnection(str);
            return conn; 
        }

        //给指定数据库新建表
        //type为列的数据类型
        //colName和type的数组元素一一对应
        public static string sqlCreateTab(string conStr, string tabName, string[] colName, string[] type)
        {
            string str;
            int count;
            SqlConnection conn = null;
            try
            {
                conn = sqlCon(conStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                count = colName.Length - 1;
                str = "";
                for (int i = 0; i < count; i++)
                {
                    str = str + colName[i] + " " + type[i] + ",";
                }
                str = str + colName[count] + " " + type[count];
                cmd.CommandText = "create table " + tabName + "(" + str + ");";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Dispose();
                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                if(conn != null)
                    conn.Dispose();
            }
        }

        //给指定数据库删除表
        public static string sqlDropTab(string conStr, string tabName)
        {
            SqlConnection conn = null;
            try
            {
                conn = sqlCon(conStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;                
                cmd.CommandText = "drop table " + tabName + ";";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Dispose();
                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                if (conn != null)
                    conn.Dispose();
            }
        }

        /*给指定数据库修改表*/

        //修改指定数据库的指定表的表名
        public static string sqlRenameTab(string conStr, string tabName, string tabNameMod)
        {
            SqlConnection conn = null;
            try
            {
                conn = sqlCon(conStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "exec" + " sp_rename " + "'" + tabName + "'" + "," + "'" + tabNameMod + "'" + ";";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Dispose();
                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                if (conn != null)
                    conn.Dispose();
            }
        }

        //给指定数据库的指定表添加列
        public static string sqlAddTabCol(string conStr, string tabName, string colName, string type)
        {
            SqlConnection conn = null;
            try
            {
                conn = sqlCon(conStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "alter table " + tabName + " add " + colName + " " + type + ";";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Dispose();
                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                if (conn != null)
                    conn.Dispose();
            }
        }

        //给指定数据库的指定表删除列
        //每个表必须有一列，所以无法删除表中的唯一列
        public static string sqlDropTabCol(string conStr, string tabName, string colName)
        {
            SqlConnection conn = null;
            try
            {
                conn = sqlCon(conStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "alter table " + tabName + " drop " + " column " + colName + ";";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Dispose();
                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                if (conn != null)
                    conn.Dispose();
            }
        }

        //给指定数据库的指定表修改列
        //typeMod为修改后的列的数据类型
        //colNameMod为修改后的列的名字
        public static string sqlModifyTabCol(string conStr, string tabName, string colName, string typeMod, string colNameMod)
        {
            SqlConnection conn = null;
            try
            {
                conn = sqlCon(conStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                if (typeMod != "[]")
                {
                    cmd.CommandText = "alter table " + tabName + " alter " + " column " + colName + " " + typeMod + ";";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                if (colNameMod != "[]")
                {
                    cmd.CommandText = "exec" + " sp_rename " + "'" + tabName + "." + colName + "'" + "," + "'" + colNameMod + "'" + ";";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                conn.Dispose();
                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                if (conn != null)
                    conn.Dispose();
            }
        }

        //给指定数据库的指定表插入数据
        //List<ArrayList> dataValue表示这个List集合中的元素类型是ArrayList
        //ArrayList则是每一行要插入的数据
        //需要插入多少行则在List这个集合中放入相应的ArrayList元素
        //ArrayList中的元素个数需要和tabName表中的列数一致
        //且每个位置上的元素类型和每一列的数据类型一致
        public static string sqlInsertTabCol(string conStr, string tabName, List<ArrayList> dataValue)
        {
            string str = "";
            SqlConnection conn = null;
            try
            {
                conn = sqlCon(conStr);
                conn.Open();             
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ArrayList element in dataValue)
                {
                    str = "";
                    for (int i = 0; i < element.Count - 1; i++)
                    {                        
                        if (element[i] is string)
                            str = str + "'" + element[i].ToString() + "'" + ",";
                        else if (element[i] is DateTime)
                            str = str + "'" + element[i].ToString() + "'" + ",";
                        else if (element[i] is bool)
                            str = str + "'" + element[i].ToString() + "'" + ",";
                        else
                            str = str + element[i].ToString() + ",";
                    }
                    if (element[element.Count - 1] is string)
                        str = str + "'" + element[element.Count - 1].ToString() + "'";
                    else if (element[element.Count - 1] is DateTime)
                        str = str + "'" + element[element.Count - 1].ToString() + "'";
                    else if (element[element.Count - 1] is bool)
                        str = str + "'" + element[element.Count - 1].ToString() + "'";
                    else
                        str = str + element[element.Count - 1].ToString();

                    cmd.CommandText = "insert into " + tabName + " values (" + str + ");";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                conn.Dispose();
                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                if (conn != null)
                    conn.Dispose();
            }
        }

        /*操作指定数据库的指定表的数据*/

        //核对是否存在指定数据库的指定表的数据
        //content[i]表示想要核对的对应列colName[i]中的内容是否存在
        public static string sqlContainTab(string conStr, string tabName, string[] colName, string[] content)
        {
            string str;
            string str1;
            int count;
            SqlConnection conn = null;
            try
            {
                conn = sqlCon(conStr);
                conn.Open();             
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                count = colName.Length - 1;
                str = "";
                str1 = "";
                for (int i = 0; i < count; i++)
                {
                    str = str + colName[i] + ",";
                    str1 = str1 + colName[i] + "='" + content[i] + "' and ";
                }
                str = str + colName[count];
                str1 = str1 + colName[count] + "='" + content[count] + "'";

                cmd.CommandText = "select " + str + " from " + tabName + " where " + str1 + ";";
                bool flag=false;
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    foreach(string element in content)
                        if (element == sdr[0].ToString())
                        flag=true;  
                }
                conn.Dispose();
                if (flag)
                    return "true";
                else
                    return "false";                
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                if (conn != null)
                    conn.Dispose();
            }
        }

        //读取指定数据库的指定表的指定列的前topNum行或所有行的内容
        public static ArrayList sqlSelectTabColTop(string conStr, string tabName, string colName, int topNum, out string message)
        {
            ArrayList str = new ArrayList { };
            SqlConnection conn = null;
            try
            {
                conn = sqlCon(conStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                if (topNum == 0)
                    cmd.CommandText =
                "select " + colName + " from " + tabName + ";";
                else
                    cmd.CommandText =
                    "select top(" + topNum.ToString() + ") " + colName + " from " + tabName + ";";
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    str.Add(sdr[0].ToString()); 
                }
                conn.Dispose();
                message = "Done";
                return str;                
            }
            catch(Exception e)
            {
                message = e.Message;
                return new ArrayList {};                
            }
            finally
            {
                if (conn != null)
                    conn.Dispose();
            }
        }

        //读取指定数据库的指定表的指定列的不同值
        public static ArrayList sqlSelectTabColDist(string conStr, string tabName, string colName,out string message)
        {
            ArrayList str = new ArrayList { };
            SqlConnection conn = null;
            try
            {
                conn = sqlCon(conStr);
                conn.Open();  
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText =
                "select distinct " + colName + " from " + tabName;
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    str.Add(sdr[0].ToString());
                }
                conn.Dispose();
                message = "Done";
                return str;
            }
            catch (Exception e)
            {
                message = e.Message;
                return new ArrayList { };
            }
            finally
            {
                if (conn != null)
                    conn.Dispose();
            }
        }

        //读取指定数据库的指定表的指定列的内容
        public static DataTable sqlSelectTabColRange(string conStr, string tabName, string[] colName, string[] content, out string message)
        {
            SqlConnection conn = null;
            try
            {
                conn = sqlCon(conStr);
                conn.Open();           
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;          
                    cmd.CommandText =
                    "select * from "+ tabName + " where " +  colName[0] + 
                    " between '" + content[0] + "' and '" + content[1] + 
                        "' and " + colName[1] + "='" + content[2] + "'";
                cmd.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);
                conn.Dispose();
                message = "Done";
                return dt;
            }
            catch (Exception e)
            {
                message = e.Message;
                return new DataTable { };
            }
            finally
            {
                if (conn != null)
                    conn.Dispose();
            }
        }       

        //删除指定数据库的指定表的指定行
        public static string sqlDeleteTabRow(string conStr, string tabName, string colName, string content)
        {
            SqlConnection conn = null;
            try
            {
                conn = sqlCon(conStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText =
                "delete from " + tabName + " where " + colName + "=" + "'" + content + "'";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Dispose();
                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                if (conn != null)
                    conn.Dispose();
            }
        }

        //更新指定数据库的指定表的指定行列内容
        public static string sqlUpdateTabContent(string conStr, string tabName, string[] colName, string[] content)
        {
            string str;
            string str1;
            int count;
            SqlConnection conn = null;
            try
            {
                conn = sqlCon(conStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;                
                count = colName.Length - 2;
                str = "";
                str1 = "";
                for (int i = 0; i < count; i++)
                {
                    str1 = str1 + colName[i] + "='" + content[i] + "',";
                }
                str = str + colName[count + 1] + "='" + content[count + 1] + "'";
                str1 = str1 + colName[count] + "='" + content[count] + "'";

                cmd.CommandText =
                "update " + tabName + " set " + str1 +
                " where " + str + " collate Chinese_PRC_CS_AS;";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Dispose();
                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                if (conn != null)
                    conn.Dispose();
            }
        }
    }
}