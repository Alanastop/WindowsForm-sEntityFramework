namespace DcProgrammingTutorial.UI.Win
{
    partial class CompanyDetailForm
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
            this.components = new System.ComponentModel.Container();
            this.companyCreationDateLabel = new System.Windows.Forms.Label();
            this.companyCodeLabel = new System.Windows.Forms.Label();
            this.companyIdLabel = new System.Windows.Forms.Label();
            this.companyNameLabel = new System.Windows.Forms.Label();
            this.companyCreationDateValueTextBox = new System.Windows.Forms.DateTimePicker();
            this.companyCodeValueTextBox = new System.Windows.Forms.TextBox();
            this.companyIdValueTextBox = new System.Windows.Forms.TextBox();
            this.companyNameValueTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CheckColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saveButton = new System.Windows.Forms.Button();
            this.warningLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.companyTaxIdLabel = new System.Windows.Forms.Label();
            this.companyTaxIdValueMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.unlinkButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // companyCreationDateLabel
            // 
            this.companyCreationDateLabel.AutoSize = true;
            this.companyCreationDateLabel.Location = new System.Drawing.Point(36, 139);
            this.companyCreationDateLabel.Name = "companyCreationDateLabel";
            this.companyCreationDateLabel.Size = new System.Drawing.Size(119, 13);
            this.companyCreationDateLabel.TabIndex = 17;
            this.companyCreationDateLabel.Text = "Company Creation Date";
            // 
            // companyCodeLabel
            // 
            this.companyCodeLabel.AutoSize = true;
            this.companyCodeLabel.Location = new System.Drawing.Point(36, 84);
            this.companyCodeLabel.Name = "companyCodeLabel";
            this.companyCodeLabel.Size = new System.Drawing.Size(79, 13);
            this.companyCodeLabel.TabIndex = 14;
            this.companyCodeLabel.Text = "Company Code";
            // 
            // companyIdLabel
            // 
            this.companyIdLabel.AutoSize = true;
            this.companyIdLabel.Location = new System.Drawing.Point(36, 110);
            this.companyIdLabel.Name = "companyIdLabel";
            this.companyIdLabel.Size = new System.Drawing.Size(63, 13);
            this.companyIdLabel.TabIndex = 13;
            this.companyIdLabel.Text = "Company Id";
            // 
            // companyNameLabel
            // 
            this.companyNameLabel.AutoSize = true;
            this.companyNameLabel.Location = new System.Drawing.Point(36, 34);
            this.companyNameLabel.Name = "companyNameLabel";
            this.companyNameLabel.Size = new System.Drawing.Size(82, 13);
            this.companyNameLabel.TabIndex = 12;
            this.companyNameLabel.Text = "Company Name";
            // 
            // companyCreationDateValueTextBox
            // 
            this.companyCreationDateValueTextBox.Enabled = false;
            this.companyCreationDateValueTextBox.Location = new System.Drawing.Point(211, 139);
            this.companyCreationDateValueTextBox.Name = "companyCreationDateValueTextBox";
            this.companyCreationDateValueTextBox.Size = new System.Drawing.Size(181, 20);
            this.companyCreationDateValueTextBox.TabIndex = 24;
            // 
            // companyCodeValueTextBox
            // 
            this.companyCodeValueTextBox.Location = new System.Drawing.Point(256, 81);
            this.companyCodeValueTextBox.Name = "companyCodeValueTextBox";
            this.companyCodeValueTextBox.Size = new System.Drawing.Size(110, 20);
            this.companyCodeValueTextBox.TabIndex = 22;
            // 
            // companyIdValueTextBox
            // 
            this.companyIdValueTextBox.Enabled = false;
            this.companyIdValueTextBox.Location = new System.Drawing.Point(256, 55);
            this.companyIdValueTextBox.Name = "companyIdValueTextBox";
            this.companyIdValueTextBox.ReadOnly = true;
            this.companyIdValueTextBox.Size = new System.Drawing.Size(110, 20);
            this.companyIdValueTextBox.TabIndex = 21;
            // 
            // companyNameValueTextBox
            // 
            this.companyNameValueTextBox.BackColor = System.Drawing.Color.Red;
            this.companyNameValueTextBox.Location = new System.Drawing.Point(256, 31);
            this.companyNameValueTextBox.Name = "companyNameValueTextBox";
            this.companyNameValueTextBox.Size = new System.Drawing.Size(110, 20);
            this.companyNameValueTextBox.TabIndex = 20;
            this.companyNameValueTextBox.Validated += new System.EventHandler(this.CompanyNameValueTextBoxValidated);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckColumn,
            this.nameDataGridViewTextBoxColumn,
            this.codeDataGridViewTextBoxColumn,
            this.balanceDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.documentBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 247);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(535, 207);
            this.dataGridView1.TabIndex = 25;
            // 
            // CheckColumn
            // 
            this.CheckColumn.HeaderText = "Select";
            this.CheckColumn.Name = "CheckColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            // 
            // balanceDataGridViewTextBoxColumn
            // 
            this.balanceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.balanceDataGridViewTextBoxColumn.DataPropertyName = "Balance";
            this.balanceDataGridViewTextBoxColumn.HeaderText = "Balance";
            this.balanceDataGridViewTextBoxColumn.Name = "balanceDataGridViewTextBoxColumn";
            // 
            // documentBindingSource
            // 
            this.documentBindingSource.DataSource = typeof(DcProgrammingTutorial.Lib.Model.Persistent.Document);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(39, 188);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 26;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.BackColor = System.Drawing.Color.Red;
            this.warningLabel.Location = new System.Drawing.Point(177, 9);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(0, 13);
            this.warningLabel.TabIndex = 27;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(457, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Send Email";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SendEmailButtonClick);
            // 
            // companyTaxIdLabel
            // 
            this.companyTaxIdLabel.AutoSize = true;
            this.companyTaxIdLabel.Location = new System.Drawing.Point(36, 60);
            this.companyTaxIdLabel.Name = "companyTaxIdLabel";
            this.companyTaxIdLabel.Size = new System.Drawing.Size(84, 13);
            this.companyTaxIdLabel.TabIndex = 28;
            this.companyTaxIdLabel.Text = "Company Tax Id";
            // 
            // companyTaxIdValueMaskedTextBox
            // 
            this.companyTaxIdValueMaskedTextBox.BackColor = System.Drawing.Color.Red;
            this.companyTaxIdValueMaskedTextBox.BeepOnError = true;
            this.companyTaxIdValueMaskedTextBox.Location = new System.Drawing.Point(256, 57);
            this.companyTaxIdValueMaskedTextBox.Mask = "000000000";
            this.companyTaxIdValueMaskedTextBox.Name = "companyTaxIdValueMaskedTextBox";
            this.companyTaxIdValueMaskedTextBox.Size = new System.Drawing.Size(110, 20);
            this.companyTaxIdValueMaskedTextBox.TabIndex = 29;
            this.companyTaxIdValueMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.companyTaxIdValueMaskedTextBox.Validated += new System.EventHandler(this.CompanyTaxIdValueMaskedTextBoxValidated);
            // 
            // unlinkButton
            // 
            this.unlinkButton.Location = new System.Drawing.Point(230, 188);
            this.unlinkButton.Name = "unlinkButton";
            this.unlinkButton.Size = new System.Drawing.Size(111, 23);
            this.unlinkButton.TabIndex = 28;
            this.unlinkButton.Text = "Unlink Document";
            this.unlinkButton.UseVisualStyleBackColor = true;
            this.unlinkButton.Click += new System.EventHandler(this.UnlinkButtonClick);
            // 
            // CompanyDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 492);
            this.Controls.Add(this.unlinkButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.companyTaxIdValueMaskedTextBox);
            this.Controls.Add(this.companyTaxIdLabel);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.companyCreationDateValueTextBox);
            this.Controls.Add(this.companyCodeValueTextBox);
            this.Controls.Add(this.companyIdValueTextBox);
            this.Controls.Add(this.companyNameValueTextBox);
            this.Controls.Add(this.companyCreationDateLabel);
            this.Controls.Add(this.companyCodeLabel);
            this.Controls.Add(this.companyIdLabel);
            this.Controls.Add(this.companyNameLabel);
            this.Name = "CompanyDetailForm";
            this.Text = "CompanyDetailForm";
            this.Load += new System.EventHandler(this.CompanyDetailFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label companyCreationDateLabel;
        private System.Windows.Forms.Label companyCodeLabel;
        private System.Windows.Forms.Label companyIdLabel;
        private System.Windows.Forms.Label companyNameLabel;
        private System.Windows.Forms.DateTimePicker companyCreationDateValueTextBox;
        private System.Windows.Forms.TextBox companyCodeValueTextBox;
        private System.Windows.Forms.TextBox companyIdValueTextBox;
        private System.Windows.Forms.TextBox companyNameValueTextBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button unlinkButton;
        private System.Windows.Forms.BindingSource documentBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn balanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label companyTaxIdLabel;
        private System.Windows.Forms.MaskedTextBox companyTaxIdValueMaskedTextBox;
    }
}