
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
            this.StatementGrid.Size = new System.Drawing.Size(1461, 823);
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.09662F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.90338F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1765, 1035);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // CreateStatementBtn
            // 
            this.CreateStatementBtn.Location = new System.Drawing.Point(3, 832);
            this.CreateStatementBtn.Name = "CreateStatementBtn";
            this.CreateStatementBtn.Size = new System.Drawing.Size(75, 23);
            this.CreateStatementBtn.TabIndex = 1;
            this.CreateStatementBtn.Text = "準備發票";
            this.CreateStatementBtn.UseVisualStyleBackColor = true;
            this.CreateStatementBtn.Click += new System.EventHandler(this.CreateStatementBtn_Click);
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
    }
}
