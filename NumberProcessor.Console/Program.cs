using NumberProcessor.Core;

Console.Write("Enter the upper bound: ");
if(int.TryParse(Console.ReadLine(), out int upperBound))
{
    Console.WriteLine(NumberFormatter.ProcessRange(upperBound));
} else
{
    Console.WriteLine("Invalid input. Please enter a valid number.");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
