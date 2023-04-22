using Domain.Common.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.ValueConverters;

public class NonEmptyStringConverter : ValueConverter<NonEmptyString, string>
{
    public NonEmptyStringConverter()
        : base(x => x.Value, x => new NonEmptyString(x)) { }
}