using System;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        int[] dimensions = Console.ReadLine().Split()
                                             .Select(int.Parse)
                                             .ToArray();
        int rows = dimensions[0];
        int cols = dimensions[1];

        int[][] matrixField = new int[rows][];
        for (int row = 0; row < rows; row++)
        {
            matrixField[row] = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                                                 .Select(int.Parse)
                                                 .ToArray();
        }

        string bombArgs;
        while ((bombArgs = Console.ReadLine()) != "cease fire!")
        {
            string[] bombDmgAndCoords = bombArgs.Split();
            int bombRow = int.Parse(bombDmgAndCoords[0]);
            int bombCol = int.Parse(bombDmgAndCoords[1]);
            int bombDmg = char.Parse(bombDmgAndCoords[2]);

            PlaceTheDamage(matrixField, bombRow, bombCol, bombDmg, rows, cols);
        }

        int destroyCells = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (matrixField[row][col] <= 0)
                    destroyCells++;
            }
        }

        double damagedPercent = (destroyCells * 100) / (double)(rows * cols);
        Console.WriteLine("Destroyed bunkers: {0}", destroyCells);
        Console.WriteLine("Damage done: {0:f1} %", damagedPercent);
    }

    private static void PlaceTheDamage(int[][] matrixField, int bombRow, int bombCol, int bombDmg, int rows, int cols)
    {
        double bombHalfDmg = Math.Ceiling((double)bombDmg / 2);

        int startRow = bombRow - 1;
        int endRow = bombRow + 1;
        int startCol = bombCol - 1;
        int endCol = bombCol + 1;

        for (int row = startRow; row <= endRow; row++)
        {
            for (int col = startCol; col <= endCol; col++)
            {
                if (row >= 0 &&
                    row < rows &&
                    col >= 0 &&
                    col < cols)
                {
                    if (row == bombRow && col == bombCol)
                        matrixField[bombRow][bombCol] -= bombDmg;
                    else
                        matrixField[row][col] -= (int)bombHalfDmg;
                }
            }
        }
    }
}