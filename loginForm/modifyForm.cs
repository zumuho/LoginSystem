using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sqlCommand;
using System.Security.Cryptography;

namespace loginForm
{
    public partial class modifyForm : Form
    {
        public modifyForm()
        {
            InitializeComponent();
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

        public bool rBtnAdminChecked;
        public bool rBtnEnginChecked;

        private void btnModify_Click(object sender, EventArgs e)
        {
            string userName = txtName.Text.Trim();                 //取出账号
            string userPassword = txtPassword.Text.Trim();         //取出密码
            string userNewPassword = txtNewPassword.Text.Trim();
            string checkPassword = txtCheckPassword.Text.Trim();

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] b = md5.ComputeHash(Encoding.Default.GetBytes(userPassword));
            
            List<ArrayList> dataList = new List<ArrayList>() ;

            string[] colName = { "userName", "userPassword" };
            string[] content = { userName, ToHexString(b) };


            byte[] b1 = md5.ComputeHash(Encoding.Default.GetBytes(userNewPassword));
            string[] colName1 = { "userPassword", "userName" };
            string[] content1 = { ToHexString(b1), userName };

            ArrayList str = new ArrayList { };

            DateTime loginTime = new DateTime();
            loginTime = DateTime.Now;
            bool logRecord = false;

            if (userName == "" || userPassword == "")
                MessageBox.Show("用户名或密码不能为空！");
            else if (sqlCom.sqlContainTab("master", "registerTable", colName, content)=="false")
                MessageBox.Show("用户名不存在或原密码错误！");
            else if (userNewPassword == "")
                MessageBox.Show("请输入新密码！");
            else if (checkPassword == "")
                MessageBox.Show("请确认新密码！");
            else if (userNewPassword != checkPassword)
                MessageBox.Show("两次输入的密码不一致！");
            else
            {
                logRecord = true;
                sqlCom.sqlUpdateTabContent("master", "registerTable", colName1, content1);
                MessageBox.Show("修改成功！");
                //要判断是管理员还是本人修改了密码
                if (rBtnAdminChecked)
                {
                    str = sqlCom.sqlSelectTabColTop("master", "loginTable", "userName", 1);
                    ArrayList logRecData = new ArrayList() { loginTime, str[0], userName, "modify password", "NULL", logRecord };
                    dataList = new List<ArrayList>() { logRecData };
                }
                if (rBtnEnginChecked)
                {
                    ArrayList logRecData = new ArrayList() { loginTime, userName, userName, "modify password", "NULL", logRecord };
                    dataList = new List<ArrayList>() { logRecData };
                }
                sqlCom.sqlInsertTabCol("master", "logRecTable", dataList);
            }
        }
    }
}
