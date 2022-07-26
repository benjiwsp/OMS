using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMS.UserControls;

namespace OMS
{
    public partial class Form1 : Form
    {

        UCStatement UCstatement = new UCStatement();
        UCClientInsert UCClient = new UCClientInsert();
        UCCheckOrder UCOrder = new UCCheckOrder();
        UCInsertOrder UCInsert = new UCInsertOrder();
        UCClientManagement UCClientMgm = new UCClientManagement();
        List<UserControl> controlList = new List<UserControl>();
        public Form1()
        {
            InitializeComponent();
            controlList.Add(UCClient);
            controlList.Add(UCstatement);
            controlList.Add(UCOrder);

        }



        private void button1_Click(object sender, EventArgs e)
        {
            //  mainPanel.Controls.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updatePanel(UCClientMgm);

        }

        private void ClientSetupBtn_Click(object sender, EventArgs e)
        {
            //  mainPanel.Controls.Clear();
            updatePanel(UCClient);


        }

        private void CheckOrderBtn_Click(object sender, EventArgs e)
        {
            updatePanel(UCOrder);
        }

        private void updatePanel(UserControl usercon)
        {
            try { 
            foreach (UserControl uc in controlList)
            {
                mainPanel.Controls.Remove(uc);
                    mainPanel.Controls.Clear();
            }
            mainPanel.Controls.Add(usercon);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            updatePanel(UCInsert);

        }

        private void CreateInvoiceBtn_Click(object sender, EventArgs e)
        {
            updatePanel(UCstatement);

        }
    }
}
