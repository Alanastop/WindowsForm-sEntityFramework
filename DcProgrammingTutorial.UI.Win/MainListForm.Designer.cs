namespace DcProgrammingTutorial.UI.Win 
{
    using DcProgrammingTutorial.Lib.Model.Persistent;

    partial class MainListForm
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.createButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.calculateTaxButton = new System.Windows.Forms.Button();
            this.taxValueTextBox = new System.Windows.Forms.TextBox();
            this.calculateAverageBalanceButton = new System.Windows.Forms.Button();
            this.averageBalanceValueTextBox = new System.Windows.Forms.TextBox();
            this.Refresh = new System.Windows.Forms.Button();
            this.entitiesComboBox = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(206, 24);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(852, 349);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DocumentDataGridViewCellMouseDoubleClick);
            // 
            // createButton
            // 
            this.createButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createButton.AutoEllipsis = true;
            this.createButton.AutoSize = true;
            this.createButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.createButton.Location = new System.Drawing.Point(33, 372);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(48, 36);
            this.createButton.TabIndex = 1;
            this.createButton.Text = "\r\nCreate";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.CreateButtonClick);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.AutoSize = true;
            this.deleteButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.deleteButton.Location = new System.Drawing.Point(1007, 426);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(51, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete ";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButtonClick);
            // 
            // calculateTaxButton
            // 
            this.calculateTaxButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.calculateTaxButton.AutoEllipsis = true;
            this.calculateTaxButton.AutoSize = true;
            this.calculateTaxButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.calculateTaxButton.Location = new System.Drawing.Point(33, 428);
            this.calculateTaxButton.Name = "calculateTaxButton";
            this.calculateTaxButton.Size = new System.Drawing.Size(35, 23);
            this.calculateTaxButton.TabIndex = 4;
            this.calculateTaxButton.Text = "Tax";
            this.calculateTaxButton.UseVisualStyleBackColor = true;
            this.calculateTaxButton.Click += new System.EventHandler(this.CalculateTaxButtonClick);
            // 
            // taxValueTextBox
            // 
            this.taxValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.taxValueTextBox.Location = new System.Drawing.Point(182, 429);
            this.taxValueTextBox.Name = "taxValueTextBox";
            this.taxValueTextBox.ReadOnly = true;
            this.taxValueTextBox.Size = new System.Drawing.Size(129, 20);
            this.taxValueTextBox.TabIndex = 5;
            // 
            // calculateAverageBalanceButton
            // 
            this.calculateAverageBalanceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.calculateAverageBalanceButton.AutoEllipsis = true;
            this.calculateAverageBalanceButton.AutoSize = true;
            this.calculateAverageBalanceButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.calculateAverageBalanceButton.Location = new System.Drawing.Point(33, 466);
            this.calculateAverageBalanceButton.Name = "calculateAverageBalanceButton";
            this.calculateAverageBalanceButton.Size = new System.Drawing.Size(99, 23);
            this.calculateAverageBalanceButton.TabIndex = 6;
            this.calculateAverageBalanceButton.Text = "Average Balance";
            this.calculateAverageBalanceButton.UseVisualStyleBackColor = true;
            this.calculateAverageBalanceButton.Click += new System.EventHandler(this.CalculateAverageBalanceButtonClick);
            // 
            // averageBalanceValueTextBox
            // 
            this.averageBalanceValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.averageBalanceValueTextBox.Location = new System.Drawing.Point(182, 467);
            this.averageBalanceValueTextBox.Name = "averageBalanceValueTextBox";
            this.averageBalanceValueTextBox.ReadOnly = true;
            this.averageBalanceValueTextBox.Size = new System.Drawing.Size(129, 20);
            this.averageBalanceValueTextBox.TabIndex = 7;
            // 
            // Refresh
            // 
            this.Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Refresh.AutoSize = true;
            this.Refresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Refresh.Location = new System.Drawing.Point(1004, 464);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(54, 23);
            this.Refresh.TabIndex = 10;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.RefreshClick);
            // 
            // entitiesComboBox
            // 
            this.entitiesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.entitiesComboBox.FormattingEnabled = true;
            this.entitiesComboBox.Items.AddRange(new object[] {
            "Companies",
            "Documents"});
            this.entitiesComboBox.Location = new System.Drawing.Point(12, 62);
            this.entitiesComboBox.Name = "entitiesComboBox";
            this.entitiesComboBox.Size = new System.Drawing.Size(121, 21);
            this.entitiesComboBox.TabIndex = 11;
            this.entitiesComboBox.SelectedIndexChanged += new System.EventHandler(this.EntitiesComboBoxSelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1070, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // MainListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 504);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.entitiesComboBox);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.averageBalanceValueTextBox);
            this.Controls.Add(this.calculateAverageBalanceButton);
            this.Controls.Add(this.taxValueTextBox);
            this.Controls.Add(this.calculateTaxButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.dataGridView);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainListForm";
            this.Text = "MainListForm";
            this.Load += new System.EventHandler(this.MainListFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button calculateTaxButton;
        private System.Windows.Forms.TextBox taxValueTextBox;
        private System.Windows.Forms.Button calculateAverageBalanceButton;
        private System.Windows.Forms.TextBox averageBalanceValueTextBox;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.ComboBox entitiesComboBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
    }
}

