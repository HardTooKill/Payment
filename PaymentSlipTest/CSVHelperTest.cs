using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;

namespace PaymentSlipTest
{
    /// <summary>
    /// This test class is used to test reading and writing CSV files.
    /// File location is hacked just for demo.
    [TestClass]
    public class CSVHelperTest
    {
        [TestMethod]
        public void GetSalaryFromCSVTest()
        {
         
            //HACK: this should be the local test csv file's path
            string fileurl = "test";
            Stream str = File.OpenRead(fileurl);

            List<Payment.Salary> list = BusinessLayer.CSVHelper.GetSalaryFromCSV(str);

            Assert.IsTrue(list.Count > 0);

            //TODO: Test all the data based on the test csv file.

        }
        [TestMethod]
        public void WritePaymentSlipCSVTest()
        {
            //HACK: this should be the test output location
            string filelocation = "test";
            List<Payment.PaymentSlip> list = new List<Payment.PaymentSlip>();
            
            //TODO insert some test data
            Payment.PaymentSlip ps = new Payment.PaymentSlip();
            list.Add(ps);

            BusinessLayer.CSVHelper.WritePaymentSlipCSV(list, filelocation);

            //TODO read the output file again and compare with original data value.

        }
    }
}
