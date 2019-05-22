using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SQLOperate;
using System.Security.Cryptography;

namespace loginForm
{
    public partial class registerForm : Form
    {
        public registerForm()
        {
            InitializeComponent();
        }

        #region 加密
        static char[] hexDigits = 
        { '0', '1', '2', '3', '4', '5', '6', '7',
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
        #endregion 加密

        private void btnRegister_Click(object sender, EventArgs e)
        {
            sqlOperate.dataSource = @"DESKTOP-O6555DI\SQLEXPRESS";
            string str;
            string userName = txtName.Text.Trim();                 //取出账号
            string userPassword = txtPassword.Text.Trim();         //取出密码
            string checkPassword = txtCheckPassword.Text.Trim();

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] b = md5.ComputeHash(Encoding.Default.GetBytes(userPassword));

            ArrayList dataArray = new ArrayList() { userName, ToHexString(b) ,"Engin"};
            List<ArrayList> dataList = new List<ArrayList>() { dataArray };

            string[] colName = { "userName" };
            string[] content = { userName };

            DateTime registerTime = DateTime.Now;
            bool logRecord = false;

            if (userName == "" || userPassword == "")
                MessageBox.Show("用户名或密码不能为空！");
            else if (checkPassword == "")
                MessageBox.Show("请确认密码！");
            else if (userPassword != checkPassword)
                MessageBox.Show("两次输入的密码不一致！");
            else if (sqlOperate.sqlIsContains("master", "registerTab", colName, content) == "true")
                MessageBox.Show("用户名已存在！");
            else
            {
                logRecord = true;
                sqlOperate.sqlRecord("master", "registerTab", dataList);
                MessageBox.Show("注册成功！");
            }
            str = sqlOperate.sqlGetAdminName("master", "registerTab", new string[] { "userName", "rank" }, "Admin");
            ArrayList logRecData = new ArrayList() { registerTime, str, "register userAccount", userName, logRecord };
            dataList = new List<ArrayList>() { logRecData };
            sqlOperate.sqlRecord("master", "logRecTab", dataList);
        }
    }
}