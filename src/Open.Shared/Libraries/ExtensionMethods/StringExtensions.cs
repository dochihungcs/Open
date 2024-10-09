namespace Open.Shared.Libraries.ExtensionMethods;

public static partial class Extensions
{
    /// <summary>
    /// Chuyển camel case sang snake case lower
    /// </summary>
    public static string ToSnakeCaseLower(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentNullException(nameof(input));
        }

        return string.Concat(input.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString().ToLower() : x.ToString())).ToLower();
    }

    /// <summary>
    /// Chuyển camel case sang kebab case
    /// </summary>
    public static string ToKebabCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentNullException(nameof(input));
        }

        return string.Concat(input.Select((x, i) => i > 0 && char.IsUpper(x) ? "-" + x.ToString() : x.ToString()));
    }

    /// <summary>
    /// Chuyển camel case sang kebab case lower
    /// </summary>
    public static string ToKebabCaseLower(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentNullException(nameof(input));
        }

        return string.Concat(input.Select((x, i) => i > 0 && char.IsUpper(x) ? "-" + x.ToString().ToLower() : x.ToString())).ToLower();
    }
}
