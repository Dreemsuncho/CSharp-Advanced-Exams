using System;
using System.Collections.Generic;
using System.Linq;

public class StartProg
{
    public static void Main()
    {
        List<int> flowers = Console.ReadLine().Split()
                                          .Select(int.Parse)
                                          .ToList();

        List<int> buckets = Console.ReadLine().Split()
                                          .Select(int.Parse)
                                          .ToList();

        List<int> secondNature = new List<int>();

        while (!flowers.Count.Equals(0) &&
               !buckets.Count.Equals(0))
        {
            int currFlower = flowers[0];
            int currBucket = buckets[buckets.Count - 1];

            if (currFlower > currBucket)
            {
                buckets.RemoveAt(buckets.Count - 1);
                flowers[0] -= currBucket;
            }
            else if (currFlower < currBucket)
            {
                flowers.RemoveAt(0);
                if(buckets.Count > 1)
                {
                    int remainWater = currBucket - currFlower;

                    buckets.RemoveAt(buckets.Count - 1);
                    buckets[buckets.Count - 1] += remainWater;
                    continue;
                }

                buckets[0] -= currFlower;
            }
            else
            {
                secondNature.Add(currFlower);
                buckets.RemoveAt(buckets.Count - 1);
                flowers.RemoveAt(0);
            }
        }

        var result = flowers;
        if (flowers.Count.Equals(0))
        {
            buckets.Reverse();
            result = buckets;
        }

        Console.WriteLine(string.Join(" ", result));
        if (secondNature.Count > 0)
            Console.WriteLine(string.Join(" ", secondNature));
        else
        {
            Console.WriteLine("None");
        }
    }
}