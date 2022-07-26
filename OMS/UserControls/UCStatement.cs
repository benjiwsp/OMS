using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using OMS.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace OMS.UserControls
{

    public partial class UCStatement : UserControl
    {
        MySqlCommand cmd = new MySqlCommand();
        MySqlConnection myConn = DBConnection.getConn();
        MySqlDataReader rdr;
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
                    StatementGrid.Rows.Add(rdr["ORDERID"].ToString(), rdr["CLIENT"].ToString(), rdr["ORDER_TYPE"].ToString(), rdr["PRICE"].ToString(), rdr["STOCK_LOCATION"].ToString(), rdr["PAYMENT_LOCATION"].ToString(), rdr["ORDER_DATE"].ToString(), "更改");
                }
                rdr.Close();
            }
            DBConnection.disconnDB();
        }

        private void CreateStatementBtn_Click(object sender, EventArgs e)
        {
            InputBox input = new InputBox();
            input.Text = "請輸入發票期數(單位數字)。";
            string index = "";
            if (input.ShowDialog() == DialogResult.OK)
            {
                index = input.OrderNumberInputTextbox.Text;
                //create the invoice
                createInvoicePDF(index, 1, "CW - TEST", "TM - TEST");
                //sfInvoice.PerformClick();
            }
         //   createInvoicePDF();
        }

        private void createInvoicePDF(string Index, int receiptIndexing, string BelongTo, string comp)
        {
            DateTime startPick = monthCalendar1.SelectionRange.Start;
            DateTime endPick = monthCalendar2.SelectionRange.Start;
            DateTime beginning = new DateTime(startPick.Year, startPick.Month, startPick.Day, 00, 00, 01);
            DateTime ending = new DateTime(endPick.Year, endPick.Month, endPick.Day, 23, 59, 59);
            DateTime today = DateTime.Now;
            string ch_compName = "";
            string en_compName = "";
            string compFax = "";
            string compTel = "";
            string ch_add = "";
            string en_add = "";
            decimal custTotal = 0.0m;
            decimal sandTotalWeight = 0.0m;
            int pageNum = 1;
            cmd = new MySqlCommand("Select * from CashPOSDB.companyInfo where NameCH = '" + BelongTo + "'", myConn);
            DBConnection.connDB();
            rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                if (rdr.Read())
                {
                    ch_compName = rdr["NameCH"].ToString();
                    en_compName = rdr["NameEN"].ToString();
                    compFax = rdr["Fax"].ToString();
                    compTel = rdr["Phone"].ToString();
                    ch_add = rdr["AddCH"].ToString();
                    en_add = rdr["AddEN"].ToString();
                }
            }
            rdr.Close();
            //     myConn.Close();

            string code = "", cust = "", handler = "", tel = "", fax = "", attn = "", email = "", refNo = "", quote = "", filepath = "", folderPath = "", address = "";
            decimal sum = 0.0m;
            int index = 1;
            bool finish = true, filled = false, firstPage = true;
            PdfWriter writer;
            Document doc = null;
            string query = "Select * from CashPOSDB.orderDetails a join CashPOSDB.orderRecords b where payment = '簽單' and a.orderID = b.orderID and b.time >=  '" +
                beginning.ToString("yyyy-MM-dd HH:mm:ss") + "' and b.time <= '" + ending.ToString("yyyy-MM-dd HH:mm:ss") + "' and a.custCode = '" + comp + "'  and b.orderID like 'MSF%' order by a.custCode, a.time,a.orderID";
            cmd = new MySqlCommand(query, myConn);
            //    myConn.Open();
            rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + "\\Fonts\\KAIU.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font chfont = new iTextSharp.text.Font(bf, 15);
                iTextSharp.text.Font chfontB = new iTextSharp.text.Font(bf, 17);
                iTextSharp.text.Font chfontT = new iTextSharp.text.Font(bf, 9);
                iTextSharp.text.Font custInfo = new iTextSharp.text.Font(bf, 11);
                iTextSharp.text.Font infoFont = new iTextSharp.text.Font(bf, 11);
                doc = new Document(iTextSharp.text.PageSize.A4);
                int rowCount = 0;
                while (rdr.Read())
                {
                    if (firstPage)
                    {
                        folderPath = "D:\\POS\\" + ch_compName + "\\發票\\" + rdr["custCode"].ToString() + rdr["custName"].ToString() + "\\" + beginning.ToString("yyyy") + "\\" + beginning.ToString("MM") + "\\";

                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }
                        filepath = folderPath + beginning.ToString("yyyyMM") + Index + rdr["custName"].ToString() + ".pdf";
                        writer = PdfWriter.GetInstance(doc, new FileStream(filepath, FileMode.Create));
                        doc.Open();
                        firstPage = false;
                    }
                    PdfPTable titleTable = new PdfPTable(5);
                    titleTable.WidthPercentage = 100f;

                    PdfPTable infoTable = new PdfPTable(7);

                    infoTable.WidthPercentage = 100f;

                    float[] twdiths = new float[7];
                    twdiths[0] = 40f;
                    twdiths[1] = 10f;
                    twdiths[2] = 85f;
                    twdiths[3] = 80f;
                    twdiths[4] = 80f;
                    twdiths[5] = 10f;
                    twdiths[6] = 80f;
                    infoTable.SetWidths(twdiths);
                    PdfPTable detailTable = new PdfPTable(10);
                    detailTable.WidthPercentage = 100f;

                    float[] detailWdiths = new float[10];
                    detailWdiths[0] = 50f;
                    detailWdiths[1] = 52f;
                    detailWdiths[2] = 54f;
                    detailWdiths[3] = 20f;
                    detailWdiths[4] = 54f;
                    detailWdiths[5] = 20f;
                    detailWdiths[6] = 50f;
                    detailWdiths[7] = 15f;
                    detailWdiths[8] = 50f;
                    detailWdiths[9] = 50f;

                    detailTable.SetWidths(detailWdiths);

                    PdfPTable addressTable = new PdfPTable(7);
                    addressTable.WidthPercentage = 100f;



                    //detailTable.SetWidths(detailWdiths);
                    PdfPTable footerTable = new PdfPTable(5);
                    footerTable.WidthPercentage = 100f;

                    PdfPTable fillFooter = new PdfPTable(8);
                    fillFooter.WidthPercentage = 100f;

                    // fillFooter.SetWidths(detailWdiths);
                    string newCode = rdr["custCode"].ToString();

                    //if the page is filled 
                    if (rowCount == 30)
                    {
                        pageNum++;
                        rowCount = 0;
                        filled = true;
                        rowCount = 0;
                        /*    fillFooter.AddCell(newCell(" ", 0, 10, 0, 2, infoFont));
                            fillFooter.AddCell(newCell(sum.ToString(" "), 0, 8, 0, 0, infoFont));
                            fillFooter.AddCell(newCell(sum.ToString("總數:"), 0, 1, 0, 0, infoFont));
                            fillFooter.AddCell(newCell(sum.ToString("0.00"), 0, 1, 0, 0, infoFont));*/
                        fillFooter.AddCell(newCell(" ", 0, 10, 0, 2, infoFont));
                        fillFooter.AddCell(newCell(" ", 0, 4, 0, 0, infoFont));
                        fillFooter.AddCell(newCell("總噸數:", 0, 1, 0, 0, infoFont));
                        fillFooter.AddCell(newCell(sandTotalWeight.ToString("0.00"), 0, 1, 0, 0, infoFont));

                        fillFooter.AddCell(newCell("總數:", 0, 1, 0, 0, infoFont));
                        fillFooter.AddCell(newCell(sum.ToString("0.00"), 0, 2, 2, 0, infoFont));

                        fillFooter.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));

                        fillFooter.AddCell(newCell("請於收貨後30天內付清貨款.", 0, 10, 0, 0, infoFont));
                        fillFooter.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
                        if (ch_compName.StartsWith("富"))
                        {
                            fillFooter.AddCell(newCell("富資建業有限公司", 0, 10, 0, 0, infoFont));
                            fillFooter.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
                            fillFooter.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));

                        }
                        else
                        {
                            fillFooter.AddCell(newCell("超誠建築材料倉有限公司", 0, 10, 0, 0, infoFont));

                            fillFooter.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
                            fillFooter.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));

                            fillFooter.AddCell(newCell("多謝惠顧 祝生意興隆", 0, 10, 1, 0, infoFont));

                        }



                        custTotal += sum;
                        //      MessageBox.Show(sum.ToString());
                        doc.Add(fillFooter);
                        sum = 0.0m;
                    }

                    if (finish || filled)
                    {
                        quote = rdr["custCode"].ToString() + beginning.ToString("yyMM") + Index + pageNum;
                        index++;
                        doc.NewPage();
                        //tempComm = new MySqlCommand("Select * from custData where Code = '" + rdr["custCode"].ToString() + "'", tempConn);
                        //tempConn.Open();
                        //tempRdr = tempComm.ExecuteReader();
                        //if (tempRdr.HasRows)
                        //{
                        //    if (tempRdr.Read())
                        //    {
                        //        code = tempRdr["Code"].ToString();
                        //        cust = tempRdr["Name"].ToString();
                        //        tel = tempRdr["Phone1"].ToString();
                        //        fax = tempRdr["Fax"].ToString();
                        //        email = tempRdr["Email"].ToString();
                        //        address = tempRdr["Address"].ToString();
                        //    }
                        //}
                        //tempRdr.Close(); tempConn.Close();
                        sandTotalWeight = 0.0m;
                        titleTable.AddCell(newCell(" ", 1, 5, 1, 0, chfontT));
                        titleTable.AddCell(newCell(" ", 1, 5, 1, 0, chfontT));
                        titleTable.AddCell(newCell(" ", 1, 5, 1, 0, chfontT));


                        titleTable.AddCell(newCell(ch_compName, 1, 5, 1, 0, chfontB));
                        titleTable.AddCell(newCell(en_compName, 3, 5, 1, 2, chfontB));

                        titleTable.AddCell(newCell(en_add, 1, 5, 1, 0, chfontT));
                        titleTable.AddCell(newCell(ch_add, 1, 5, 1, 0, chfontT));
                        titleTable.AddCell(newCell("", 1, 1, 0, 0, chfontT));

                        titleTable.AddCell(newCell("Tel:" + compTel, 1, 1, 1, 0, chfontT));
                        titleTable.AddCell(newCell("", 1, 1, 0, 0, chfontT));

                        titleTable.AddCell(newCell("Fax:" + compFax, 1, 1, 1, 0, chfontT));
                        titleTable.AddCell(newCell("", 1, 1, 0, 0, chfontT));




                        doc.Add(titleTable);

                        infoTable.AddCell(newCell(" ", 0, 7, 0, 0, custInfo));

                        // start of customer info

                        //    infoTable.AddCell(newCell("Tel No", 0, 1, 0, 0, custInfo));
                        //   infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        //    infoTable.AddCell(newCell(tel, 0, 1, 0, 0, custInfo));
                        //   infoTable.AddCell(newCell("", 0, 4, 0, 0, custInfo));
                        //     infoTable.AddCell(newCell("Invoice No", 0, 1, 0, 0, custInfo));
                        //      infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        //      infoTable.AddCell(newCell(quote, 0, 1, 0, 0, custInfo));

                        //  infoTable.AddCell(newCell("Fax No", 0, 1, 0, 0, custInfo));
                        //   infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        //  infoTable.AddCell(newCell(fax, 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("Customer", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(code, 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("Date", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(ending.ToString("yyyy-MM-dd"), 0, 1, 0, 0, custInfo));

                        infoTable.AddCell(newCell("TO", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(cust, 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("Invoice No", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(quote, 0, 1, 0, 0, custInfo));

                        //         infoTable.AddCell(newCell("地址", 0, 1, 0, 0, custInfo));
                        //        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        //         infoTable.AddCell(newCell(address, 0, 6, 0, 0, custInfo));


                        infoTable.AddCell(newCell("Address", 0, 1, 0, 0, infoFont));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        PdfPCell addressCell = newCell(address, 0, 1, 0, 0, custInfo);
                        infoTable.AddCell(addressCell);
                        infoTable.AddCell(newCell(" ", 0, 3, 0, 0, infoFont));
                        infoTable.AddCell(newCell(" ", 0, 7, 0, 0, infoFont));
                        infoTable.AddCell(newCell(" ", 3, 7, 0, 0, infoFont));

                        infoTable.AddCell(newCell("發票", 1, 7, 1, 0, infoFont));
                        infoTable.AddCell(newCell("Invoice", 1, 7, 1, 0, infoFont));
                        doc.Add(infoTable);

                        doc.Add(addressTable);
                        detailTable.AddCell(newCell("單號", 2, 1, 0, 2, chfontT));

                        detailTable.AddCell(newCell("日期", 2, 1, 0, 2, chfontT));

                        detailTable.AddCell(newCell("貨品", 2, 3, 0, 2, chfontT));
                        detailTable.AddCell(newCell("類", 2, 1, 0, 2, chfontT));

                        detailTable.AddCell(newCell("數量", 2, 1, 2, 2, chfontT));
                        detailTable.AddCell(newCell(" ", 2, 1, 0, 2, chfontT));
                        detailTable.AddCell(newCell("單價", 2, 1, 2, 2, chfontT));
                        detailTable.AddCell(newCell("總數(港幣)", 2, 1, 2, 2, chfontT));
                        finish = false;
                        filled = false;
                    }
                    detailTable.AddCell(newCell(rdr["orderID"].ToString(), 1, 1, 0, 0, infoFont));

                    detailTable.AddCell(newCell(Convert.ToDateTime(rdr["time"]).ToString("dd-MM-yy"), 1, 1, 0, 0, infoFont));

                    detailTable.AddCell(newCell(rdr["itemName"].ToString(), 1, 3, 0, 0, infoFont));
                    detailTable.AddCell(newCell(rdr["priceType"].ToString().Substring(0, 1), 1, 1, 0, 0, infoFont));

                    detailTable.AddCell(newCell(rdr["amount"].ToString(), 1, 1, 2, 0, infoFont));
                    detailTable.AddCell(newCell(rdr["unit"].ToString().Substring(0, 1), 1, 1, 0, 0, infoFont));
                    detailTable.AddCell(newCell(rdr["unitPrice"].ToString(), 1, 1, 2, 0, infoFont));
                    detailTable.AddCell(newCell(rdr["total"].ToString(), 1, 1, 2, 0, infoFont));
                    sum += Convert.ToDecimal(rdr["total"].ToString());
                    doc.Add(detailTable);
                    rowCount++;
                    if (rdr["itemName"].ToString() == "洗水沙" || rdr["itemName"].ToString() == "天然沙")
                    {
                        sandTotalWeight += Convert.ToDecimal(rdr["amount"].ToString());
                    }

                }

                PdfPTable footer = new PdfPTable(8);
                footer.WidthPercentage = 100f;
                while (rowCount < 30)
                {
                    footer.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
                    rowCount++;
                }
                rowCount = 0;
                footer.AddCell(newCell(" ", 0, 10, 0, 2, infoFont));
                footer.AddCell(newCell(" ", 0, 4, 0, 0, infoFont));
                footer.AddCell(newCell("總噸數:", 0, 1, 0, 0, infoFont));
                footer.AddCell(newCell(sandTotalWeight.ToString("0.00"), 0, 1, 0, 0, infoFont));

                footer.AddCell(newCell("總數:", 0, 1, 0, 0, infoFont));
                footer.AddCell(newCell(sum.ToString("0.00"), 0, 2, 2, 0, infoFont));

                footer.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));

                footer.AddCell(newCell("請於收貨後30天內付清貨款.", 0, 10, 0, 0, infoFont));
                footer.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
                if (ch_compName.StartsWith("富"))
                {
                    footer.AddCell(newCell("富資建業有限公司", 0, 10, 0, 0, infoFont));
                    footer.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
                    footer.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));

                }
                else
                {
                    footer.AddCell(newCell("超誠建築材料倉有限公司", 0, 10, 0, 0, infoFont));
                    footer.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
                    footer.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));

                }


                footer.AddCell(newCell("多謝惠顧 祝生意興隆", 0, 10, 1, 0, infoFont));




                custTotal += sum;
                //   MessageBox.Show(sum.ToString());
                // MessageBox.Show("this is total " + custTotal);
                sum = 0.0m;
                //  footer.AddCell(newCell("客戶總數:", 0, 7, 0, 2, infoFont));
                //footer.AddCell(newCell(custTotal.ToString("0.00"), 0, 2, 2, 2, infoFont));
                custTotal = 0;
                doc.Add(footer);
                //   doc.Close();
                //   myConn.Close();

            }


            //invoice for sand order
            // index++;
            pageNum++;
            finish = true;

            query = "Select * from CashPOSDB.orderDetails a join CashPOSDB.orderRecords b where payment = '簽單' and a.orderID = b.orderID and b.time >=  '" +
          beginning.ToString("yyyy-MM-dd HH:mm:ss") + "' and b.time <= '" + ending.ToString("yyyy-MM-dd HH:mm:ss") + "' and a.custCode = '" + comp + "' and b.orderID not like 'MSF%' order by a.custCode, a.time,a.orderID";
            cmd = new MySqlCommand(query, myConn);
            //      myConn.Open();
            rdr.Close();
            rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + "\\Fonts\\KAIU.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font chfont = new iTextSharp.text.Font(bf, 15);
                iTextSharp.text.Font chfontB = new iTextSharp.text.Font(bf, 17);
                iTextSharp.text.Font chfontT = new iTextSharp.text.Font(bf, 9);
                iTextSharp.text.Font custInfo = new iTextSharp.text.Font(bf, 11);
                iTextSharp.text.Font infoFont = new iTextSharp.text.Font(bf, 11);
                // Document doc = new Document(iTextSharp.text.PageSize.A4);
                int rowCount = 0;

                while (rdr.Read())
                {
                    if (firstPage)
                    {
                        if (doc == null)
                        {
                            pageNum--;
                            doc = new Document(iTextSharp.text.PageSize.A4);
                            folderPath = "D:\\POS\\" + ch_compName + "\\發票\\" + rdr["custCode"].ToString() + rdr["custName"].ToString() + "\\" + beginning.ToString("yyyy") + "\\" + beginning.ToString("MM") + "\\";

                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }
                            filepath = folderPath + beginning.ToString("yyyyMM") + Index + rdr["custName"].ToString() + ".pdf";

                            writer = PdfWriter.GetInstance(doc, new FileStream(filepath, FileMode.Create));
                            doc.Open();
                            firstPage = false;
                        }
                        doc.NewPage();

                    }
                    PdfPTable titleTable = new PdfPTable(5);
                    titleTable.WidthPercentage = 100f;

                    PdfPTable infoTable = new PdfPTable(7);

                    infoTable.WidthPercentage = 100f;

                    float[] twdiths = new float[7];
                    twdiths[0] = 40f;
                    twdiths[1] = 10f;
                    twdiths[2] = 85f;
                    twdiths[3] = 80f;
                    twdiths[4] = 80f;
                    twdiths[5] = 10f;
                    twdiths[6] = 80f;
                    infoTable.SetWidths(twdiths);
                    PdfPTable detailTable = new PdfPTable(10);
                    detailTable.WidthPercentage = 100f;

                    float[] detailWdiths = new float[10];
                    detailWdiths[0] = 50f;
                    detailWdiths[1] = 52f;
                    detailWdiths[2] = 54f;
                    detailWdiths[3] = 20f;
                    detailWdiths[4] = 54f;
                    detailWdiths[5] = 20f;
                    detailWdiths[6] = 50f;
                    detailWdiths[7] = 15f;
                    detailWdiths[8] = 50f;
                    detailWdiths[9] = 50f;

                    detailTable.SetWidths(detailWdiths);

                    PdfPTable addressTable = new PdfPTable(7);
                    addressTable.WidthPercentage = 100f;



                    //detailTable.SetWidths(detailWdiths);
                    PdfPTable footerTable = new PdfPTable(5);
                    footerTable.WidthPercentage = 100f;

                    PdfPTable fillFooter = new PdfPTable(8);
                    fillFooter.WidthPercentage = 100f;

                    // fillFooter.SetWidths(detailWdiths);
                    string newCode = rdr["custCode"].ToString();

                    //if the page is filled 
                    if (rowCount == 30)
                    {
                        pageNum++;
                        rowCount = 0;
                        filled = true;
                        rowCount = 0;
                        /*    fillFooter.AddCell(newCell(" ", 0, 10, 0, 2, infoFont));
                            fillFooter.AddCell(newCell(sum.ToString(" "), 0, 8, 0, 0, infoFont));
                            fillFooter.AddCell(newCell(sum.ToString("總數:"), 0, 1, 0, 0, infoFont));
                            fillFooter.AddCell(newCell(sum.ToString("0.00"), 0, 1, 0, 0, infoFont));*/
                        fillFooter.AddCell(newCell(" ", 0, 10, 0, 2, infoFont));
                        fillFooter.AddCell(newCell(" ", 0, 4, 0, 0, infoFont));
                        fillFooter.AddCell(newCell("總噸數:", 0, 1, 0, 0, infoFont));
                        fillFooter.AddCell(newCell(sandTotalWeight.ToString("0.00"), 0, 1, 0, 0, infoFont));

                        fillFooter.AddCell(newCell("總數:", 0, 1, 0, 0, infoFont));
                        fillFooter.AddCell(newCell(sum.ToString("0.00"), 0, 2, 2, 0, infoFont));

                        fillFooter.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));

                        fillFooter.AddCell(newCell("請於收貨後30天內付清貨款.", 0, 10, 0, 0, infoFont));
                        fillFooter.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
                        if (ch_compName.StartsWith("富"))
                        {
                            fillFooter.AddCell(newCell("富資建業有限公司", 0, 10, 0, 0, infoFont));
                            fillFooter.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
                            fillFooter.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));

                        }
                        else
                        {
                            fillFooter.AddCell(newCell("超誠建築材料倉有限公司", 0, 10, 0, 0, infoFont));

                            fillFooter.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
                            fillFooter.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));

                            fillFooter.AddCell(newCell("多謝惠顧 祝生意興隆", 0, 10, 1, 0, infoFont));

                        }



                        custTotal += sum;
                        //      MessageBox.Show(sum.ToString());
                        doc.Add(fillFooter);
                        sum = 0.0m;
                    }

                    if (finish || filled)
                    {
                        quote = rdr["custCode"].ToString() + beginning.ToString("yyMM") + Index + pageNum;
                        index++;
                        doc.NewPage();
                        //tempComm = new MySqlCommand("Select * from custData where Code = '" + rdr["custCode"].ToString() + "'", tempConn);
                        //tempConn.Open();
                        //tempRdr = tempComm.ExecuteReader();
                        //if (tempRdr.HasRows)
                        //{
                        //    if (tempRdr.Read())
                        //    {
                        //        code = tempRdr["Code"].ToString();
                        //        cust = tempRdr["Name"].ToString();
                        //        tel = tempRdr["Phone1"].ToString();
                        //        fax = tempRdr["Fax"].ToString();
                        //        email = tempRdr["Email"].ToString();
                        //        address = tempRdr["Address"].ToString();
                        //    }
                        //}
                        //tempRdr.Close(); tempConn.Close();
                        sandTotalWeight = 0.0m;
                        titleTable.AddCell(newCell(" ", 1, 5, 1, 0, chfontT));
                        titleTable.AddCell(newCell(" ", 1, 5, 1, 0, chfontT));
                        titleTable.AddCell(newCell(" ", 1, 5, 1, 0, chfontT));


                        titleTable.AddCell(newCell(ch_compName, 1, 5, 1, 0, chfontB));
                        titleTable.AddCell(newCell(en_compName, 3, 5, 1, 2, chfontB));

                        titleTable.AddCell(newCell(en_add, 1, 5, 1, 0, chfontT));
                        titleTable.AddCell(newCell(ch_add, 1, 5, 1, 0, chfontT));
                        titleTable.AddCell(newCell("", 1, 1, 0, 0, chfontT));

                        titleTable.AddCell(newCell("Tel:" + compTel, 1, 1, 1, 0, chfontT));
                        titleTable.AddCell(newCell("", 1, 1, 0, 0, chfontT));

                        titleTable.AddCell(newCell("Fax:" + compFax, 1, 1, 1, 0, chfontT));
                        titleTable.AddCell(newCell("", 1, 1, 0, 0, chfontT));




                        doc.Add(titleTable);

                        infoTable.AddCell(newCell(" ", 0, 7, 0, 0, custInfo));

                        // start of customer info

                        //    infoTable.AddCell(newCell("Tel No", 0, 1, 0, 0, custInfo));
                        //   infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        //    infoTable.AddCell(newCell(tel, 0, 1, 0, 0, custInfo));
                        //   infoTable.AddCell(newCell("", 0, 4, 0, 0, custInfo));
                        //     infoTable.AddCell(newCell("Invoice No", 0, 1, 0, 0, custInfo));
                        //      infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        //      infoTable.AddCell(newCell(quote, 0, 1, 0, 0, custInfo));

                        //  infoTable.AddCell(newCell("Fax No", 0, 1, 0, 0, custInfo));
                        //   infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        //  infoTable.AddCell(newCell(fax, 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("Customer", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(code, 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("Date", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(ending.ToString("yyyy-MM-dd"), 0, 1, 0, 0, custInfo));

                        infoTable.AddCell(newCell("TO", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(cust, 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("Invoice No", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(quote, 0, 1, 0, 0, custInfo));

                        //         infoTable.AddCell(newCell("地址", 0, 1, 0, 0, custInfo));
                        //        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        //         infoTable.AddCell(newCell(address, 0, 6, 0, 0, custInfo));


                        infoTable.AddCell(newCell("Address", 0, 1, 0, 0, infoFont));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        PdfPCell addressCell = newCell(address, 0, 1, 0, 0, custInfo);
                        infoTable.AddCell(addressCell);
                        infoTable.AddCell(newCell(" ", 0, 3, 0, 0, infoFont));
                        infoTable.AddCell(newCell(" ", 0, 7, 0, 0, infoFont));
                        infoTable.AddCell(newCell(" ", 3, 7, 0, 0, infoFont));

                        infoTable.AddCell(newCell("發票", 1, 7, 1, 0, infoFont));
                        infoTable.AddCell(newCell("Invoice", 1, 7, 1, 0, infoFont));
                        doc.Add(infoTable);

                        doc.Add(addressTable);
                        detailTable.AddCell(newCell("單號", 2, 1, 0, 2, chfontT));

                        detailTable.AddCell(newCell("日期", 2, 1, 0, 2, chfontT));

                        detailTable.AddCell(newCell("貨品", 2, 3, 0, 2, chfontT));
                        detailTable.AddCell(newCell("類", 2, 1, 0, 2, chfontT));

                        detailTable.AddCell(newCell("數量", 2, 1, 2, 2, chfontT));
                        detailTable.AddCell(newCell(" ", 2, 1, 0, 2, chfontT));
                        detailTable.AddCell(newCell("單價", 2, 1, 2, 2, chfontT));
                        detailTable.AddCell(newCell("總數(港幣)", 2, 1, 2, 2, chfontT));
                        finish = false;
                        filled = false;
                    }
                    detailTable.AddCell(newCell(rdr["orderID"].ToString(), 1, 1, 0, 0, infoFont));

                    detailTable.AddCell(newCell(Convert.ToDateTime(rdr["time"]).ToString("dd-MM-yy"), 1, 1, 0, 0, infoFont));

                    detailTable.AddCell(newCell(rdr["itemName"].ToString(), 1, 3, 0, 0, infoFont));
                    detailTable.AddCell(newCell(rdr["priceType"].ToString().Substring(0, 1), 1, 1, 0, 0, infoFont));

                    detailTable.AddCell(newCell(rdr["amount"].ToString(), 1, 1, 2, 0, infoFont));
                    detailTable.AddCell(newCell(rdr["unit"].ToString().Substring(0, 1), 1, 1, 0, 0, infoFont));
                    detailTable.AddCell(newCell(rdr["unitPrice"].ToString(), 1, 1, 2, 0, infoFont));
                    detailTable.AddCell(newCell(rdr["total"].ToString(), 1, 1, 2, 0, infoFont));
                    sum += Convert.ToDecimal(rdr["total"].ToString());
                    doc.Add(detailTable);
                    rowCount++;
                    if (rdr["itemName"].ToString() == "洗水沙" || rdr["itemName"].ToString() == "天然沙")
                    {
                        sandTotalWeight += Convert.ToDecimal(rdr["amount"].ToString());
                    }

                }

                PdfPTable footer = new PdfPTable(8);
                footer.WidthPercentage = 100f;
                while (rowCount < 30)
                {
                    footer.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
                    rowCount++;
                }
                rowCount = 0;
                footer.AddCell(newCell(" ", 0, 10, 0, 2, infoFont));
                footer.AddCell(newCell(" ", 0, 4, 0, 0, infoFont));
                footer.AddCell(newCell("總噸數:", 0, 1, 0, 0, infoFont));
                footer.AddCell(newCell(sandTotalWeight.ToString("0.00"), 0, 1, 0, 0, infoFont));

                footer.AddCell(newCell("總數:", 0, 1, 0, 0, infoFont));
                footer.AddCell(newCell(sum.ToString("0.00"), 0, 2, 2, 0, infoFont));

                footer.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));

                footer.AddCell(newCell("請於收貨後30天內付清貨款.", 0, 10, 0, 0, infoFont));
                footer.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
                if (ch_compName.StartsWith("富"))
                {
                    footer.AddCell(newCell("富資建業有限公司", 0, 10, 0, 0, infoFont));
                    footer.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
                    footer.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));

                }
                else
                {
                    footer.AddCell(newCell("超誠建築材料倉有限公司", 0, 10, 0, 0, infoFont));
                    footer.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
                    footer.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));

                }


                footer.AddCell(newCell("多謝惠顧 祝生意興隆", 0, 10, 1, 0, infoFont));




                custTotal += sum;
                //   MessageBox.Show(sum.ToString());
                // MessageBox.Show("this is total " + custTotal);
                sum = 0.0m;
                //  footer.AddCell(newCell("客戶總數:", 0, 7, 0, 2, infoFont));
                //footer.AddCell(newCell(custTotal.ToString("0.00"), 0, 2, 2, 2, infoFont));
                custTotal = 0;
                doc.Add(footer);
                //     doc.Close();

            }
            if (doc.IsOpen())
            {
                doc.Close();

            }
            myConn.Close();

            cmd = new MySqlCommand("update CashPOSDB.custData set LastInvGenS = '" + beginning.ToString("yyyy-MM-dd") + "', LastInvGenE = '" + ending.ToString("yyyy-MM-dd") + "' where Code = '" + comp + "'", myConn);
            DBConnection.connDB();
            cmd.ExecuteNonQuery();
            myConn.Close();

          //  searchForInv(BelongTo.Substring(0, 2));
        }

        private PdfPCell newCell(iTextSharp.text.Phrase phrase, int colSpan)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.HorizontalAlignment = 0;
            cell.Padding = 0;
            cell.Border = 0;
            cell.Colspan = colSpan;
            return cell;
        }



        private PdfPCell newCell(string txt, int padding, int colSpan, int horAlig, int border, iTextSharp.text.Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(txt, font));
            cell.Border = border;
            cell.Colspan = colSpan;
            cell.Padding = padding;
            cell.HorizontalAlignment = horAlig; //0=Left, 1=Centre, 2=right
            return cell;
        }

        private PdfPCell newCellRowSpan(string txt, int padding, int colSpan, int horAlig, int border, iTextSharp.text.Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(txt, font));
            cell.Border = border;
            cell.Colspan = colSpan;
            cell.Padding = padding;
            cell.Rowspan = 2;
            cell.HorizontalAlignment = horAlig; //0=Left, 1=Centre, 2=right
            return cell;
        }
        private void createFooter(PdfPTable table, int rowCount, Document doc, iTextSharp.text.Font font)
        {
            while (rowCount < 30)
            {
                table.AddCell(newCell("a", 0, 8, 0, 0, font));
                rowCount++;
            }
            rowCount = 0;
            table.AddCell(newCell(" ", 0, 8, 0, 2, font));
            doc.Add(table);
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
