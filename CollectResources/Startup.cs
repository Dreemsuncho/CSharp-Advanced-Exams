using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        List<string> inputResources = Console.ReadLine().Split().ToList();
        int countWays = int.Parse(Console.ReadLine());

        List<string> startSteps = new List<string>();
        for (int way = 0; way < countWays; way++)
        {
            startSteps.Add(Console.ReadLine());
        }

        int maxCollect = int.MinValue;
        startSteps.ForEach(arg =>
        {
            int start = int.Parse(arg[0].ToString());
            int step = int.Parse(arg.Substring(2));

            int currCollect = 0;
            List<string> collectableResources = new List<string>();
            collectableResources.Clear();
            collectableResources.AddRange(inputResources);
            while (true)
            {
                if (collectableResources[start] == "collected")
                    break;

                if (collectableResources[start].StartsWith("wood") ||
                    collectableResources[start].StartsWith("gold") ||
                    collectableResources[start].StartsWith("food") ||
                    collectableResources[start].StartsWith("stone"))
                {
                    int resource = 1;

                    if (collectableResources[start].Contains("_"))
                    {
                        int sepElement = collectableResources[start].IndexOf("_");
                        int.TryParse(collectableResources[start].Substring(sepElement + 1), out resource);
                    }

                    currCollect += resource;
                    collectableResources[start] = "collected";
                }
                start += step;
                while (start >= collectableResources.Count)
                {
                    start -= collectableResources.Count;
                }
            }

            if (currCollect > maxCollect)
            {
                maxCollect = currCollect;
            }
        });

        Console.WriteLine(maxCollect);
    }
}