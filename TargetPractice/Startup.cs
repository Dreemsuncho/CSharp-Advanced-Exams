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


        char[,] matrix = new char[rows, cols];

        string snake = Console.ReadLine();
        FillMatrix(rows, cols, matrix, snake);


        int[] coords = Console.ReadLine().Split()
                                         .Select(int.Parse)
                                         .ToArray();
        int targetRow = coords[0];
        int targetCol = coords[1];
        int splashRange = coords[2];

        DamagingSnake(rows, cols, matrix, targetRow, targetCol, splashRange);
        FallingChars(rows, cols, matrix);

        PrintMatrix(rows, cols, matrix);
    }

    private static void FallingChars(int rows, int cols, char[,] matrix)
    {
        for (int col = (cols - 1); col >= 0; col--)
        {
            for (int row = (rows - 2); row >= 0; row--)
            {
                if (matrix[row, col] != ' ' &&
                    matrix[row + 1, col] == ' ')
                {
                    matrix[row + 1, col] = matrix[row, col];
                    matrix[row, col] = ' ';
                    if(row < rows - 2) row += 2;
                }
            }
        }
    }

    private static void DamagingSnake(int rows, int cols, char[,] matrix, int targetRow, int targetCol, int splashRange)
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (Math.Pow(row - targetRow, 2) +
                    Math.Pow(col - targetCol, 2) <=
                    Math.Pow(splashRange, 2))
                {
                    matrix[row, col] = ' ';
                }
            }
        }
    }

    private static void PrintMatrix(int rows, int cols, char[,] matrix)
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write("{0}", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }

    private static void FillMatrix(int rows, int cols, char[,] matrix, string snake)
    {
        int ind = 0;
        for (int row = (rows - 1); row >= 0; row--)
        {
            for (int col = (cols - 1); col >= 0; col--)
            {
                matrix[row, col] = snake[ind++ % snake.Length];
            }

            if (row > 0) row--; else break;

            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = snake[ind++ % snake.Length];
            }
        }
    }
}