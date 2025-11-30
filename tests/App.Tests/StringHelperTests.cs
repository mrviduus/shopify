using Xunit;
using App;

namespace App.Tests;

public class StringHelperTests
{
    [Theory]
    [InlineData(null, true)]
    [InlineData("", true)]
    [InlineData("hello", false)]
    public void IsNullOrEmpty_ReturnsExpected(string? input, bool expected) =>
        Assert.Equal(expected, StringHelper.IsNullOrEmpty(input));

    [Theory]
    [InlineData(null, true)]
    [InlineData("", true)]
    [InlineData("   ", true)]
    [InlineData("hello", false)]
    public void IsNullOrWhiteSpace_ReturnsExpected(string? input, bool expected) =>
        Assert.Equal(expected, StringHelper.IsNullOrWhiteSpace(input));

    [Fact]
    public void ToLower_ConvertsToLowerCase() =>
        Assert.Equal("hello", StringHelper.ToLower("HELLO"));

    [Fact]
    public void ToUpper_ConvertsToUpperCase() =>
        Assert.Equal("HELLO", StringHelper.ToUpper("hello"));

    [Fact]
    public void Trim_RemovesWhitespace() =>
        Assert.Equal("hello", StringHelper.Trim("  hello  "));

    [Fact]
    public void NormalizeWhitespace_CollapsesMultipleSpaces() =>
        Assert.Equal("hello world", StringHelper.NormalizeWhitespace("  hello   world  "));

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Tokenize_EmptyInput_ReturnsEmpty(string? input) =>
        Assert.Empty(StringHelper.Tokenize(input));

    [Fact]
    public void Tokenize_SplitsAndLowercases()
    {
        var tokens = StringHelper.Tokenize("Hello, World!").ToList();
        Assert.Equal(new[] { "hello", "world" }, tokens);
    }

    [Fact]
    public void TokenizeFields_CombinesMultipleFields()
    {
        var tokens = StringHelper.TokenizeFields("Hello", null, "World").ToList();
        Assert.Equal(new[] { "hello", "world" }, tokens);
    }

    [Theory]
    [InlineData("Hello World", "world", true, true)]
    [InlineData("Hello World", "world", false, false)]
    [InlineData("Hello World", "foo", true, false)]
    public void Contains_ReturnsExpected(string input, string value, bool ignoreCase, bool expected) =>
        Assert.Equal(expected, StringHelper.Contains(input, value, ignoreCase));

    [Theory]
    [InlineData("Hello World", "hello", true, true)]
    [InlineData("Hello World", "hello", false, false)]
    public void StartsWith_ReturnsExpected(string input, string value, bool ignoreCase, bool expected) =>
        Assert.Equal(expected, StringHelper.StartsWith(input, value, ignoreCase));

    [Theory]
    [InlineData("Hello World", "world", true, true)]
    [InlineData("Hello World", "world", false, false)]
    public void EndsWith_ReturnsExpected(string input, string value, bool ignoreCase, bool expected) =>
        Assert.Equal(expected, StringHelper.EndsWith(input, value, ignoreCase));

    [Fact]
    public void Replace_ReplacesSubstring() =>
        Assert.Equal("hi world", StringHelper.Replace("hello world", "hello", "hi"));

    [Theory]
    [InlineData("hello", 0, 3, "hel")]
    [InlineData("hello", 0, 10, "hello")]
    [InlineData("hello", 10, 3, "")]
    [InlineData("hello", -1, 3, "")]
    public void SubstringSafe_ReturnsExpected(string input, int start, int length, string expected) =>
        Assert.Equal(expected, StringHelper.SubstringSafe(input, start, length));

    [Fact]
    public void Join_JoinsWithSeparator() =>
        Assert.Equal("a,b,c", StringHelper.Join(new[] { "a", "b", "c" }));

    [Fact]
    public void BuildString_UsesBuilder()
    {
        var result = StringHelper.BuildString(sb => sb.Append("hello").Append(" world"));
        Assert.Equal("hello world", result);
    }
}
