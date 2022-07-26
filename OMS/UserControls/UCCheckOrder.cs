using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using OMS.Utility;

namespace OMS.UserControls
{
    public partial class UCCheckOrder : UserControl
    {
        MySqlCommand cmd = new MySqlCommand();
        MySqlConnection myConn = DBConnection.getConn();
        MySqlDataReader rdr;
        Dictionary<string, string> location = new Dictionary<string, string>();

        public UCCheckOrder()
        {
            InitializeComponent();
            location.Add("KT", "觀塘");
            AddColumnsProgrammatically();
        }

        private void KtBtn_Click(object sender, EventArgs e)
        {
            clearOrderGrid();
            Button clickedBtn = (Button)sender;
            getOrder(clickedBtn.Text);
        }

        private void CWBtn_Click(object sender, EventArgs e)
        {
            clearOrderGrid();
            Button clickedBtn = (Button)sender;
            getOrder(clickedBtn.Text);

        }
        private void clearOrderGrid()
        {
            orderGrid.Rows.Clear();
        }

        private void getOrder(string site)
        {
            string startTime = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd 00:00:01");
            string endTime = monthCalendar2.SelectionRange.End.ToString("yyyy-MM-dd 23:59:59");
            cmd = new MySqlCommand($"SELECT ORDERID, CLIENT, ORDER_TYPE, PRICE, STOCK_LOCATION, PAYMENT_LOCATION, ORDER_DATE from ORDERS where STOCK_LOCATION = '{site}' AND ORDER_DATE between '{startTime}' and '{endTime}' ", myConn);
            DBConnection.connDB();
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            rdr = cmd.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    orderGrid.Rows.Add(rdr["ORDERID"].ToString(), rdr["CLIENT"].ToString(), rdr["ORDER_TYPE"].ToString(), rdr["PRICE"].ToString(), rdr["STOCK_LOCATION"].ToString(), rdr["PAYMENT_LOCATION"].ToString(), rdr["ORDER_DATE"].ToString(), "更改");
                }
                rdr.Close();
            }
            DBConnection.disconnDB();
        }
        private void AddColumnsProgrammatically()
        {
            var col1 = new DataGridViewTextBoxColumn();
            var col2 = new DataGridViewTextBoxColumn();

            var col3 = new DataGridViewTextBoxColumn();
            var col4 = new DataGridViewTextBoxColumn();

            var col5 = new DataGridViewTextBoxColumn();
            var col6 = new DataGridViewTextBoxColumn();

            var col7 = new DataGridViewTextBoxColumn();
            var col8 = new DataGridViewButtonColumn();


            col1.HeaderText = "單號";
            col1.Name = "單號";
            col1.ReadOnly = true;
            col2.HeaderText = "客戶";
            col2.Name = "客戶";
            col2.ReadOnly = true;
            col3.HeaderText = "類別";
            col3.Name = "類別";
            col3.ReadOnly = true;
            col4.HeaderText = "金額";
            col4.Name = "金額";
            col4.ReadOnly = true;
            col5.HeaderText = "出單地點";
            col5.Name = "出單地點";
            col5.ReadOnly = true;
            col6.HeaderText = "收錢地點";
            col6.Name = "收錢地點";
            col6.ReadOnly = true;
            col7.HeaderText = "日期";
            col7.Name = "日期";
            col7.ReadOnly = true;
            col8.HeaderText = "更改";
            col8.Name = "更改";

            orderGrid.Columns.AddRange(new DataGridViewColumn[] { col1, col2, col3, col4, col5, col6, col7 , col8});
        }


        private void addRow(string orderID, string cust, string ordType, string amount, string deployLoc, string paidLoc, string date)
        {
            orderGrid.Rows.Add(orderID, cust, ordType, amount, deployLoc, paidLoc, date);
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            clearOrderGrid();
        }

        private void orderGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                MessageBox.Show("test");
                //TODO - Button Clicked - Execute Code Here
            }
        }
    }
}   