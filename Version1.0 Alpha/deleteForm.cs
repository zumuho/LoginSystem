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

namespace loginForm
{
    public partial class deleteForm : Form
    {
        public deleteForm()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            sqlOperate.dataSource = @"DESKTOP-O6555DI\SQLEXPRESS";
            string str;
            string userName = txtName.Text.Trim();
            string[] colName = { "userName" };
            string[] content = { userName };
            List<ArrayList> dataList;

            DateTime deleteTime = DateTime.Now;            
            bool logRecord = false;

            if (userName == "")
                MessageBox.Show("用户名不能为空！");
            else if (sqlOperate.sqlIsContains("master", "registerTab", colName, content) == "false")
                MessageBox.Show("用户名不存在！");
            else
            {
                logRecord = true;
                sqlOperate.sqlDelTabRow("master", "registerTab", "userName", userName);
                MessageBox.Show("删除成功！");
            }
            str = sqlOperate.sqlGetAdminName("master", "registerTab", new string[] { "userName", "rank" }, "Admin");
            ArrayList logRecData = new ArrayList() { deleteTime, str, "delete userAccount", userName, logRecord };
            dataList = new List<ArrayList>() { logRecData };
            sqlOperate.sqlRecord("master", "logRecTab", dataList);
        }
    }
}
