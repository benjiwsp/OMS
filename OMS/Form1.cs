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
        UCInsertOrder UCOrder = new UCInsertOrder();
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
            updatePanel(UCstatement);
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

        private void InsertOrderBtn_Click(object sender, EventArgs e)
        {
            updatePanel(UCOrder);
        }

        private void updatePanel(UserControl usercon)
        {
            foreach (UserControl uc in controlList)
            {
                mainPanel.Controls.Remove(uc);
            }
            mainPanel.Controls.Add(usercon);

        }

     
    }
}
