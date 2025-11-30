using System.Text;
using System.Text.RegularExpressions;

namespace App;

public static class StringHelper
{
    // Regex that splits on anything not a letter or digit (best for search)
    private static readonly Regex TokenSplitPattern =
        new(@"[^\p{L}\p{N}]+", RegexOptions.Compiled);

    // ------------------------------------------
    // BASIC CHECKS
    // ------------------------------------------

    public static bool IsNullOrEmpty(string? input) =>
        string.IsNullOrEmpty(input);

    public static bool IsNullOrWhiteSpace(string? input) =>
        string.IsNullOrWhiteSpace(input);

    // ------------------------------------------
    // NORMALIZATION
    // ------------------------------------------

    public static string ToLower(string input) =>
        input.ToLowerInvariant();

    public static string ToUpper(string input) =>
        input.ToUpperInvariant();

    public static string Trim(string input) =>
        input.Trim();

    public static string NormalizeWhitespace(string input) =>
        Regex.Replace(input, @"\s+", " ").Trim();

    // ------------------------------------------
    // TOKENIZATION
    // ------------------------------------------

    /// <summary>
    /// Split into lowercase tokens using universal non-letter/number separators.
    /// Perfect for search and indexing.
    /// </summary>
    public static IEnumerable<string> Tokenize(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return Enumerable.Empty<string>();

        return TokenSplitPattern
            .Split(input.ToLowerInvariant())
            .Where(t => t.Length > 0);
    }

    /// <summary>
    /// Tokenize multiple fields together (e.g., name + vendor + description)
    /// </summary>
    public static IEnumerable<string> TokenizeFields(params string?[] fields) =>
        fields.Where(f => !string.IsNullOrWhiteSpace(f))
              .SelectMany(f => Tokenize(f!));

    // ------------------------------------------
    // CONTAINS / PREFIX / SUFFIX
    // ------------------------------------------

    public static bool Contains(string input, string value, bool ignoreCase = true)
    {
        return ignoreCase
            ? input.Contains(value, StringComparison.OrdinalIgnoreCase)
            : input.Contains(value);
    }

    public static bool StartsWith(string input, string value, bool ignoreCase = true)
    {
        return ignoreCase
            ? input.StartsWith(value, StringComparison.OrdinalIgnoreCase)
            : input.StartsWith(value);
    }

    public static bool EndsWith(string input, string value, bool ignoreCase = true)
    {
        return ignoreCase
            ? input.EndsWith(value, StringComparison.OrdinalIgnoreCase)
            : input.EndsWith(value);
    }

    // ------------------------------------------
    // SUBSTRINGS & REPLACEMENT
    // ------------------------------------------

    public static string Replace(string input, string from, string to) =>
        input.Replace(from, to);

    public static string SubstringSafe(string input, int start, int length)
    {
        if (start < 0 || start >= input.Length) return string.Empty;
        if (start + length > input.Length) length = input.Length - start;
        return input.Substring(start, length);
    }

    // ------------------------------------------
    // JOINING & BUILDING
    // ------------------------------------------

    public static string Join(IEnumerable<string> items, string separator = ",") =>
        string.Join(separator, items);

    public static string BuildString(Action<StringBuilder> builderAction)
    {
        var sb = new StringBuilder();
        builderAction(sb);
        return sb.ToString();
    }
}
