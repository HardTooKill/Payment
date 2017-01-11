using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment;

namespace BusinessLayer
{
   public static class BuildPaymentSlip
    {
        /// <summary>
        /// This method is used to populate payment slip by employee's annual salary infomation
        /// </summary>
        /// <param name="sa"></param>
        /// <returns></returns>
        public static PaymentSlip ConvertToPaymentSlip(Salary sa)
        {
            PaymentSlip ps = new PaymentSlip();
            return ps;
        }
    }
}
