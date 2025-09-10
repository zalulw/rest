﻿namespace Solution.DesktopApp.Converters;

internal class ValidationResultToHasErrorConverter
{
    public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not ValidationResult validationResult || parameter == null)
        {
            return null;
        }

        if (validationResult.IsValid)
        {
            return null;
        }

        var property = parameter as string;

        return validationResult.Errors.Any(x => x.PropertyName == property);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException("ConvertBack not implemented");
    }
}
