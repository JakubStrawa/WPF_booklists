using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;

namespace BooksWPF
{
    class TitleNotValidRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string title;
            try
            {
                title = value.ToString();
            }
            catch (FormatException)
            {
                return new ValidationResult(false, "Book title not valid");
            }
            catch (ArgumentOutOfRangeException)
            {
                return new ValidationResult(false, "Book title not valid");
            }
            if (String.IsNullOrEmpty(title))
                return new ValidationResult(false, "Book title cannot be empty");

            if (!title.Any(char.IsLetter))
                return new ValidationResult(false, "Book title must have letters");

            return ValidationResult.ValidResult;
        }
    }
}
