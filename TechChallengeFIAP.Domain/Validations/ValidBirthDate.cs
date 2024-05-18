using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallengeFIAP.Domain.Validations
{
    public static class ValidBirthDate
    {
        public static bool IsValidBirthDate(string dateString, out string errorMessage)
        {
            errorMessage = null;
            var dateFormat = "yyyy-MM-dd";

            if (string.IsNullOrEmpty(dateString))
            {
                errorMessage = "Date of birth is required.";
                return false;
            }

            if (!DateTime.TryParseExact(dateString, dateFormat, null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                errorMessage = $"Date of birth must be in the format {dateFormat} and must be a valid date.";
                return false;
            }

            if (date > DateTime.Now)
            {
                errorMessage = "Date of birth cannot be in the future.";
                return false;
            }

            return true;
        }
    }
}
