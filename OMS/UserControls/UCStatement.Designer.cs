
namespace OMS.UserControls
{
    partial class UCStatement
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
            this.StatementGrid = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CreateStatementBtn = new System.Windows.Forms.Button();
            this.CW = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.StatementGrid)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatementGrid
            // 
            this.StatementGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StatementGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatementGrid.Location = new System.Drawing.Point(3, 3);
            this.StatementGrid.Name = "StatementGrid";
            this.StatementGrid.Size = new System.Drawing.Size(1461, 633);
            this.StatementGrid.TabIndex = 0;
            this.StatementGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StatementGrid_CellContentClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.17281F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8272F));
            this.tableLayoutPanel1.Controls.Add(this.StatementGrid, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CreateStatementBtn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.CW, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.monthCalendar1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.monthCalendar2, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.09662F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.90338F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1765, 1035);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // CreateStatementBtn
            // 
            this.CreateStatementBtn.Location = new System.Drawing.Point(3, 642);
            this.CreateStatementBtn.Name = "CreateStatementBtn";
            this.CreateStatementBtn.Size = new System.Drawing.Size(75, 23);
            this.CreateStatementBtn.TabIndex = 1;
            this.CreateStatementBtn.Text = "準備發票";
            this.CreateStatementBtn.UseVisualStyleBackColor = true;
            this.CreateStatementBtn.Click += new System.EventHandler(this.CreateStatementBtn_Click);
            // 
            // CW
            // 
            this.CW.Location = new System.Drawing.Point(1470, 3);
            this.CW.Name = "CW";
            this.CW.Size = new System.Drawing.Size(75, 23);
            this.CW.TabIndex = 2;
            this.CW.Text = "button1";
            this.CW.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(1476, 648);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 3;
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(1476, 806);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 5;
            // 
            // UCStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UCStatement";
            this.Size = new System.Drawing.Size(1765, 1035);
            ((System.ComponentModel.ISupportInitialize)(this.StatementGrid)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView StatementGrid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button CreateStatementBtn;
        private System.Windows.Forms.Button CW;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
    }
}
