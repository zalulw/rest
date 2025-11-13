using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DekstopApp.Converters
{
    public class ValidationResultToErrorMessageConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if(value is not ValidationResultToErrorMessageConverter validationResult || validationResult.IsValid)
            {
                return null;
            }

            if(parameter == null)
            {
                return null;
            }

            var property = parameter as string;
            var errorMessage = validationResult.Errors.Where(x => x.PropertyName == property).Select(x => x.ErrorMessage).FirstOrDefault();

            return string.Join(Environment.NewLine, errorMessage);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Convertback not implemented for the converter");
        }
    }
}
