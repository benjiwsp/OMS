using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using OMS.Utility;
namespace OMS.UserControls
{
    public partial class UCClientInsert : UserControl
    {
        MySqlCommand cmd = new MySqlCommand();
        MySqlConnection myConn = DBConnection.getConn();
        MySqlDataReader rdr;
        public string address
        {
            get { return AddressTxt.Text; }
        }
        public string clientName
        {
            get { return clientNameTxt.Text; }
        }
        public string clientCode
        {
            get { return ClientCodeTxt.Text; }
        }
        public string contact
        {
            get { return ContactTxt.Text; }
        }
        public string tel
        {
            get { return TelTxt.Text; }
        }
        public string clientType
        {
            get { return ClientTypeCombo.Text; }
        }
        public double credit
        {
            get { return Convert.ToDouble(CreditTxt.Text); }
        }
        public UCClientInsert()
        {
            InitializeComponent();
            getClientTypeList();
        }

        private void clientNameTxt_TextChanged(object sender, EventArgs e)
        {
            DisplayNameLbl.Text = getClientName();
        }

        private void ClientCodeTxt_TextChanged(object sender, EventArgs e)
        {
            DisplayNameLbl.Text = getClientName();
        }

        private string getClientName()
        {
            string output;
            output = clientCode + " - " + clientName;

            return output;

        }

        private void insertClientToDb(string _name, string _code, string _clientType, string _tel, string _add, double _credit, string _contact)
        {
            string now = DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
            cmd = new MySqlCommand($"insert into CLIENT (CLIENT_ID,CLIENT_NAME,ADDRESS,TEL,CONTACT_PERSON,CREDIT, CLIENT_TYPE,MODIFY_TIME) values('{ _code }','{_name}','{_add}','{_tel}','{_contact}','{_credit}','{_clientType}','{now}')", myConn);
            DBConnection.connDB();
            cmd.ExecuteNonQuery();

            DBConnection.disconnDB();

        }

        private bool fieldValidation()
        {
            bool isValid = true;
            if (clientCode.Length <= 0)
                isValid = false;
            if (clientName.Length <= 0)
                isValid = false;
            if (clientType.Length <= 0)
                isValid = false;
            if (address.Length <= 0)
                isValid = false;
            if (tel.Length <= 0)
                isValid = false;
            if (contact.Length <= 0)
                isValid = false;
            //if (credit.Length <= 0)
            //{
            //    isValid = false;
            //}
            return isValid;


        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            clearControl();
            enablePanel(false);
        }
        private void clearControl()
        {
            foreach (Control x in ClientPanel.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Clear();
                }
                else if (x is MaskedTextBox)
                {
                    ((MaskedTextBox)x).Clear();
                }
                else if (x is ComboBox)
                {
                    ((ComboBox)x).SelectedIndex = -1;
                }
            }
        }
        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            if (fieldValidation())
            {
                insertClientToDb(clientName, clientCode, clientType, tel, address, credit, contact);
                clearControl();
                enablePanel(false);
            }
            else
            {
                MessageBox.Show("請檢查輸入資料.");
            }
        }

        private void newClientBtn_Click(object sender, EventArgs e)
        {
            enablePanel(true);
        }

        private void enablePanel(bool en)
        {
            ClientPanel.Enabled = en;
        }

        private void importFromExcelBtn_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            {
                filePath = file.FileName; //get the path of the file  
                fileExt = Path.GetExtension(filePath); //get the file extension  
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        DataTable dtExcel = new DataTable();
                        dtExcel = ReadExcel(filePath, fileExt); //read excel file  
                        foreach (DataRow row in dtExcel.Rows)
                        {

                            if (row["F1"].ToString() != "客戶代號")
                            {
                                string ExCode = row["F1"].ToString(); //客戶代號
                                string ExName = row["F2"].ToString(); //客戶名稱
                                string ExType = row["F3"].ToString(); //客戶類別
                                string ExTel = row["F4"].ToString(); //電話
                                string ExAdd = row["F5"].ToString(); //地址
                                string ExContact = row["F6"].ToString(); //聯絡人
                                string ExCredit = row["F7"].ToString(); //貸款
                                // insert these records to the table
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }
            }
        }
        public DataTable ReadExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xls") == 0)
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=NO';"; //for above excel 2007  
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                try
                {
                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [Sheet1$]", con); //here we read data from sheet1  
                    oleAdpt.Fill(dtexcel); //fill excel data into dataTable  
                }
                catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            }
            return dtexcel;
        }

        private void SearchClientBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            cmd = new MySqlCommand("SELECT CLIENT_ID, CLIENT_NAME, CREDIT from CLIENT", myConn);
            DBConnection.connDB();
            rdr = cmd.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    dataGridView1.Rows.Add(rdr["CLIENT_ID"].ToString(), rdr["CLIENT_NAME"].ToString(), rdr["CREDIT"].ToString(), "更改");
                }
                rdr.Close();
            }
            DBConnection.disconnDB();
        }
        private void getClientTypeList()
        {
            cmd = new MySqlCommand("SELECT DISTINCT CLIENT_TYPE from CLIENT", myConn);
            DBConnection.connDB();
            rdr = cmd.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    ClientListCbox.Items.Add(rdr["CLIENT_TYPE"].ToString());
                }
                rdr.Close();
            }
            DBConnection.disconnDB();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            enablePanel(true);
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string _clientID = senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString();

                cmd = new MySqlCommand($"SELECT CLIENT_ID, CLIENT_NAME, CREDIT, ADDRESS, TEL, CONTACT_PERSON, CLIENT_TYPE from CLIENT where CLIENT_ID = '{_clientID}'", myConn);
                DBConnection.connDB();
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {
                        AddressTxt.Text = rdr["ADDRESS"].ToString();
                        clientNameTxt.Text = rdr["CLIENT_NAME"].ToString();
                        ClientCodeTxt.Text = rdr["CLIENT_ID"].ToString();
                        CreditTxt.Text = rdr["CREDIT"].ToString();
                        TelTxt.Text = rdr["TEL"].ToString();
                        ContactTxt.Text = rdr["CONTACT_PERSON"].ToString();
                        ClientTypeCombo.SelectedIndex = ClientTypeCombo.FindString(rdr["CLIENT_TYPE"].ToString());

                        //  dataGridView1.Rows.Add(rdr["CLIENT_ID"].ToString(), rdr["CLIENT_NAME"].ToString(), rdr["CREDIT"].ToString(), "更改");
                    }
                    rdr.Close();
                }
                DBConnection.disconnDB();
                //TODO - Button Clicked - Execute Code Here
            }
        }

        private void ClientListCbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                string cSelected = ClientListCbox.SelectedItem.ToString();
                cmd = new MySqlCommand($"SELECT CLIENT_ID, CLIENT_NAME, CREDIT from CLIENT where CLIENT_TYPE = '{cSelected}'", myConn);
                DBConnection.connDB();
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {
                        dataGridView1.Rows.Add(rdr["CLIENT_ID"].ToString(), rdr["CLIENT_NAME"].ToString(), rdr["CREDIT"].ToString(), "更改");
                    }
                    rdr.Close();
                }
                DBConnection.disconnDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
