using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;

namespace BooksWPF
{
    class IDNotValidRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            long number;
            try
            {
                number = Int32.Parse(value.ToString());
            }
            catch (FormatException)
            {
                return new ValidationResult(false, "ID not valid, must be a 32bit number");
            }
            catch (OverflowException)
            {
                return new ValidationResult(false, "ID too long, must be a 32bit number");
            }
            if (number < 0)
                return new ValidationResult(false, "ID must be an positive number");


            return ValidationResult.ValidResult;
        }
    }
}
