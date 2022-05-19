using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMS.UserControls
{
    public partial class UCInsertOrder : UserControl
    {
        public UCInsertOrder()
        {
            InitializeComponent();
        }

        private void KtBtn_Click(object sender, EventArgs e)
        {
            clearOrderGrid();
        }

        private void CWBtn_Click(object sender, EventArgs e)
        {
            clearOrderGrid();

        }
        private void clearOrderGrid()
        {
            orderGrid.Rows.Clear();
        }
    }
}
