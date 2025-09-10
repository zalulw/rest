﻿namespace Solution.DesktopApp.Converters;

public class ValidationResultToErrorMessagesConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not ValidationResult validationResult || validationResult.IsValid)
        {
            return null;
        }

        if(parameter == null)
        {
            return null;
        }

        var property = parameter as string;

        var errorMessages = validationResult.Errors
            .Where(e => e.PropertyName == property)
            .Select(e => e.ErrorMessage)
            .ToList();

        return string.Join(Environment.NewLine, errorMessages);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException("ConvertBack not implemented");
    }
}
