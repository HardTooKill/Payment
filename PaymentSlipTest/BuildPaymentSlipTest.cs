using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using Payment;
using System.Collections.Generic;

namespace PaymentSlipTest
{
    /// <summary>
    /// This test is designed to test payment slip population and tax calculation methods
    /// </summary>
    [TestClass]
    public class BuildPaymentSlipTest
    {
        [TestMethod]
        public void ConvertToPaymentSlipTest()
        {
            //create sample data
            List<Salary> list = new List<Salary>();
            Salary sa1 = new Salary();
            sa1.FirstName = "FirstName";
            sa1.LastName = "LastName";
            sa1.PaymentPeriod = "March";
            sa1.AnnualSalary = 60000;
            sa1.SuperRate = 0.09d;

            List<PaymentSlip> paymentlist= BuildPaymentSlip.ConvertToPaymentSlip(list);

            //TODO: do a manual calculation on the sample data and compare with the result form the method
            Assert.IsTrue(paymentlist.Count == 1);
            Assert.IsTrue(paymentlist[0].Name.Equals("FirstName LastName"));
            
        }
        [TestMethod]
        public void GetIncomeTaxTest()
        {
            //TODO: To make a better test , need to add more test case for differen income in diffrent tax rate zones.
            int income1 = 22222;
            int income2 = 37800;


            Assert.IsTrue(BuildPaymentSlip.GetIncomeTax(income1) == 3656);
            Assert.IsTrue(BuildPaymentSlip.GetIncomeTax(income2) == 9999);
        }
    }
}
