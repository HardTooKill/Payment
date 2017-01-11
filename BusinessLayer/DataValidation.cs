using Payment;

namespace BusinessLayer
{
    public static class DataValidation
    {
        /// <summary>
        /// Validate data from csv file
        /// </summary>
        /// <param name="sal"></param>
        /// <returns></returns>
        public static string SalaryValidate(Salary sal)
        {
            string errormessage = string.Empty;
            if (string.IsNullOrEmpty(sal.FirstName))
            {
                return "Cannot find employee's first name.";
            }
            if (string.IsNullOrEmpty(sal.LastName))
            {
                return "Cannot find employee's last name.";
            }
            if (sal.AnnualSalary < 0)
            {
                return "Annual salary cannot be negative value.";
            }
            if (sal.SuperRate < 0)
            {
                return "The rate of Super cannot be negative value.";
            }
            /// there should be more business rule for super rate validation

            /// there should be validation for payment period 

            return string.Empty;
        }
    }
}
