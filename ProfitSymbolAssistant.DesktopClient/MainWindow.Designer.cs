namespace ProfitSymbolAssistant.DesktopClient
{
    partial class MainWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.selectedSymbolsListBox = new System.Windows.Forms.ListBox();
            this.addSymGroupBox = new System.Windows.Forms.GroupBox();
            this.monthCodeMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.monthCodeLabel = new System.Windows.Forms.Label();
            this.selSymAddLabel = new System.Windows.Forms.Label();
            this.selExpDateLabel = new System.Windows.Forms.Label();
            this.symExpDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.addSymComboBox = new System.Windows.Forms.ComboBox();
            this.addSymButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.newSymDataGridView = new System.Windows.Forms.DataGridView();
            this.selSymGroupBox = new System.Windows.Forms.GroupBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.exportsGroupBox = new System.Windows.Forms.GroupBox();
            this.expSqlButton = new System.Windows.Forms.Button();
            this.addSymGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newSymDataGridView)).BeginInit();
            this.selSymGroupBox.SuspendLayout();
            this.exportsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectedSymbolsListBox
            // 
            this.selectedSymbolsListBox.FormattingEnabled = true;
            this.selectedSymbolsListBox.ItemHeight = 19;
            this.selectedSymbolsListBox.Location = new System.Drawing.Point(4, 22);
            this.selectedSymbolsListBox.Margin = new System.Windows.Forms.Padding(2);
            this.selectedSymbolsListBox.Name = "selectedSymbolsListBox";
            this.selectedSymbolsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.selectedSymbolsListBox.Size = new System.Drawing.Size(203, 232);
            this.selectedSymbolsListBox.TabIndex = 0;
            // 
            // addSymGroupBox
            // 
            this.addSymGroupBox.Controls.Add(this.monthCodeMaskedTextBox);
            this.addSymGroupBox.Controls.Add(this.monthCodeLabel);
            this.addSymGroupBox.Controls.Add(this.selSymAddLabel);
            this.addSymGroupBox.Controls.Add(this.selExpDateLabel);
            this.addSymGroupBox.Controls.Add(this.symExpDateTimePicker);
            this.addSymGroupBox.Controls.Add(this.addSymComboBox);
            this.addSymGroupBox.Controls.Add(this.addSymButton);
            this.addSymGroupBox.Location = new System.Drawing.Point(319, 10);
            this.addSymGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.addSymGroupBox.Name = "addSymGroupBox";
            this.addSymGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.addSymGroupBox.Size = new System.Drawing.Size(166, 253);
            this.addSymGroupBox.TabIndex = 2;
            this.addSymGroupBox.TabStop = false;
            this.addSymGroupBox.Text = "Add Symbol";
            // 
            // monthCodeMaskedTextBox
            // 
            this.monthCodeMaskedTextBox.BeepOnError = true;
            this.monthCodeMaskedTextBox.Location = new System.Drawing.Point(13, 142);
            this.monthCodeMaskedTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.monthCodeMaskedTextBox.Mask = "L09";
            this.monthCodeMaskedTextBox.Name = "monthCodeMaskedTextBox";
            this.monthCodeMaskedTextBox.Size = new System.Drawing.Size(32, 27);
            this.monthCodeMaskedTextBox.TabIndex = 10;
            // 
            // monthCodeLabel
            // 
            this.monthCodeLabel.AutoSize = true;
            this.monthCodeLabel.Location = new System.Drawing.Point(10, 120);
            this.monthCodeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.monthCodeLabel.Name = "monthCodeLabel";
            this.monthCodeLabel.Size = new System.Drawing.Size(130, 19);
            this.monthCodeLabel.TabIndex = 9;
            this.monthCodeLabel.Text = "Enter Month Code:";
            // 
            // selSymAddLabel
            // 
            this.selSymAddLabel.AutoSize = true;
            this.selSymAddLabel.Location = new System.Drawing.Point(10, 21);
            this.selSymAddLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selSymAddLabel.Name = "selSymAddLabel";
            this.selSymAddLabel.Size = new System.Drawing.Size(148, 19);
            this.selSymAddLabel.TabIndex = 8;
            this.selSymAddLabel.Text = "Select Symbol to Add:";
            // 
            // selExpDateLabel
            // 
            this.selExpDateLabel.AutoSize = true;
            this.selExpDateLabel.Location = new System.Drawing.Point(10, 71);
            this.selExpDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selExpDateLabel.Name = "selExpDateLabel";
            this.selExpDateLabel.Size = new System.Drawing.Size(138, 19);
            this.selExpDateLabel.TabIndex = 5;
            this.selExpDateLabel.Text = "Select Expirey Date:";
            // 
            // symExpDateTimePicker
            // 
            this.symExpDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.symExpDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.symExpDateTimePicker.Location = new System.Drawing.Point(13, 93);
            this.symExpDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.symExpDateTimePicker.Name = "symExpDateTimePicker";
            this.symExpDateTimePicker.Size = new System.Drawing.Size(130, 27);
            this.symExpDateTimePicker.TabIndex = 7;
            // 
            // addSymComboBox
            // 
            this.addSymComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addSymComboBox.FormattingEnabled = true;
            this.addSymComboBox.Location = new System.Drawing.Point(13, 43);
            this.addSymComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.addSymComboBox.Name = "addSymComboBox";
            this.addSymComboBox.Size = new System.Drawing.Size(138, 27);
            this.addSymComboBox.TabIndex = 6;
            // 
            // addSymButton
            // 
            this.addSymButton.Location = new System.Drawing.Point(73, 219);
            this.addSymButton.Margin = new System.Windows.Forms.Padding(2);
            this.addSymButton.Name = "addSymButton";
            this.addSymButton.Size = new System.Drawing.Size(88, 29);
            this.addSymButton.TabIndex = 5;
            this.addSymButton.Text = "Add";
            this.addSymButton.UseVisualStyleBackColor = true;
            this.addSymButton.Click += new System.EventHandler(this.addSymButton_Click);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(212, 219);
            this.generateButton.Margin = new System.Windows.Forms.Padding(2);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(88, 29);
            this.generateButton.TabIndex = 3;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(212, 186);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(88, 29);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // newSymDataGridView
            // 
            this.newSymDataGridView.AllowUserToAddRows = false;
            this.newSymDataGridView.AllowUserToDeleteRows = false;
            this.newSymDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.newSymDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.newSymDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.newSymDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.newSymDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.newSymDataGridView.Location = new System.Drawing.Point(10, 266);
            this.newSymDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.newSymDataGridView.Name = "newSymDataGridView";
            this.newSymDataGridView.ReadOnly = true;
            this.newSymDataGridView.RowHeadersVisible = false;
            this.newSymDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.newSymDataGridView.Size = new System.Drawing.Size(768, 270);
            this.newSymDataGridView.TabIndex = 5;
            // 
            // selSymGroupBox
            // 
            this.selSymGroupBox.Controls.Add(this.loadButton);
            this.selSymGroupBox.Controls.Add(this.saveButton);
            this.selSymGroupBox.Controls.Add(this.selectedSymbolsListBox);
            this.selSymGroupBox.Controls.Add(this.generateButton);
            this.selSymGroupBox.Controls.Add(this.deleteButton);
            this.selSymGroupBox.Location = new System.Drawing.Point(10, 10);
            this.selSymGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.selSymGroupBox.Name = "selSymGroupBox";
            this.selSymGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.selSymGroupBox.Size = new System.Drawing.Size(305, 255);
            this.selSymGroupBox.TabIndex = 6;
            this.selSymGroupBox.TabStop = false;
            this.selSymGroupBox.Text = "Selected Symbols";
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(212, 76);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(88, 29);
            this.loadButton.TabIndex = 6;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(212, 41);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(88, 29);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // exportsGroupBox
            // 
            this.exportsGroupBox.Controls.Add(this.expSqlButton);
            this.exportsGroupBox.Location = new System.Drawing.Point(491, 152);
            this.exportsGroupBox.Name = "exportsGroupBox";
            this.exportsGroupBox.Size = new System.Drawing.Size(188, 111);
            this.exportsGroupBox.TabIndex = 7;
            this.exportsGroupBox.TabStop = false;
            this.exportsGroupBox.Text = "Exports";
            // 
            // expSqlButton
            // 
            this.expSqlButton.Location = new System.Drawing.Point(6, 77);
            this.expSqlButton.Name = "expSqlButton";
            this.expSqlButton.Size = new System.Drawing.Size(176, 29);
            this.expSqlButton.TabIndex = 0;
            this.expSqlButton.Text = "Generate SQL script";
            this.expSqlButton.UseVisualStyleBackColor = true;
            this.expSqlButton.Click += new System.EventHandler(this.expSqlButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 546);
            this.Controls.Add(this.exportsGroupBox);
            this.Controls.Add(this.selSymGroupBox);
            this.Controls.Add(this.newSymDataGridView);
            this.Controls.Add(this.addSymGroupBox);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.Text = "ProfitSymbolAssistant";
            this.addSymGroupBox.ResumeLayout(false);
            this.addSymGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newSymDataGridView)).EndInit();
            this.selSymGroupBox.ResumeLayout(false);
            this.exportsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox selectedSymbolsListBox;
        private System.Windows.Forms.GroupBox addSymGroupBox;
        private System.Windows.Forms.Label monthCodeLabel;
        private System.Windows.Forms.Label selSymAddLabel;
        private System.Windows.Forms.Label selExpDateLabel;
        private System.Windows.Forms.DateTimePicker symExpDateTimePicker;
        private System.Windows.Forms.ComboBox addSymComboBox;
        private System.Windows.Forms.Button addSymButton;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.MaskedTextBox monthCodeMaskedTextBox;
        private System.Windows.Forms.DataGridView newSymDataGridView;
        private System.Windows.Forms.GroupBox selSymGroupBox;
        private System.Windows.Forms.GroupBox exportsGroupBox;
        private System.Windows.Forms.Button expSqlButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
    }
}

