using System.Collections.Generic;

namespace Payment
{
    /// <summary>
    /// This class is used to store temporary data if needed
    /// </summary>
    public class DataContext
    {
        public List<Salary> SalaryList { get; set; }
        public List<PaymentSlip> PaymentSlipList { get; set; }

        public DataContext()
        {
            PaymentSlipList = new List<PaymentSlip>();
            SalaryList = new List<Salary>();
        }
    }
}
