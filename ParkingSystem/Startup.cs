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

        Dictionary<int, HashSet<int>> parking = new Dictionary<int, HashSet<int>>();

        while (true)
        {
            string inputCoords = Console.ReadLine();
            if (inputCoords.Equals("stop"))
                break;

            int[] coordArgs = inputCoords.Split()
                                         .Select(int.Parse)
                                         .ToArray();
            int entryRow = coordArgs[0];
            int spotRow = coordArgs[1];
            int spotCol = coordArgs[2];

            bool isFree = CheckParkSpot(parking, spotRow, spotCol);
            int distance = int.MinValue;
            if (isFree)
            {
                OccupiedPlace(parking, spotRow, spotCol);
                distance = CalcDistance(entryRow, spotRow, spotCol);

                Console.WriteLine(distance);
                continue;
            }

            spotCol = TryFindPlace(parking[spotRow], spotCol, cols);

            if (spotCol != int.MinValue)
            {
                OccupiedPlace(parking, spotRow, spotCol);
                distance = CalcDistance(entryRow, spotRow, spotCol);

                Console.WriteLine(distance);
                continue;
            }
            Console.WriteLine("Row {0} full", spotRow);
        }
    }

    private static int TryFindPlace(HashSet<int> hashSet, int spotCol, int cols)
    {
        int minDistance = int.MaxValue;
        int currDistance = int.MaxValue;
        int resultCol = int.MinValue;

        for (int col = 1; col < cols; col++)
        {
            if (!hashSet.Contains(col))
            {
                currDistance = Math.Abs(spotCol - col);
            }

            if (currDistance < minDistance)
            {
                minDistance = currDistance;
                resultCol = col;
            }
        }

        return resultCol;
    }

    private static void OccupiedPlace(Dictionary<int, HashSet<int>> parking, int spotRow, int spotCol)
    {
        if (!parking.ContainsKey(spotRow))
        {
            parking.Add(spotRow, new HashSet<int>());
        }

        parking[spotRow].Add(spotCol);
    }

    private static int CalcDistance(int entryRow, int spotRow, int spotCol)
    {
        return Math.Abs(entryRow - spotRow) + spotCol + 1;
    }

    private static bool CheckParkSpot(Dictionary<int, HashSet<int>> parking, int spotRow, int spotCol)
    {
        return parking.ContainsKey(spotRow) && parking[spotRow].Contains(spotCol) ? false : true;
    }
}

