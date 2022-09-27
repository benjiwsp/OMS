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
    public partial class UCInsertOrder : UserControl
    {
        MySqlCommand cmd = new MySqlCommand();
        MySqlConnection myConn = DBConnection.getConn();
        MySqlDataReader rdr;
        Dictionary<string, string> location = new Dictionary<string, string>();

        public UCInsertOrder()
        {
            InitializeComponent();
            location.Add("KT", "觀塘");
            AddColumnsProgrammatically();
        }

        private void KtBtn_Click(object sender, EventArgs e)
        {
            insertToDB("KT");
        }

        private void CWBtn_Click(object sender, EventArgs e)
        {
            insertToDB("CW");

        }
        private void clearOrderGrid()
        {
            orderGrid.Rows.Clear();
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


            col1.HeaderText = "單號";
            col1.Name = "單號";
            col2.HeaderText = "客戶";
            col2.Name = "客戶";
            col3.HeaderText = "類別";
            col3.Name = "類別";
            col4.HeaderText = "金額";
            col4.Name = "金額";
            col5.HeaderText = "出單地點";
            col5.Name = "出單地點";
            col6.HeaderText = "收錢地點";
            col6.Name = "收錢地點";
            col7.HeaderText = "日期";
            col7.Name = "日期";

            orderGrid.Columns.AddRange(new DataGridViewColumn[] { col1, col2, col3, col4, col5, col6, col7 });
        }


        private void addRow(string orderID, string cust, string ordType, string amount, string deployLoc, string paidLoc, string date)
        {
            orderGrid.Rows.Add(orderID, cust, ordType, amount, deployLoc, paidLoc, date);
        }


        private void insertToDB(string location)
        {
            try
            {
                string startTime = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd 00:00:01");
                string endTime = monthCalendar1.SelectionRange.End.ToString("yyyy-MM-dd 23:59:59");
                string site = "";
                if (orderGrid.Rows.Count > 0)
                {
                    DBConnection.connDB();

                    foreach (DataGridViewRow row in orderGrid.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            string orderID = row.Cells[0].Value.ToString();

                            string clientID = row.Cells[1].Value.ToString();
                            string orderType = row.Cells[2].Value.ToString();
                            string price = row.Cells[3].Value.ToString();
                            string stockLocation = row.Cells[4].Value.ToString();
                            string payLocation = row.Cells[5].Value.ToString();
                            string date = startTime;
                            string query = $"INSERT INTO ORDERS (ORDERID, CLIENT, ORDER_TYPE, PRICE, STOCK_LOCATION, PAYMENT_LOCATION, ORDER_DATE) values ('{orderID}','{clientID}','{orderType}',{price},'{stockLocation}','{payLocation}','{startTime}')";
                            cmd = new MySqlCommand(query, myConn);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    orderGrid.Rows.Clear();
                    AddColumnsProgrammatically();
                    DBConnection.disconnDB();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("duplicate key"))
                {
                    MessageBox.Show("OrderID already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
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