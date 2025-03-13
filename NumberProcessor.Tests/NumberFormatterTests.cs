using FluentAssertions;
using NumberProcessor.Core;
using System;

namespace NumberProcessor.Tests;

public class NumberFormatterTests
{
    [Fact]
    public void FormatValue_Should_Handle_Large_Numbers()
    {
        string result = NumberFormatter.FormatValue(1000000);

        result.Should().Be("Wells");
    }

    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(3, "Caleb")]
    [InlineData(5, "Wells")]
    [InlineData(6, "Caleb")]
    [InlineData(10, "Wells")]
    [InlineData(15, "Caleb Wells")]
    [InlineData(30, "Caleb Wells")]
    public void FormatValue_Should_Return_Correct_Formatted_Value(int input, string expected)
    {
        string result = NumberFormatter.FormatValue(input);

        result.Should().Be(expected);
    }

    [Fact]
    public void ProcessRange_Should_Not_Throw_Exception_With_Large_Value()
    {
        Action action = () => NumberFormatter.ProcessRange(1000);

        action.Should().NotThrow();
    }


    [Fact]
    public void ProcessRange_Should_Return_Correct_Sequence()
    {
        string expected = "1\r\n2\r\nCaleb\r\n4\r\nWells\r\nCaleb\r\n7\r\n8\r\nCaleb\r\nWells\r\n11\r\nCaleb\r\n13\r\n14\r\nCaleb Wells";

        string result = NumberFormatter.ProcessRange(15);

        result.Should().Be(expected);
    }

    [Fact]
    public void ProcessRange_Should_Return_Error_Message_From_Zero()
    {
        string result = NumberFormatter.ProcessRange(0);

        result.Should().Be("Upper bound must be at least 1");
    }

    [Fact]
    public void ProcessRange_Should_Return_Error_Message_When_Negative_Value()
    {
        string result = NumberFormatter.ProcessRange(-5);

        result.Should().Be("Upper bound must be at least 1");
    }

    [Fact]
    public void ProcessRange_Should_Return_Single_Value_From_One()
    {
        string result = NumberFormatter.ProcessRange(1);

        result.Should().Be("1");
    }
}
