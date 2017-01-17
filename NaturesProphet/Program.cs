using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class StartProg
{
    public static void Main()
    {
        List<Tuple<int, int>> gardenArgs = new List<Tuple<int, int>>();
        ReadInput(gardenArgs);

        int gardenRows = gardenArgs[0].Item1;
        int gardenCols = gardenArgs[0].Item2;
        gardenArgs.RemoveAt(0);

        int[,] garden = new int[gardenRows, gardenCols];
        FillGarden(gardenRows, gardenCols, garden);

        BloomingGarden(gardenArgs, gardenRows, gardenCols, garden);
        PrintGarden(gardenRows, gardenCols, garden);
    }

    private static void PrintGarden(int gardenRows, int gardenCols, int[,] garden)
    {
        for (int row = 0; row < gardenRows; row++)
        {
            for (int col = 0; col < gardenCols; col++)
            {
                Console.Write("{0} ", garden[row, col]);
            }
            Console.WriteLine();
        }
    }

    private static void BloomingGarden(List<Tuple<int, int>> gardenArgs, int gardenRows, int gardenCols, int[,] garden)
    {
        gardenArgs.ForEach(pair =>
        {
            int initRow = pair.Item1;
            int initCol = pair.Item2;

            for (int row = 0; row < gardenRows; row++)
            {
                //if (!row.Equals(initRow))
                garden[row, initCol]++;
            }
            for (int col = 0; col < gardenCols; col++)
            {
                if (!col.Equals(initCol))
                    garden[initRow, col]++;
            }
        });
    }

    private static void FillGarden(int gardenRows, int gardenCols, int[,] garden)
    {
        for (int row = 0; row < gardenRows; row++)
        {
            for (int col = 0; col < gardenCols; col++)
            {
                garden[row, col] = 0;
            }
        }
    }

    private static void ReadInput(List<Tuple<int, int>> gardenArgs)
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (input.Equals("Bloom Bloom Plow"))
                break;

            int[] inputArgs = input.Split()
                                   .Select(int.Parse)
                                   .ToArray();

            gardenArgs.Add(new Tuple<int, int>(inputArgs[0], inputArgs[1]));
        }
    }
}