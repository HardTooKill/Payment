using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment
{
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
