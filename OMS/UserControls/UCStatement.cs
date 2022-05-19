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
  
    public partial class UCStatement : UserControl
    {
        public UCStatement()
        {
            InitializeComponent();
            setGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void StatementGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void setGrid()
        {
           

            List<Statement> eObj = new List<Statement>();

            Statement emp = new Statement();
            emp.isRequired = false;
            emp.OrderId = "Devesh";
            eObj.Add(emp);
            emp = new Statement();
            emp.isRequired = false;
            emp.OrderId = "ROLI";
            eObj.Add(emp);

            emp = new Statement();
            emp.isRequired = true;
            emp.OrderId = "Manish";
            eObj.Add(emp);

            emp = new Statement();
            emp.isRequired = false;
            emp.OrderId = "Nikhil";
            eObj.Add(emp);

            StatementGrid.DataSource = eObj;
        }
      

        private void CreateStatementBtn_Click(object sender, EventArgs e)
        {

        }
    }
    public class Statement
    {
        public bool isRequired { get; set; }
        public string OrderId { get; set; }
        public string ClientName { get; set; }
        public double TotalPrice { get; set; }
        public string Date { get; set; }

    }
}
