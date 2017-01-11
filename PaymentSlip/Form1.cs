using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using Payment;
namespace PaymentSlip
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Build in  payment slip list
        /// </summary>
        private List<Payment.PaymentSlip> _paymentsliplist = new List<Payment.PaymentSlip>();
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Load salary data from a csv file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            List<Salary> salarylist = new List<Salary>();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                             _paymentsliplist=BuildPaymentSlip.ConvertToPaymentSlip(CSVHelper.GetSalaryFromCSV(myStream));
                            dataGridView1.DataSource = _paymentsliplist;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }

         /// <summary>
         /// Export to a csv file
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csv File|*.csv";
            sfd.FileName = "PaymentSlip";
            sfd.Title = "Save Payment Slip";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = sfd.FileName;
                CSVHelper.WritePaymentSlipCSV(_paymentsliplist, path);
            }
        }
    }
}
