namespace loginForm
{
    partial class queryLogForm
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
            this.txtStartTime = new System.Windows.Forms.DateTimePicker();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEndTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStartTime
            // 
            this.txtStartTime.CalendarFont = new System.Drawing.Font("宋体", 12F);
            this.txtStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.txtStartTime.Font = new System.Drawing.Font("宋体", 12F);
            this.txtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtStartTime.Location = new System.Drawing.Point(25, 101);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(190, 26);
            this.txtStartTime.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("宋体", 10F);
            this.btnQuery.Location = new System.Drawing.Point(375, 31);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 40);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(22, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "查询时间";
            // 
            // txtEndTime
            // 
            this.txtEndTime.CalendarFont = new System.Drawing.Font("宋体", 12F);
            this.txtEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.txtEndTime.Font = new System.Drawing.Font("宋体", 12F);
            this.txtEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtEndTime.Location = new System.Drawing.Point(261, 101);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(189, 26);
            this.txtEndTime.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(227, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "至";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(22, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "查询结果";
            // 
            // txtUserList
            // 
            this.txtUserList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtUserList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtUserList.Font = new System.Drawing.Font("宋体", 12F);
            this.txtUserList.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUserList.FormattingEnabled = true;
            this.txtUserList.Location = new System.Drawing.Point(116, 31);
            this.txtUserList.Name = "txtUserList";
            this.txtUserList.Size = new System.Drawing.Size(167, 24);
            this.txtUserList.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(22, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "查询用户";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(25, 175);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(425, 183);
            this.dataGridView.TabIndex = 5;
            // 
            // queryLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 384);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.txtUserList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.txtEndTime);
            this.Controls.Add(this.txtStartTime);
            this.Name = "queryLogForm";
            this.Text = "查询操作日志界面";
            this.Load += new System.EventHandler(this.queryLogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker txtStartTime;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtEndTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox txtUserList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}