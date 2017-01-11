using System;
using System.Collections.Generic;
using System.IO;
using Payment;

namespace BusinessLayer
{
    public static class CSVHelper
    {
        /// <summary>
        /// Get salary list from a csv file
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static List<Salary> GetSalaryFromCSV(System.IO.Stream stream)
        {
            List<Salary> list = new List<Salary>();
            string line = string.Empty;

            // Read the csv file line by line.  
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            while ((line = sr.ReadLine()) != null)
            {
                char[] csplit = { ',' };
                string[] temp = line.Split(csplit);
                Salary sl = new Salary();
                sl.FirstName = temp[0];
                sl.LastName = temp[1];
                sl.AnnualSalary = Convert.ToInt32(temp[2]);
                sl.SuperRate = Convert.ToDouble(temp[3].Replace("%", string.Empty)) / 100;
                sl.PaymentPeriod = temp[4];

                ///It's better to build a log message in the system. Currently if the validation is failed, just throw exception and display to users.
                string errormessage = DataValidation.SalaryValidate(sl);

                if (!string.IsNullOrEmpty(errormessage))
                {
                    throw new Exception(errormessage);

                }
                list.Add(sl);
            }

            sr.Close();

            return list;
        }
        /// <summary>
        /// output payment slip to csv file
        /// </summary>
        /// <param name="list"></param>
        /// <param name="path"></param>
        public static void WritePaymentSlipCSV(List<PaymentSlip> list, string path)
        {
            StreamWriter bw = new StreamWriter(File.Create(path));
            foreach (PaymentSlip ps in list)
            {
                string line = ps.Name + "," + ps.PaymentPeriod + "," + ps.GrossIncome.ToString() + "," + ps.IncomeTax.ToString() + "," + ps.NetIncome.ToString() + "," + ps.Super;
                bw.WriteLine(line);
            }
            bw.Close();
            bw.Dispose();
        }
    }
}

