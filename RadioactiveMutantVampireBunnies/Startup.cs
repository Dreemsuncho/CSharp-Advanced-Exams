using System;
using System.Collections.Generic;
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

        char[][] bunnyLair = new char[rows][];

        int playerRow = int.MinValue;
        int playerCol = int.MinValue;
        for (int row = 0; row < rows; row++)
        {
            bunnyLair[row] = Console.ReadLine().ToCharArray();
            if (bunnyLair[row].Contains('P'))
            {
                playerRow = row;
                playerCol = Array.IndexOf(bunnyLair[row], 'P');
            }
        }

        bool playerIsWin = true;
        char[] directions = Console.ReadLine().ToCharArray();

        foreach (var dir in directions)
        {
            int lastPlayerRow = playerRow;
            int lastPlayerCol = playerCol;

            switch (dir)
            {
                case 'L':
                    bunnyLair[playerRow][playerCol] = '.';

                    if (playerCol > 0 &&
                        bunnyLair[playerRow][playerCol - 1] != 'B')
                    {
                        bunnyLair[playerRow][playerCol - 1] = 'P';
                    }
                    playerCol--;

                    BunnySpread(bunnyLair, rows, cols);
                    break;

                case 'R':
                    bunnyLair[playerRow][playerCol] = '.';

                    if (playerCol < (cols - 1) &&
                        bunnyLair[playerRow][playerCol + 1] != 'B')
                    {
                        bunnyLair[playerRow][playerCol + 1] = 'P';
                    }
                    playerCol++;

                    BunnySpread(bunnyLair, rows, cols);
                    break;

                case 'U':
                    bunnyLair[playerRow][playerCol] = '.';

                    if (playerRow > 0 &&
                        bunnyLair[playerRow - 1][playerCol] != 'B')
                    {
                        bunnyLair[playerRow - 1][playerCol] = 'P';
                    }
                    playerRow--;

                    BunnySpread(bunnyLair, rows, cols);
                    break;

                case 'D':
                    bunnyLair[playerRow][playerCol] = '.';

                    if (playerRow < (rows - 1) &&
                        bunnyLair[playerRow + 1][playerCol] != 'B')
                    {
                        bunnyLair[playerRow + 1][playerCol] = 'P';
                    }
                    playerRow++;

                    BunnySpread(bunnyLair, rows, cols);
                    break;
                default:
                    break;
            }

            if (playerRow < 0 ||
                playerRow >= rows ||
                playerCol < 0 ||
                playerCol >= cols)
            {
                playerRow = lastPlayerRow;
                playerCol = lastPlayerCol;
                break;
            }
            else if (bunnyLair[playerRow][playerCol] == 'B')
            {
                playerIsWin = false;
                break;
            }
        }

        for (int row = 0; row < rows; row++)
        {
            Console.WriteLine(string.Join("", bunnyLair[row]));
        }
        if (playerIsWin)
            Console.WriteLine("won: {0} {1}", playerRow, playerCol);
        else
            Console.WriteLine("dead: {0} {1}", playerRow, playerCol);
    }

    private static void BunnySpread(char[][] bunnyLair, int rows, int cols)
    {
        List<int[]> occupiedCells = new List<int[]>();

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (bunnyLair[row][col] == 'B' &&
                    row >= 0 &&
                    row < rows &&
                    col >= 0 &&
                    col < cols)
                {
                    if (row > 0)
                        occupiedCells.Add(new[] { row - 1, col });
                    if (row < rows - 1)
                        occupiedCells.Add(new[] { row + 1, col });
                    if (col > 0)
                        occupiedCells.Add(new[] { row, col - 1 });
                    if (col < cols - 1)
                        occupiedCells.Add(new[] { row, col + 1 });
                }
            }
        }

        occupiedCells.ForEach(c => bunnyLair[c[0]][c[1]] = 'B');
    }
}