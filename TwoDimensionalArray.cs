using System;
using System.Collections.Generic;
using System.Linq;

public class TwoDimensionalArray
{
    private int[,] elements;

    public TwoDimensionalArray(params int[] values)
    {
        int size = (int)Math.Sqrt(values.Length);
        elements = new int[size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                elements[i, j] = values[i * size + j];
            }
        }
    }

    public TwoDimensionalArray(string values)
    {
        try
        {
            var rows = values.Split(',').Select(int.Parse).ToArray();
            int size = (int)Math.Sqrt(rows.Length);
            elements = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    elements[i, j] = rows[j * size + i];
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error parsing input: " + ex.Message);
            elements = new int[0, 0]; // Set to empty array on error
        }
    }

    public int ZeroCount => elements.Cast<int>().Count(x => x == 0);

    public void Display()
    {
        int rows = elements.GetLength(0);
        int cols = elements.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(elements[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public int SumBelowSecondaryDiagonal()
    {
        int sum = 0;
        int size = elements.GetLength(0);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (i + j >= size)
                {
                    sum += Math.Abs(elements[i, j]);
                }
            }
        }

        return sum;
    }

    public void ZeroOutNonSortedArea()
    {
        int size = elements.GetLength(0);

        // Обнулення всіх елементів над областю B6
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (i + j < size - 1) // Якщо елемент знаходиться над областю B6
                {
                    elements[i, j] = 0; // Обнулення
                }
                if (i + j > size && elements[i, j] != 0)
                {
                    elements[i, j] = 0;
                }
            }
        }
    }



    public void SortAreaB6()
    {
        int size = elements.GetLength(0);
        List<int> areaToSort = new List<int>();
        HashSet<(int, int)> zeroPosition = new HashSet<(int, int)>();

        // Вибір елементів з області B6 (на або під другою діагоналлю)
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (elements[i, j] == 0 && (i + j < size - 1 || i + j > size)) // Якщо елемент належить області B6
                {
                    zeroPosition.Add((i, j));
                }
                else
                {
                    areaToSort.Add(elements[i, j]);
                }
            }
        }

        // Сортування вибраних елементів
        areaToSort.Sort();

        // Запис відсортованих елементів назад у область B6
        int index = 0;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (i + j >= size - 1) // Якщо елемент належить області B6
                {
                    {
                        if (!zeroPosition.Contains((i, j)))
                        {
                            elements[i, j] = areaToSort[index];
                            index++;
                        }
                    }
                }
            }
        }



    }
}
