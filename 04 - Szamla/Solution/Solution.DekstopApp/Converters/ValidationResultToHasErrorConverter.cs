using System;
using System.Collections.Generic;
using System.Globalization;
using FluentValidation;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Solution.DekstopApp.Converters
{
    public class ValidationResultToHasErrorConverter:IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if(value is not ValidationResult validationResult || parameter == null)
            {
                return null;
            }

            if(validationResult.IsValid)
            {
                return false;
            }

            var property = parameter as string;

            return validationResult.Errors.Any(x => x.PropertyName == property);

        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Convertback not implemented for the converter");
        }
    }
}
