using System;
using System.Linq;

public class OneDimensionalArray
{
    private int[] elements;

    public OneDimensionalArray(params int[] values)
    {
        elements = values;
    }

    public OneDimensionalArray(string values)
    {
        try
        {
            elements = values.Split(',')
                             .Select(int.Parse)
                             .ToArray();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error parsing input: " + ex.Message);
            elements = new int[0];
        }
    }

    public int ZeroCount => elements.Count(x => x == 0);

    public int SumAfterFirstPositive()
    {
        int sum = 0;
        bool foundPositive = false;

        foreach (var element in elements)
        {
            if (foundPositive)
            {
                sum += Math.Abs(element);
            }

            if (!foundPositive && element > 0)
            {
                foundPositive = true;
            }
        }

        return sum;
    }
}
