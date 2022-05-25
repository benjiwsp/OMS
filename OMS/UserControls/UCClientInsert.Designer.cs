
namespace OMS.UserControls
{
    partial class UCClientInsert
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ClientListCbox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchClientBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.radSeparator1 = new Telerik.WinControls.UI.RadSeparator();
            this.newClientBtn = new System.Windows.Forms.Button();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ClientPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.clientNameTxt = new System.Windows.Forms.TextBox();
            this.ClientCodeTxt = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DisplayNameLbl = new System.Windows.Forms.Label();
            this.ClientTypeCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TelTxt = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AddressTxt = new System.Windows.Forms.MaskedTextBox();
            this.ContactTxt = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CreditTxt = new System.Windows.Forms.MaskedTextBox();
            this.importFromExcelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).BeginInit();
            this.panel1.SuspendLayout();
            this.ClientPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientListCbox
            // 
            this.ClientListCbox.FormattingEnabled = true;
            this.ClientListCbox.Location = new System.Drawing.Point(105, 31);
            this.ClientListCbox.Name = "ClientListCbox";
            this.ClientListCbox.Size = new System.Drawing.Size(318, 21);
            this.ClientListCbox.TabIndex = 0;
            this.ClientListCbox.SelectedIndexChanged += new System.EventHandler(this.ClientListCbox_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(8, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.Size = new System.Drawing.Size(415, 819);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "代號";
            this.Column2.Name = "Column2";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "客戶";
            this.Column1.Name = "Column1";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "貨款";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "更改";
            this.Column4.Name = "Column4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "客戶類別";
            // 
            // SearchClientBtn
            // 
            this.SearchClientBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.SearchClientBtn.Location = new System.Drawing.Point(429, 31);
            this.SearchClientBtn.Name = "SearchClientBtn";
            this.SearchClientBtn.Size = new System.Drawing.Size(145, 64);
            this.SearchClientBtn.TabIndex = 4;
            this.SearchClientBtn.Text = "搜查";
            this.SearchClientBtn.UseVisualStyleBackColor = true;
            this.SearchClientBtn.Click += new System.EventHandler(this.SearchClientBtn_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Maroon;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(429, 813);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 64);
            this.button2.TabIndex = 5;
            this.button2.Text = "刪除";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button3.Location = new System.Drawing.Point(429, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 64);
            this.button3.TabIndex = 6;
            this.button3.Text = "更改";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // radSeparator1
            // 
            this.radSeparator1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radSeparator1.Location = new System.Drawing.Point(580, 0);
            this.radSeparator1.Name = "radSeparator1";
            this.radSeparator1.Orientation = System.Windows.Forms.Orientation.Vertical;
            // 
            // 
            // 
            this.radSeparator1.RootElement.ControlBounds = new System.Drawing.Rectangle(580, 0, 200, 4);
            this.radSeparator1.Size = new System.Drawing.Size(48, 1035);
            this.radSeparator1.TabIndex = 7;
            // 
            // newClientBtn
            // 
            this.newClientBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.newClientBtn.Location = new System.Drawing.Point(634, 31);
            this.newClientBtn.Name = "newClientBtn";
            this.newClientBtn.Size = new System.Drawing.Size(145, 64);
            this.newClientBtn.TabIndex = 8;
            this.newClientBtn.Text = "新客戶";
            this.newClientBtn.UseVisualStyleBackColor = true;
            this.newClientBtn.Click += new System.EventHandler(this.newClientBtn_Click);
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.ConfirmBtn.Location = new System.Drawing.Point(1484, 813);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(267, 64);
            this.ConfirmBtn.TabIndex = 9;
            this.ConfirmBtn.Text = "確定";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.ClearBtn.Location = new System.Drawing.Point(1323, 813);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(145, 64);
            this.ClearBtn.TabIndex = 8;
            this.ClearBtn.Text = "清除";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ClientPanel);
            this.panel1.Location = new System.Drawing.Point(801, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 776);
            this.panel1.TabIndex = 11;
            // 
            // ClientPanel
            // 
            this.ClientPanel.ColumnCount = 5;
            this.ClientPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.31579F));
            this.ClientPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.57895F));
            this.ClientPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ClientPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.684211F));
            this.ClientPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.73684F));
            this.ClientPanel.Controls.Add(this.label4, 0, 3);
            this.ClientPanel.Controls.Add(this.label2, 0, 0);
            this.ClientPanel.Controls.Add(this.clientNameTxt, 1, 0);
            this.ClientPanel.Controls.Add(this.ClientCodeTxt, 1, 1);
            this.ClientPanel.Controls.Add(this.label3, 0, 1);
            this.ClientPanel.Controls.Add(this.DisplayNameLbl, 0, 2);
            this.ClientPanel.Controls.Add(this.ClientTypeCombo, 1, 3);
            this.ClientPanel.Controls.Add(this.label6, 0, 4);
            this.ClientPanel.Controls.Add(this.TelTxt, 1, 4);
            this.ClientPanel.Controls.Add(this.label7, 0, 5);
            this.ClientPanel.Controls.Add(this.AddressTxt, 1, 5);
            this.ClientPanel.Controls.Add(this.ContactTxt, 4, 4);
            this.ClientPanel.Controls.Add(this.label8, 3, 4);
            this.ClientPanel.Controls.Add(this.label5, 0, 7);
            this.ClientPanel.Controls.Add(this.CreditTxt, 1, 7);
            this.ClientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientPanel.Enabled = false;
            this.ClientPanel.Location = new System.Drawing.Point(0, 0);
            this.ClientPanel.Name = "ClientPanel";
            this.ClientPanel.RowCount = 10;
            this.ClientPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.510309F));
            this.ClientPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.510309F));
            this.ClientPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.608248F));
            this.ClientPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.768041F));
            this.ClientPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.283505F));
            this.ClientPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.701031F));
            this.ClientPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.865979F));
            this.ClientPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.381444F));
            this.ClientPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.19072F));
            this.ClientPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ClientPanel.Size = new System.Drawing.Size(950, 776);
            this.ClientPanel.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 37);
            this.label4.TabIndex = 6;
            this.label4.Text = "客戶類別:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 35);
            this.label2.TabIndex = 0;
            this.label2.Text = "客戶名稱:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clientNameTxt
            // 
            this.ClientPanel.SetColumnSpan(this.clientNameTxt, 2);
            this.clientNameTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientNameTxt.Location = new System.Drawing.Point(100, 3);
            this.clientNameTxt.Name = "clientNameTxt";
            this.clientNameTxt.Size = new System.Drawing.Size(463, 29);
            this.clientNameTxt.TabIndex = 1;
            this.clientNameTxt.TextChanged += new System.EventHandler(this.clientNameTxt_TextChanged);
            // 
            // ClientCodeTxt
            // 
            this.ClientCodeTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientCodeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientCodeTxt.Location = new System.Drawing.Point(100, 38);
            this.ClientCodeTxt.Name = "ClientCodeTxt";
            this.ClientCodeTxt.Size = new System.Drawing.Size(274, 29);
            this.ClientCodeTxt.TabIndex = 2;
            this.ClientCodeTxt.TextChanged += new System.EventHandler(this.ClientCodeTxt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 35);
            this.label3.TabIndex = 3;
            this.label3.Text = "客戶代號:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DisplayNameLbl
            // 
            this.DisplayNameLbl.AutoSize = true;
            this.ClientPanel.SetColumnSpan(this.DisplayNameLbl, 3);
            this.DisplayNameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DisplayNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayNameLbl.Location = new System.Drawing.Point(3, 70);
            this.DisplayNameLbl.Name = "DisplayNameLbl";
            this.DisplayNameLbl.Size = new System.Drawing.Size(560, 28);
            this.DisplayNameLbl.TabIndex = 5;
            this.DisplayNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ClientTypeCombo
            // 
            this.ClientTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClientTypeCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.ClientTypeCombo.FormattingEnabled = true;
            this.ClientTypeCombo.Items.AddRange(new object[] {
            "",
            "簽單",
            "門市"});
            this.ClientTypeCombo.Location = new System.Drawing.Point(100, 101);
            this.ClientTypeCombo.Name = "ClientTypeCombo";
            this.ClientTypeCombo.Size = new System.Drawing.Size(121, 32);
            this.ClientTypeCombo.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 41);
            this.label6.TabIndex = 11;
            this.label6.Text = "電話:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TelTxt
            // 
            this.TelTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TelTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TelTxt.Location = new System.Drawing.Point(100, 138);
            this.TelTxt.Name = "TelTxt";
            this.TelTxt.Size = new System.Drawing.Size(274, 29);
            this.TelTxt.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 52);
            this.label7.TabIndex = 12;
            this.label7.Text = "地址:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddressTxt
            // 
            this.ClientPanel.SetColumnSpan(this.AddressTxt, 2);
            this.AddressTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddressTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressTxt.Location = new System.Drawing.Point(100, 179);
            this.AddressTxt.Name = "AddressTxt";
            this.AddressTxt.Size = new System.Drawing.Size(463, 29);
            this.AddressTxt.TabIndex = 6;
            // 
            // ContactTxt
            // 
            this.ContactTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContactTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactTxt.Location = new System.Drawing.Point(660, 138);
            this.ContactTxt.Name = "ContactTxt";
            this.ContactTxt.Size = new System.Drawing.Size(287, 29);
            this.ContactTxt.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(569, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 41);
            this.label8.TabIndex = 14;
            this.label8.Text = "聯絡人:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 34);
            this.label5.TabIndex = 9;
            this.label5.Text = "貸款:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CreditTxt
            // 
            this.CreditTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CreditTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditTxt.Location = new System.Drawing.Point(100, 261);
            this.CreditTxt.Name = "CreditTxt";
            this.CreditTxt.Size = new System.Drawing.Size(274, 29);
            this.CreditTxt.TabIndex = 7;
            // 
            // importFromExcelBtn
            // 
            this.importFromExcelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.importFromExcelBtn.Location = new System.Drawing.Point(634, 723);
            this.importFromExcelBtn.Name = "importFromExcelBtn";
            this.importFromExcelBtn.Size = new System.Drawing.Size(145, 84);
            this.importFromExcelBtn.TabIndex = 12;
            this.importFromExcelBtn.Text = "EXCEL加入客戶";
            this.importFromExcelBtn.UseVisualStyleBackColor = true;
            this.importFromExcelBtn.Click += new System.EventHandler(this.importFromExcelBtn_Click);
            // 
            // UCClientInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.importFromExcelBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.newClientBtn);
            this.Controls.Add(this.radSeparator1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SearchClientBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ClientListCbox);
            this.Name = "UCClientInsert";
            this.Size = new System.Drawing.Size(1765, 1035);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSeparator1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ClientPanel.ResumeLayout(false);
            this.ClientPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ClientListCbox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SearchClientBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private Telerik.WinControls.UI.RadSeparator radSeparator1;
        private System.Windows.Forms.Button newClientBtn;
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel ClientPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox clientNameTxt;
        private System.Windows.Forms.MaskedTextBox ClientCodeTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label DisplayNameLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ClientTypeCombo;
        private System.Windows.Forms.MaskedTextBox CreditTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox TelTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox AddressTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox ContactTxt;
        private System.Windows.Forms.Button importFromExcelBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
    }
}
