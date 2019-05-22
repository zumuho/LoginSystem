namespace loginForm
{
    partial class adminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnQueryLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("宋体", 10F);
            this.btnRegister.Location = new System.Drawing.Point(95, 23);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(99, 35);
            this.btnRegister.TabIndex = 0;
            this.btnRegister.Text = "注册用户";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnModify
            // 
            this.btnModify.Font = new System.Drawing.Font("宋体", 10F);
            this.btnModify.Location = new System.Drawing.Point(95, 136);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(99, 35);
            this.btnModify.TabIndex = 2;
            this.btnModify.Text = "修改密码";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("宋体", 10F);
            this.btnDelete.Location = new System.Drawing.Point(95, 82);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 35);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除用户";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnQueryLog
            // 
            this.btnQueryLog.Font = new System.Drawing.Font("宋体", 10F);
            this.btnQueryLog.Location = new System.Drawing.Point(85, 192);
            this.btnQueryLog.Name = "btnQueryLog";
            this.btnQueryLog.Size = new System.Drawing.Size(121, 35);
            this.btnQueryLog.TabIndex = 3;
            this.btnQueryLog.Text = "查询操作日志";
            this.btnQueryLog.UseVisualStyleBackColor = true;
            this.btnQueryLog.Click += new System.EventHandler(this.btnQueryLog_Click);
            // 
            // adminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnQueryLog);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnRegister);
            this.Name = "adminForm";
            this.Text = "管理员界面";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnQueryLog;
    }
}