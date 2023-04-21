using Domain.Common.Exceptions;

namespace Domain.Common.ValueObjects;

public struct NonEmptyString
{
    private string _value;

    public NonEmptyString(string value)
    {
        _value = ValidateNotEmpty(value);
    }

    public string Value
    {
        get => _value;
        set => _value = ValidateNotEmpty(value);
    }

    public override string ToString()
    {
        return _value;
    }

    private static string ValidateNotEmpty(string value)
    {
        if (value == string.Empty)
        {
            throw IncorrectValueException.EmptyString();
        }

        return value;
    }
}