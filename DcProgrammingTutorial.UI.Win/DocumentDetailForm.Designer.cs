namespace DcProgrammingTutorial.UI.Win
{
    partial class DocumentDetailForm
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
            this.companyNameLabel = new System.Windows.Forms.Label();
            this.documentNameValueTextBox = new System.Windows.Forms.TextBox();
            this.documentCodeValueTextBox = new System.Windows.Forms.TextBox();
            this.documentIdValueTextBox = new System.Windows.Forms.TextBox();
            this.documentIdLabel = new System.Windows.Forms.Label();
            this.documentCodeLabel = new System.Windows.Forms.Label();
            this.documentNameLabel = new System.Windows.Forms.Label();
            this.documentBalanceLabel = new System.Windows.Forms.Label();
            this.documentCreationDateLabel = new System.Windows.Forms.Label();
            this.closeDocumentDetailFormButton = new System.Windows.Forms.Button();
            this.calculateTaxButton = new System.Windows.Forms.Button();
            this.taxValueTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.documentCreationDateValueTextBox = new System.Windows.Forms.DateTimePicker();
            this.documentBalanceValueTextBox = new System.Windows.Forms.NumericUpDown();
            this.warningLabel = new System.Windows.Forms.Label();
            this.linkDocumentToCompanyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.documentBalanceValueTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // companyNameLabel
            // 
            this.companyNameLabel.AutoSize = true;
            this.companyNameLabel.Location = new System.Drawing.Point(36, 20);
            this.companyNameLabel.Name = "companyNameLabel";
            this.companyNameLabel.Size = new System.Drawing.Size(82, 13);
            this.companyNameLabel.TabIndex = 1;
            this.companyNameLabel.Text = "Company Name";
            // 
            // documentNameValueTextBox
            // 
            this.documentNameValueTextBox.BackColor = System.Drawing.Color.Red;
            this.documentNameValueTextBox.Location = new System.Drawing.Point(179, 91);
            this.documentNameValueTextBox.Name = "documentNameValueTextBox";
            this.documentNameValueTextBox.Size = new System.Drawing.Size(110, 20);
            this.documentNameValueTextBox.TabIndex = 2;
            // 
            // documentCodeValueTextBox
            // 
            this.documentCodeValueTextBox.Location = new System.Drawing.Point(179, 65);
            this.documentCodeValueTextBox.Name = "documentCodeValueTextBox";
            this.documentCodeValueTextBox.Size = new System.Drawing.Size(110, 20);
            this.documentCodeValueTextBox.TabIndex = 4;
            // 
            // documentIdValueTextBox
            // 
            this.documentIdValueTextBox.Location = new System.Drawing.Point(179, 39);
            this.documentIdValueTextBox.Name = "documentIdValueTextBox";
            this.documentIdValueTextBox.ReadOnly = true;
            this.documentIdValueTextBox.Size = new System.Drawing.Size(110, 20);
            this.documentIdValueTextBox.TabIndex = 6;
            // 
            // documentIdLabel
            // 
            this.documentIdLabel.AutoSize = true;
            this.documentIdLabel.Location = new System.Drawing.Point(36, 45);
            this.documentIdLabel.Name = "documentIdLabel";
            this.documentIdLabel.Size = new System.Drawing.Size(68, 13);
            this.documentIdLabel.TabIndex = 7;
            this.documentIdLabel.Text = "Document Id";
            // 
            // documentCodeLabel
            // 
            this.documentCodeLabel.AutoSize = true;
            this.documentCodeLabel.Location = new System.Drawing.Point(36, 71);
            this.documentCodeLabel.Name = "documentCodeLabel";
            this.documentCodeLabel.Size = new System.Drawing.Size(84, 13);
            this.documentCodeLabel.TabIndex = 8;
            this.documentCodeLabel.Text = "Document Code";
            // 
            // documentNameLabel
            // 
            this.documentNameLabel.AutoSize = true;
            this.documentNameLabel.Location = new System.Drawing.Point(31, 97);
            this.documentNameLabel.Name = "documentNameLabel";
            this.documentNameLabel.Size = new System.Drawing.Size(87, 13);
            this.documentNameLabel.TabIndex = 9;
            this.documentNameLabel.Text = "Document Name";
            // 
            // documentBalanceLabel
            // 
            this.documentBalanceLabel.AutoSize = true;
            this.documentBalanceLabel.Location = new System.Drawing.Point(25, 126);
            this.documentBalanceLabel.Name = "documentBalanceLabel";
            this.documentBalanceLabel.Size = new System.Drawing.Size(98, 13);
            this.documentBalanceLabel.TabIndex = 10;
            this.documentBalanceLabel.Text = "Document Balance";
            // 
            // documentCreationDateLabel
            // 
            this.documentCreationDateLabel.AutoSize = true;
            this.documentCreationDateLabel.Location = new System.Drawing.Point(12, 156);
            this.documentCreationDateLabel.Name = "documentCreationDateLabel";
            this.documentCreationDateLabel.Size = new System.Drawing.Size(124, 13);
            this.documentCreationDateLabel.TabIndex = 11;
            this.documentCreationDateLabel.Text = "Document Creation Date";
            // 
            // closeDocumentDetailFormButton
            // 
            this.closeDocumentDetailFormButton.Location = new System.Drawing.Point(211, 307);
            this.closeDocumentDetailFormButton.Name = "closeDocumentDetailFormButton";
            this.closeDocumentDetailFormButton.Size = new System.Drawing.Size(75, 23);
            this.closeDocumentDetailFormButton.TabIndex = 12;
            this.closeDocumentDetailFormButton.Text = "Close";
            this.closeDocumentDetailFormButton.UseVisualStyleBackColor = true;
            this.closeDocumentDetailFormButton.Click += new System.EventHandler(this.CloseDocumentDetailFormButtonClick);
            // 
            // calculateTaxButton
            // 
            this.calculateTaxButton.Location = new System.Drawing.Point(39, 246);
            this.calculateTaxButton.Name = "calculateTaxButton";
            this.calculateTaxButton.Size = new System.Drawing.Size(75, 23);
            this.calculateTaxButton.TabIndex = 13;
            this.calculateTaxButton.Text = "Tax";
            this.calculateTaxButton.UseVisualStyleBackColor = true;
            this.calculateTaxButton.Click += new System.EventHandler(this.CalculateTaxButtonClick);
            // 
            // taxValueTextBox
            // 
            this.taxValueTextBox.Location = new System.Drawing.Point(176, 248);
            this.taxValueTextBox.Name = "taxValueTextBox";
            this.taxValueTextBox.ReadOnly = true;
            this.taxValueTextBox.Size = new System.Drawing.Size(110, 20);
            this.taxValueTextBox.TabIndex = 14;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(39, 307);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = "Save All";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(179, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(110, 21);
            this.comboBox1.TabIndex = 16;
            // 
            // documentCreationDateValueTextBox
            // 
            this.documentCreationDateValueTextBox.Enabled = false;
            this.documentCreationDateValueTextBox.Location = new System.Drawing.Point(153, 149);
            this.documentCreationDateValueTextBox.Name = "documentCreationDateValueTextBox";
            this.documentCreationDateValueTextBox.Size = new System.Drawing.Size(181, 20);
            this.documentCreationDateValueTextBox.TabIndex = 17;
            // 
            // documentBalanceValueTextBox
            // 
            this.documentBalanceValueTextBox.DecimalPlaces = 2;
            this.documentBalanceValueTextBox.Location = new System.Drawing.Point(179, 118);
            this.documentBalanceValueTextBox.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.documentBalanceValueTextBox.Name = "documentBalanceValueTextBox";
            this.documentBalanceValueTextBox.Size = new System.Drawing.Size(110, 20);
            this.documentBalanceValueTextBox.TabIndex = 19;
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Location = new System.Drawing.Point(69, 9);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(0, 13);
            this.warningLabel.TabIndex = 20;
            // 
            // linkDocumentToCompanyButton
            // 
            this.linkDocumentToCompanyButton.Location = new System.Drawing.Point(72, 190);
            this.linkDocumentToCompanyButton.Name = "linkDocumentToCompanyButton";
            this.linkDocumentToCompanyButton.Size = new System.Drawing.Size(159, 23);
            this.linkDocumentToCompanyButton.TabIndex = 21;
            this.linkDocumentToCompanyButton.Text = "Link To Company";
            this.linkDocumentToCompanyButton.UseVisualStyleBackColor = true;
            this.linkDocumentToCompanyButton.Click += new System.EventHandler(this.LinkDocumentToCompanyButtonClick);
            // 
            // DocumentDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 342);
            this.Controls.Add(this.linkDocumentToCompanyButton);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.documentBalanceValueTextBox);
            this.Controls.Add(this.documentCreationDateValueTextBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.taxValueTextBox);
            this.Controls.Add(this.calculateTaxButton);
            this.Controls.Add(this.closeDocumentDetailFormButton);
            this.Controls.Add(this.documentCreationDateLabel);
            this.Controls.Add(this.documentBalanceLabel);
            this.Controls.Add(this.documentNameLabel);
            this.Controls.Add(this.documentCodeLabel);
            this.Controls.Add(this.documentIdLabel);
            this.Controls.Add(this.documentIdValueTextBox);
            this.Controls.Add(this.documentCodeValueTextBox);
            this.Controls.Add(this.documentNameValueTextBox);
            this.Controls.Add(this.companyNameLabel);
            this.Name = "DocumentDetailForm";
            this.Text = "Document Details";
            ((System.ComponentModel.ISupportInitialize)(this.documentBalanceValueTextBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label companyNameLabel;
        private System.Windows.Forms.TextBox documentNameValueTextBox;
        private System.Windows.Forms.TextBox documentCodeValueTextBox;
        private System.Windows.Forms.TextBox documentIdValueTextBox;
        private System.Windows.Forms.Label documentIdLabel;
        private System.Windows.Forms.Label documentCodeLabel;
        private System.Windows.Forms.Label documentNameLabel;
        private System.Windows.Forms.Label documentBalanceLabel;
        private System.Windows.Forms.Label documentCreationDateLabel;
        private System.Windows.Forms.Button closeDocumentDetailFormButton;
        private System.Windows.Forms.Button calculateTaxButton;
        private System.Windows.Forms.TextBox taxValueTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker documentCreationDateValueTextBox;
        private System.Windows.Forms.NumericUpDown documentBalanceValueTextBox;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Button linkDocumentToCompanyButton;
    }
}