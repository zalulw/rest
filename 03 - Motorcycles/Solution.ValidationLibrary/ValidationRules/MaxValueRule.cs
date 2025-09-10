﻿namespace Solution.ValidationLibrary.ValidationRules;

public class MaxValueRule<T>(int maxValue) : IValidationRule<T>
{
    public string ValidationMessage { get; set; } = $"Value can't be larger then {maxValue}.";

    public bool Check(object value)
    {
        if (!int.TryParse(value?.ToString(), out int data))
        {
            return false;
        }

        return data <= maxValue;
    }
}
