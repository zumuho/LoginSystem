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
    public partial class loginForm : Form
    {
        public loginForm()
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            adminForm adminForm = new adminForm();//声明不能放在判断句内！！！
            DateTime loginTime = new DateTime();
            loginTime = DateTime.Now;
            bool logRecord;
            string userName = txtName.Text.Trim();                 //取出账号
            string userPassword = txtPassword.Text.Trim();         //取出密码
            string[] colName = { "userName", "userPassword" };

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] b = md5.ComputeHash(Encoding.Default.GetBytes(userPassword));

            string[] content = { userName, ToHexString(b) };
            string tableName;
            if (rBtnAdmin.Checked)
                tableName = "loginTable";
            else if (rBtnEngin.Checked)
                tableName = "registerTable";
            else
                tableName = "";

            if (userName == "" || userPassword == "")
                MessageBox.Show("用户名或密码不能为空！");
            else if (tableName == "")
                MessageBox.Show("请选择管理员或工程师");
            else
            {
                if (sqlCom.sqlContainTab("master", tableName, colName, content)=="true")
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

                ArrayList logRecData = new ArrayList() { loginTime, userName, "NULL", "login", "NULL", logRecord };
                List<ArrayList> dataList = new List<ArrayList>() { logRecData };
                sqlCom.sqlInsertTabCol("master", "logRecTable", dataList);
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
