using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;

namespace BooksWPF
{
    class AuthorNotValidRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string author;
            try
            {
                author = value.ToString();
            }
            catch (FormatException)
            {
                return new ValidationResult(false, "Author name not valid");
            }
            if (author.Any(char.IsDigit))
                return new ValidationResult(false, "Author name cannot have numbers");

            if (String.IsNullOrEmpty(author))
                return new ValidationResult(false, "Author name cannot be empty");

            return ValidationResult.ValidResult;
        }
    }
}
