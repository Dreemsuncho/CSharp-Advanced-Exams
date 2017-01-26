using System;
using System.Collections.Generic;
using System.Linq;

public class Coord
{
    public int x { get; set; }
    public int y { get; set; }

    public Coord(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

public class StartProg
{
    public static void Main()
    {
        int[] galaxySize = Console.ReadLine().Split()
                                             .Select(int.Parse)
                                             .ToArray();
        int rows = galaxySize[0];
        int cols = galaxySize[1];


        Queue<Coord> ivoCoords = new Queue<Coord>();
        Queue<Coord> evilCoords = new Queue<Coord>();

        ReadIvoAndEvilCoords(ivoCoords, evilCoords);

        int[,] galaxyMatrix = new int[rows, cols];
        FillGalaxy(rows, cols, galaxyMatrix);

        long ivoStat = IvoAndEvilCollectTheStars(rows, cols, ivoCoords, evilCoords, galaxyMatrix);

        Console.WriteLine(ivoStat);
    }

    private static long IvoAndEvilCollectTheStars(int rows, int cols, Queue<Coord> ivoCoords, Queue<Coord> evilCoords, int[,] galaxyMatrix)
    {
        long totalStars = 0;

        while (ivoCoords.Count > 0)
        {
            Coord currEvilCoord = evilCoords.Dequeue();
            int row = currEvilCoord.x;
            int col = currEvilCoord.y;

            while (row >= 0 || col >= 0)
            {
                if (row > -1 &&
                    row < rows &&
                    col > -1 &&
                    col < cols)
                {
                    galaxyMatrix[row, col] = 0;
                }

                row -= 1;
                col -= 1;
            }


            Coord currIvoCoord = ivoCoords.Dequeue();
            row = currIvoCoord.x;
            col = currIvoCoord.y;

            while (row >= 0 || col < cols)
            {
                if (row > -1 &&
                    row < rows &&
                    col > -1 &&
                    col < cols)
                {
                    totalStars += galaxyMatrix[row, col];
                }

                row -= 1;
                col += 1;
            }
        }

        return totalStars;
    }

    private static void FillGalaxy(int rows, int cols, int[,] galaxyMatrix)
    {
        int num = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                galaxyMatrix[row, col] = num;
                num++;
            }
        }
    }

    private static void ReadIvoAndEvilCoords(Queue<Coord> ivoCoords, Queue<Coord> evilCoords)
    {
        bool isIvoArgs = true;
        while (true)
        {
            string input = Console.ReadLine();
            if (input.Equals("Let the Force be with you"))
                break;

            int[] inputArgs = input.Split()
                                   .Select(int.Parse)
                                   .ToArray();
            int coordX = inputArgs[0];
            int coordY = inputArgs[1];

            if (isIvoArgs)
            {
                ivoCoords.Enqueue(new Coord(coordX, coordY));
                isIvoArgs = false;
                continue;
            }

            evilCoords.Enqueue(new Coord(coordX, coordY));
            isIvoArgs = true;
        }
    }
}