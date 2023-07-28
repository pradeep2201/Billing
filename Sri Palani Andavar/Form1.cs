using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;

namespace Sri_Palani_Andavar
{
    public partial class dshbrd : Form
    {
        public dshbrd()
        {
            InitializeComponent();
        }
        public static decimal RESULT = 0;
        public static int Count = 1;

        private void listeditms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void totltxtbx_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void qtytxtbx_TextChanged(object sender, EventArgs e)
        {            
            
            try
            {
                decimal Sum;
                int Quantity = int.Parse(qtytxtbx.Text);
                //float Mrp = float.Parse(mrptxtbx.Text);

                string Final;
                int Integers;
                double Doubles;
                Doubles = double.Parse(mrptxtbx.Text);
                Integers = (int)Doubles;
                if (Integers == Doubles)
                {
                    Final = mrptxtbx.Text + ".00";
                }
                else
                {
                    Final = mrptxtbx.Text;
                }

                Sum = decimal.Parse(Final, CultureInfo.InvariantCulture) * Quantity;
                totltxtbx.Text = Sum.ToString();
            }
            catch { }            
        }

        private void mrptxtbx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal Sum;
                int Quantity = int.Parse(qtytxtbx.Text);
                //float Mrp = float.Parse(mrptxtbx.Text);

                string Final;
                int Integers;
                double Doubles;
                Doubles = double.Parse(mrptxtbx.Text);
                Integers = (int)Doubles;
                if (Integers == Doubles)
                {
                    Final = mrptxtbx.Text + ".00";
                }
                else
                {
                    Final = mrptxtbx.Text;
                }

