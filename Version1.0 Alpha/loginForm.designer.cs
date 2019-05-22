namespace loginForm
{
    partial class loginForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnChangePwd = new System.Windows.Forms.Button();
            this.rBtnAdmin = new System.Windows.Forms.RadioButton();
            this.rBtnEngin = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(108, 31);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(157, 21);
            this.txtName.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(108, 73);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(157, 21);
            this.txtPassword.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(36, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(36, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码";
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("宋体", 10F);
            this.btnLogin.Location = new System.Drawing.Point(83, 124);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 31);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "登陆";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.Font = new System.Drawing.Font("宋体", 10F);
            this.btnChangePwd.Location = new System.Drawing.Point(234, 124);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(75, 31);
            this.btnChangePwd.TabIndex = 5;
            this.btnChangePwd.Text = "修改密码";
            this.btnChangePwd.UseVisualStyleBackColor = true;
            this.btnChangePwd.Click += new System.EventHandler(this.btnChangePwd_Click);
            // 
            // rBtnAdmin
            // 
            this.rBtnAdmin.AutoSize = true;
            this.rBtnAdmin.Font = new System.Drawing.Font("宋体", 10F);
            this.rBtnAdmin.Location = new System.Drawing.Point(294, 34);
            this.rBtnAdmin.Name = "rBtnAdmin";
            this.rBtnAdmin.Size = new System.Drawing.Size(67, 18);
            this.rBtnAdmin.TabIndex = 2;
            this.rBtnAdmin.TabStop = true;
            this.rBtnAdmin.Text = "管理员";
            this.rBtnAdmin.UseVisualStyleBackColor = true;
            // 
            // rBtnEngin
            // 
            this.rBtnEngin.AutoSize = true;
            this.rBtnEngin.Font = new System.Drawing.Font("宋体", 10F);
            this.rBtnEngin.Location = new System.Drawing.Point(294, 76);
            this.rBtnEngin.Name = "rBtnEngin";
            this.rBtnEngin.Size = new System.Drawing.Size(67, 18);
            this.rBtnEngin.TabIndex = 3;
            this.rBtnEngin.TabStop = true;
            this.rBtnEngin.Text = "工程师";
            this.rBtnEngin.UseVisualStyleBackColor = true;
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 180);
            this.Controls.Add(this.rBtnEngin);
            this.Controls.Add(this.rBtnAdmin);
            this.Controls.Add(this.btnChangePwd);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtName);
            this.Name = "loginForm";
            this.Text = "登陆界面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnChangePwd;
        private System.Windows.Forms.RadioButton rBtnAdmin;
        private System.Windows.Forms.RadioButton rBtnEngin;
    }
}

