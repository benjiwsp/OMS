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
            string endTime = monthCalendar1.SelectionRange.End.ToString("yyyy-MM-dd 23:59:59");
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
    }
}
