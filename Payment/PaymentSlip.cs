using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment
{
    public class PaymentSlip
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PaymentPeriod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int GrossIncome { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int IncomeTax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int NetIncome { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Super { get; set; }

    }
}
