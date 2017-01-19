using System;
using System.Linq;

public class StartProg
{
    public static void Main()
    {
        checked
        {
            long dimensions = long.Parse(Console.ReadLine());

            long[,,] cube = new long[dimensions, dimensions, dimensions];
            FillCube(dimensions, cube);

            long sumParticles = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("Analyze"))
                    break;

                long[] coordinateArgs = input.Split()
                                            .Select(long.Parse)
                                            .ToArray();

                long firstDim = coordinateArgs[0];
                long secDim = coordinateArgs[1];
                long thirdDim = coordinateArgs[2];
                long particle = coordinateArgs[3];

                if (firstDim > -1 &&
                    secDim > -1 &&
                    thirdDim > -1 &&
                    firstDim < dimensions &&
                    secDim < dimensions &&
                    thirdDim < dimensions)
                {
                    cube[firstDim, secDim, thirdDim] += particle;
                    sumParticles += particle;
                }
            }

            Console.WriteLine(sumParticles);
            long countEmptyCells = 0;
            foreach (var cell in cube)
            {
                if (cell.Equals(0))
                    countEmptyCells++;
            }
            Console.WriteLine(countEmptyCells);
        }
    }

    private static void FillCube(long dimensions, long[,,] cube)
    {
        for (long row = 0; row < dimensions; row++)
        {
            for (long col = 0; col < dimensions; col++)
            {
                for (long innerRow = 0; innerRow < dimensions; innerRow++)
                {
                    cube[row, col, innerRow] = 0;
                }
            }
        }
    }
}