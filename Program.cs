public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter elements for the one-dimensional array (comma-separated):");
        string oneDInput = Console.ReadLine();

        OneDimensionalArray oneDArray = new OneDimensionalArray(oneDInput);

        Console.WriteLine("One Dimensional Array:");
        Console.WriteLine("Count of zeros: " + oneDArray.ZeroCount);
        Console.WriteLine("Sum after first positive: " + oneDArray.SumAfterFirstPositive());

        Console.WriteLine("\nEnter elements for the two-dimensional array (comma-separated, must be a perfect square):");
        string twoDInput = Console.ReadLine();

        TwoDimensionalArray twoDArray = new TwoDimensionalArray(twoDInput);

        Console.WriteLine("\nTwo Dimensional Array:");
        Console.WriteLine("Count of zeros: " + twoDArray.ZeroCount);
        Console.WriteLine("Sum below secondary diagonal: " + twoDArray.SumBelowSecondaryDiagonal());

        Console.WriteLine("Array before zeroing out and sorting:");
        twoDArray.Display();

        twoDArray.ZeroOutNonSortedArea();
        Console.WriteLine("After zeroing out non-sorted area:");
        twoDArray.Display();

        twoDArray.SortAreaB6();
        Console.WriteLine("After sorting area:");
        twoDArray.Display();
    }
}
