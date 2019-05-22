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
    public partial class queryLogForm : Form
    {
        public queryLogForm()
        {
            InitializeComponent();
        }
        private void queryLogForm_Load(object sender, EventArgs e)
        {
            ArrayList str = sqlCom.sqlSelectTabColDist("master", "logRecTable", "userName");
            foreach (string element in str)
                if (element.ToString() != "")   //若是空数据则不加入txtUserList
                txtUserList.Items.Add(element);
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {            
            DateTime startTime = txtStartTime.Value;
            DateTime endTime = txtEndTime.Value;
            string txtList = txtUserList.Text;
            string[] colName = { "time", "userName" };
            string[] content = { startTime.ToString(), endTime.ToString(), txtList };
            DataTable list = sqlCom.sqlSelectTabColRange("master", "logRecTable", colName, content);
            dataGridView.DataSource = null;  //先清空数据表的内容再读入新的数据
            //dataGridView.Rows.Clear();
            dataGridView.DataSource = list;
        }
    }
}
