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
    public partial class loginForm : Form
    {
        public loginForm()
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            sqlOperate.dataSource = @"DESKTOP-O6555DI\SQLEXPRESS";
            adminForm adminForm = new adminForm();//声明不能放在判断句内！！！
            DateTime loginTime = DateTime.Now;
            bool logRecord;
            string userName = txtName.Text.Trim();                 //取出账号
            string userPassword = txtPassword.Text.Trim();         //取出密码
            string[] colName = { "userName", "userPassword", "rank" };
            string[] content;

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] b = md5.ComputeHash(Encoding.Default.GetBytes(userPassword));
           
            if (rBtnAdmin.Checked)
                content = new string[]{ userName, ToHexString(b) ,"Admin"};
            else if (rBtnEngin.Checked)
                content = new string[] { userName, ToHexString(b), "Engin" };
            else
                content = null;

            if (userName == "" || userPassword == "")
                MessageBox.Show("用户名或密码不能为空！");
            else if (content == null)
                MessageBox.Show("请选择管理员或工程师");
            else
            {
                if (sqlOperate.sqlIsContains("master", "registerTab", colName, content) == "true")
                {
                    logRecord = true;
                    MessageBox.Show("登陆成功！");
                    if (rBtnAdmin.Checked)
                        adminForm.Show();
                }
                else
                {
                    logRecord = false;
                    MessageBox.Show("用户名或密码错误！");
                }

                ArrayList logRecData = new ArrayList() { loginTime, userName, "login", userName, logRecord };
                List<ArrayList> dataList = new List<ArrayList>() { logRecData };
                sqlOperate.sqlRecord("master", "logRecTab", dataList);
            }
        }

        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            modifyForm modifyForm = new modifyForm();
            if (!rBtnAdmin.Checked && !rBtnEngin.Checked)
                MessageBox.Show("请选择管理员或工程师");
            else
            {
                modifyForm.Show();
                modifyForm.rBtnAdminChecked = rBtnAdmin.Checked;
                modifyForm.rBtnEnginChecked = rBtnEngin.Checked;
            }
        }
    }
}
