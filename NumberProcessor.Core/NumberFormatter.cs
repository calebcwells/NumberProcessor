
namespace NumberProcessor.Core;

public static class NumberFormatter
{
    public static string FormatValue(int i) => (i % 3, i % 5) switch
    {
        (0, 0) => "Caleb Wells",
        (0, _) => "Caleb",
        (_, 0) => "Wells",
        _ => i.ToString()
    };

    public static string ProcessRange(int upperBound)
    {
        if(upperBound < 1)
            return "Upper bound must be at least 1";

        return string.Join(Environment.NewLine, Enumerable.Range(1, upperBound).Select(FormatValue));
    }
}
