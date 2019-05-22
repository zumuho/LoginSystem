using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace loginForm
{
    public partial class adminForm : Form
    {
        public adminForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            registerForm registerForm = new registerForm();
            registerForm.Show();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            modifyForm modifyForm = new modifyForm();
            modifyForm.rBtnAdminChecked = true;
            modifyForm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteForm deleteForm = new deleteForm();
            deleteForm.Show();
        }

        private void btnQueryLog_Click(object sender, EventArgs e)
        {
            queryLogForm queryLogForm = new queryLogForm();
            queryLogForm.Show();
        }
    }
}
