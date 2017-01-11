using System;
using System.Collections.Generic;
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
        public static List<PaymentSlip> ConvertToPaymentSlip(List<Salary> salaryList)
        {
            List<PaymentSlip> paymentlist = new List<PaymentSlip>();

            foreach (Salary sl in salaryList)
            {
                PaymentSlip ps = new PaymentSlip();
                ps.Name = sl.FirstName + " " + sl.LastName;
                ps.PaymentPeriod = sl.PaymentPeriod;
                ps.GrossIncome =(int)Math.Round((double)sl.AnnualSalary / 12);
                ps.IncomeTax = (int)Math.Round((double)GetIncomeTax(sl.AnnualSalary)/12);
                ps.NetIncome = ps.GrossIncome - ps.IncomeTax;
                ps.Super = (int)Math.Round(ps.GrossIncome * sl.SuperRate);
                paymentlist.Add(ps);
             }
            return paymentlist;
        }

        /// <summary>
        /// Tax calculator
        /// </summary>
        /// <param name="income"></param>
        /// <returns></returns>
        public static int GetIncomeTax(int income)
        {
            if (income <= 18200) return 0;
            else if (income >= 18201 && income <= 37000)
            {
                return (int)Math.Round((income - 18200) * 0.19);
            }
            else if (income >= 37001 && income <= 80000)
            {
                return 3572 + (int)Math.Round((income - 37000) * 0.325);
            }
            else if (income >= 80001 && income <= 180000)
            {
                return 17547 + (int)Math.Round((income - 80000) * 0.37);
            }
            else
            {
                return 54547 + (int)Math.Round((income - 180000) * 0.45);
            }
        }
    }
}
