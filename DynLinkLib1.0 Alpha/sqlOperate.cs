using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SQLOperate
{
    public class sqlOperate
    {
        public static string dataSource;

        public static SqlConnection sqlCon(string databaseName)
        {
            string conStr = string.Format
                ("Data Source={0};Initial Catalog={1};Integrated Security=True;",
                dataSource, databaseName);
            SqlConnection con = new SqlConnection(conStr);
            return con;
        }

        public static string sqlIsContains(string databaseName, string tabName, string[] colName, string[] value)
        {
            string str;
            string str1;
            int count;
            SqlConnection con = null;
            try
            {
                con = sqlCon(databaseName);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                count = colName.Length - 1;
                str = "";
                str1 = "";
                for (int i = 0; i < count; i++)
                {
                    str = str + string.Format("{0},", colName[i]);
                    str1 = str1 + string.Format("{0}='{1}' AND ", colName[i], value[i]);
                }
                str = str + colName[count];
                str1 = str1 + string.Format("{0}='{1}'", colName[count], value[count]);
                cmd.CommandText = string.Format
                    ("SELECT {0} FROM {1} WHERE ({2})",
                    str, tabName, str1);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr.HasRows)
                {
                    con.Dispose();
                    return "true";
                }
                else
                {
                    con.Dispose();
                    return "false";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                if(con != null)
                    con.Dispose();
            }
        }

        public static string sqlRecord(string databaseName, string tabName, List<ArrayList> values)
        {
            string str = "";
            SqlConnection con = null;
            try
            {
                con = sqlCon(databaseName);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                foreach (ArrayList element in values)
                {
                    str = "";//每次作循环之前都应该把str赋空字符
                    for (int i = 0; i < element.Count - 1; i++)
                    {
                        if (element[i] is string && element[i].ToString() != "NULL")
                            str = str + string.Format("'{0}',", element[i].ToString());
                        else if (element[i] is DateTime)
                            str = str + string.Format("'{0}',", element[i].ToString());
                        else if (element[i] is bool)
                            str = str + string.Format("'{0}',", element[i].ToString());
                        else
                            str = str + string.Format("{0},", element[i].ToString());
                    }
                    if (element[element.Count - 1] is string && element[element.Count - 1].ToString() != "NULL")
                        str = str + string.Format("'{0}'", element[element.Count - 1].ToString());
                    else if (element[element.Count - 1] is DateTime)
                        str = str + string.Format("'{0}'", element[element.Count - 1].ToString());
                    else if (element[element.Count - 1] is bool)
                        str = str + string.Format("'{0}'", element[element.Count - 1].ToString());
                    else
                        str = str + string.Format("{0}", element[element.Count - 1].ToString());

                    cmd.CommandText = string.Format
                        ("INSERT INTO {0} VALUES ({1})", tabName, str);
                    //Console.WriteLine(cmd.CommandText);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                con.Dispose();
                return "success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        public static ArrayList sqlGetList(string databaseName, string tabName, string colName)
        {
            //用string[]则必须初始化且指定大小很麻烦
            ArrayList str = new ArrayList { };
            SqlConnection con = null;
            try
            {
                con = sqlCon(databaseName);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = string.Format
                    ("SELECT DISTINCT {0} FROM {1}",
                    colName, tabName);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    str.Add(sdr[0].ToString());
                }
                con.Dispose();
                return str;
            }
            catch (Exception e)
            {
                return new ArrayList { e.Message };
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        public static DataTable sqlGetRecord(string databaseName, string tabName, string[] colName, string[] value)
        {
            SqlConnection con = null;
            try
            {
                con = sqlCon(databaseName);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = string.Format
                    ("SELECT * FROM {0} WHERE {1} BETWEEN '{2}' AND '{3}' AND {4}='{5}'"
                    , tabName, colName[0], value[0], value[1], colName[1], value[2]);
                cmd.CommandType = CommandType.Text;
                DataTable dataTab = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dataTab);
                con.Dispose();
                return dataTab;
            }
            catch (Exception e)
            {
                return new DataTable(e.Message);
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        public static string sqlGetAdminName(string databaseName, string tabName, string[] colName, string value)
        {
            string str = "";
            SqlConnection con = null;
            try
            {
                con = sqlCon(databaseName);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = string.Format
                    ("SELECT {0} FROM {1} WHERE ({2}='{3}')",
                    colName[0], tabName, colName[1], value);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                str = sdr[0].ToString();
                con.Dispose();
                return str;
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        public static string sqlUpdateTab(string databaseName, string tabName, string[] colName, string[] value)
        {
            string str;
            string str1;
            int count;
            SqlConnection con = null;
            try
            {
                con = sqlCon(databaseName);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                count = colName.Length - 1;
                str = "";
                str1 = string.Format("{0}='{1}'", colName[0], value[0]);
                for (int i = 1; i < count; i++)
                {
                    str = str + string.Format("{0}='{1}',", colName[i], value[i]);
                }
                str = str + string.Format("{0}='{1}'", colName[count], value[count]);
                cmd.CommandText = string.Format
                ("UPDATE {0} SET {1} WHERE {2}", tabName, str, str1);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Dispose();
                return "success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        public static string sqlDelTabRow(string databaseName, string tabName, string colName, string value)
        {
            SqlConnection con = null;
            try
            {
                con = sqlCon(databaseName);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = string.Format
                ("DELETE FROM {0} WHERE {1}='{2}'", tabName, colName, value);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Dispose();
                return "success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }
    }
}
