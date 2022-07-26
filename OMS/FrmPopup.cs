using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMS
{
    public partial class FrmPopup : Form
    {
        public FrmPopup()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // Write code for button1 and button2 's click event in order to call 
        // from any where in your current project.

        // Calling

        //Form1 frm = new Form1("message to show", "buttontext1", "buttontext2");
        //frm.ShowDialog();
    }
}
