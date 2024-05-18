using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallengeFIAP.Domain.Validations
{
    public class BirthDateAttribute : ValidationAttribute
    {
        private readonly string _dateFormat;

        public BirthDateAttribute(string dateFormat = "yyyy-MM-dd")
        {
            _dateFormat = dateFormat;
            ErrorMessage = $"Date of birth must be in the format {_dateFormat} and must be a valid date.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (value is string dateString && DateTime.TryParseExact(dateString, _dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                if (date > DateTime.Now)
                {
                    return new ValidationResult("Date of birth cannot be in the future.");
                }
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
