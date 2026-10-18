using System.Text.RegularExpressions;

namespace Collections;

public static class StringValidationExtensions
{
    private static readonly Regex EgyptianPhoneRegex =
        new(@"^(0|\+20)1[0125]\d{8}$");

    private static readonly Regex EgyptianNationalIdRegex =
        new(@"^[23]\d{13}$");

    public static bool IsValidEgyptianPhone(this string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        return EgyptianPhoneRegex.IsMatch(value.Trim());
    }

    public static bool IsValidEgyptianNationalId(this string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        return EgyptianNationalIdRegex.IsMatch(value.Trim());
    }
}