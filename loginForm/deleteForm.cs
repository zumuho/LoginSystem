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
            ArrayList str = new ArrayList { };
            string userName = txtName.Text.Trim();
            string[] colName = { "userName" };
            string[] content = { userName };            
            List<ArrayList> dataList = new List<ArrayList>();

            DateTime loginTime = new DateTime();
            loginTime = DateTime.Now;
            bool logRecord = false;

            if (userName == "")
                MessageBox.Show("用户名不能为空！");
            else if (sqlCom.sqlContainTab("master", "registerTable", colName, content)=="false")
                MessageBox.Show("用户名不存在！");
            else
            {
                logRecord = true;
                sqlCom.sqlDeleteTabRow("master", "registerTable", "userName", userName);
                MessageBox.Show("删除成功！");

                str = sqlCom.sqlSelectTabColTop("master", "loginTable", "userName",1);
                ArrayList logRecData = new ArrayList() { loginTime, str[0], userName, "delete userAccount", "NULL", logRecord };
                dataList = new List<ArrayList>() { logRecData };
                sqlCom.sqlInsertTabCol("master", "logRecTable", dataList);
            }
        }
    }
}