                Sum = decimal.Parse(Final, CultureInfo.InvariantCulture) * Quantity;
                totltxtbx.Text = Sum.ToString();
            }
            catch { }
        }
        
        private void adbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string Final;
                int Integers;
                double Doubles;
                Doubles = double.Parse(mrptxtbx.Text);
                Integers = (int)Doubles;
                if (Integers == Doubles)
                {
                    Final = mrptxtbx.Text + ".00";
                }
                else
                {
                    Final = mrptxtbx.Text;
                }
                listeditms.Rows.Add(Count, prtclrtxtbx.Text, qtytxtbx.Text, Final, totltxtbx.Text);

                if (qtytxtbx.Text == "" || mrptxtbx.Text == "")
                {
                    qtytxtbx.Text = "0";
                    mrptxtbx.Text = "0";
                }

                Count++;
                snotxtbx.Text = Count.ToString();

                RESULT += Convert.ToDecimal(totltxtbx.Text);

                prtclrtxtbx.Text = "";
                qtytxtbx.Text = "";
                mrptxtbx.Text = "";
                totltxtbx.Text = "";
            }
            catch 
            {
                MessageBox.Show("Quantity or rate is empty","Warning",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            //if (Count > 15)
            //{
            //    MessageBox.Show("Generate a new bill" , MessageBoxIcon.Exclamation.ToString(),MessageBoxButtons.OK);
                
            //}
        }
        
        private void clrbtn_Click(object sender, EventArgs e)
        {
            snotxtbx.Text = "";
            prtclrtxtbx.Text = "";
            qtytxtbx.Text = "";
            mrptxtbx.Text = "";
            totltxtbx.Text = "";
            Count = 1;
        }

        private void snotxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void qtytxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void mrptxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char ch = e.KeyChar;
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void delbtn_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = listeditms.CurrentCell.RowIndex;
                listeditms.Rows.RemoveAt(rowIndex);
            }
            catch 
            {
            }
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //e.Graphics.DrawString("SRI PALANI ANDAVAR HARDWARES", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(250, 25));
            //e.Graphics.DrawString("Eswaran kovil Turn, \n Nangavalli, \n Mettur(TK),\n Salem(D), \n Ph : +91 93619 58286.", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, 60));
            //e.Graphics.DrawString("__________________________________________________________________", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(10, 140));
            //e.Graphics.DrawString("ESTIMATE BILL", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(330, 180));
            //e.Graphics.DrawString("Invoice No : " + invctxtbx.Text + "", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(20, 230));
            //e.Graphics.DrawString("Customer Name : " + cstmrnmtxtbx.Text + "", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(20, 290));
            //e.Graphics.DrawString("Date : " + DateTime.Now.ToShortDateString() + "", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(550, 230));
            //e.Graphics.DrawString("BILL TIME : " + DateTime.Now.ToShortDateString() + "", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(550, 290));
            //e.Graphics.DrawString("__________________________________________________________________", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(10, 310));
            //e.Graphics.DrawString("S.No", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(20, 350));
            //e.Graphics.DrawString("PARTICULARS", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(100, 350));
            //e.Graphics.DrawString("QUANTITY", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(500, 350));
            //e.Graphics.DrawString("RATE", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(640, 350));
            //e.Graphics.DrawString("TOTAL", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(730, 350));
            //e.Graphics.DrawString("__________________________________________________________________", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(10, 370));

            //for (int i = 0; i < listeditms.Rows.Count - 1; i++)
            //{
            //    for (int j = 0; j < listeditms.Columns.Count; j++)
            //    {
            //        e.Graphics.DrawString(listeditms.Rows[i].Cells[j].Value.ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(ADDX[j], ADDY[i]));
            //    }
            //}
            //e.Graphics.DrawString("__________________________________________________________________", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(10, 1000));
            //e.Graphics.DrawString("TOTAL : " + RESULT + "", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(600, 1040));
            //e.Graphics.DrawString("THANK YOU !!! HAVE A NICE DAY", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(300, 1080));
        }
        public int[] ADDX = { 20, 100,500,640,740 };
        public int[] ADDY = { 420,460,500,540,580,620,660,700,740,780,820,860,900,940,980 };
        public string ConvertNumbertoWords(long number)
        {
            if (number == 0) return "ZERO";
            if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
            string words = "";
            if ((number / 1000000) > 0)
            {
                words += ConvertNumbertoWords(number / 100000) + " LAKES ";
                number %= 1000000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
                number %= 100;
            }
            //if ((number / 10) > 0)  
            //{  
            // words += ConvertNumbertoWords(number / 10) + " RUPEES ";  
            // number %= 10;  
            //}  
            if (number > 0)
            {
                if (words != "") words += "AND ";
                var unitsMap = new[]
                {
            "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"
        };
                var tensMap = new[]
                {
            "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"
        };
                if (number < 20) words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0) words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }

        private void prntbtn_Click(object sender, EventArgs e)
        {
            Count = 1;

            long Words = decimal.ToInt32(RESULT);

            DGVPrinter Printer = new DGVPrinter();
            Printer.Title = "SRI PALANI ANDAVAR HARDWARES";
            Printer.TitleSpacing = 25;
            Printer.SubTitleSpacing= 15;
            Printer.PageNumbers = false;
            Printer.SubTitle = string.Format("Bill.No : "+invctxtbx.Text+"                                                       Customer Name : "+cstmrnmtxtbx.Text+ "\n\n Date : "+DateTime.Now+"\n\n                                               ESTIMATE BILL ", Printer.SubTitleAlignment = StringAlignment.Near);
            //Printer.PageSettings.PaperSize = new PaperSize();
            //PaperSize paper = new PaperSize();
            //paper.Width.ToString("20");
            //paper.Height.ToString("30");
            Printer.FooterAlignment = StringAlignment.Center;
            Printer.Footer = " "+ConvertNumbertoWords(Words)+" RUPEES ONLY                        Total : "+RESULT.ToString();
            Printer.FooterSpacing = 0;
            Printer.PrintPreviewDataGridView(listeditms);

            //printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.ShowDialog();

            listeditms.Rows.Clear();
            invctxtbx.Text = "";
            cstmrnmtxtbx.Text = "";

            //RESULT = 0;
        }

        private void snotxtbx_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cstmrnmlbl_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
