using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment;
using BusinessLayer;

namespace PaymentSlipTest
{
    /// <summary>
    /// This test class is used to test all the possible validation rule from reading in salary details. Test are created by busiess validation rules.
    /// I created some simple test cases for them but not all.
    /// </summary>
    [TestClass]
    public class DataValidationTest
    {
        [TestMethod]
        public void SalaryValidationWithMissingFirstNameTest()
        {
            Salary sa = new Salary();
            string errormessage= DataValidation.SalaryValidate(sa);
            Assert.IsTrue(errormessage.Equals("Cannot find employee's first name."));
        }
        [TestMethod]
        public void SalaryValidationWithMissingLastNameTest()
        {
            Salary sa = new Salary();
            sa.FirstName = "test";
            string errormessage = DataValidation.SalaryValidate(sa);
            Assert.IsTrue(errormessage.Equals("Cannot find employee's last name."));
        }
        [TestMethod]
        public void SalaryValidationWithMissingInvalidSalaryTest()
        {
            Salary sa = new Salary();
            sa.FirstName = "test";
            sa.LastName = "test";
            sa.AnnualSalary = -1;
            string errormessage = DataValidation.SalaryValidate(sa);
            Assert.IsTrue(errormessage.Equals("Annual salary cannot be negative value."));
        }
        [TestMethod]
        public void SalaryValidationWithMissingInvalidSuperRateTest()
        {
            Assert.Inconclusive();

        }        
    }
}
