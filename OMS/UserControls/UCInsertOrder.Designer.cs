
namespace OMS.UserControls
{
    partial class UCInsertOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.orderGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KtBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.CWBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.orderGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // orderGrid
            // 
            this.orderGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.orderGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.orderGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.orderGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column7,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.orderGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.orderGrid.Location = new System.Drawing.Point(248, 6);
            this.orderGrid.Name = "orderGrid";
            this.orderGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.orderGrid.Size = new System.Drawing.Size(1143, 1029);
            this.orderGrid.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "單號";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Column2.HeaderText = "客戶";
            this.Column2.Name = "Column2";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "類別";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "金額";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Column4.HeaderText = "出單地點";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Column5.HeaderText = "收錢地點";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "日期";
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // KtBtn
            // 
            this.KtBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.KtBtn.Location = new System.Drawing.Point(9, 224);
            this.KtBtn.Name = "KtBtn";
            this.KtBtn.Size = new System.Drawing.Size(227, 81);
            this.KtBtn.TabIndex = 9;
            this.KtBtn.Text = "KT";
            this.KtBtn.UseVisualStyleBackColor = true;
            this.KtBtn.Click += new System.EventHandler(this.KtBtn_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button1.Location = new System.Drawing.Point(9, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 81);
            this.button1.TabIndex = 10;
            this.button1.Text = "KT";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // CWBtn
            // 
            this.CWBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.CWBtn.Location = new System.Drawing.Point(9, 311);
            this.CWBtn.Name = "CWBtn";
            this.CWBtn.Size = new System.Drawing.Size(227, 81);
            this.CWBtn.TabIndex = 11;
            this.CWBtn.Text = "CW";
            this.CWBtn.UseVisualStyleBackColor = true;
            this.CWBtn.Click += new System.EventHandler(this.CWBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.SaveBtn.Location = new System.Drawing.Point(9, 951);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(227, 81);
            this.SaveBtn.TabIndex = 12;
            this.SaveBtn.Text = "儲存";
            this.SaveBtn.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(9, 57);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "入單";
            // 
            // UCInsertOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.CWBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.KtBtn);
            this.Controls.Add(this.orderGrid);
            this.Name = "UCInsertOrder";
            this.Size = new System.Drawing.Size(1765, 1035);
            ((System.ComponentModel.ISupportInitialize)(this.orderGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView orderGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column4;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button KtBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button CWBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label1;
    }
}
