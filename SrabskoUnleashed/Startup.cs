using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Startup
{
    public static void Main()
    {
        string pattern = @"^([a-zA-Z]+ *[a-zA-Z]* *[a-zA-Z]*) @([a-zA-Z]+ *[a-zA-Z]* *[a-zA-Z]*) ([0-9]+) ([0-9]+)$";
        Regex reg = new Regex(pattern);

        Dictionary<string, Dictionary<string, int>> aggregateData = new Dictionary<string, Dictionary<string, int>>();

        string input;
        while (!((input = Console.ReadLine()) == "End"))
        {
            Match inputArgs = reg.Match(input);
            if (inputArgs.Value != string.Empty)
            {
                string singer = inputArgs.Groups[1].Value;
                string venue = inputArgs.Groups[2].Value;
                int price = int.Parse(inputArgs.Groups[3].Value);
                int count = int.Parse(inputArgs.Groups[4].Value);

                if (!aggregateData.ContainsKey(venue))
                {
                    aggregateData.Add(venue, new Dictionary<string, int>());
                }

                if (!aggregateData[venue].ContainsKey(singer))
                {
                    aggregateData[venue].Add(singer, 0);
                }

                aggregateData[venue][singer] += (count * price);
            }
        }

        aggregateData.ToList()
                     .ForEach(x =>
        {
            Console.WriteLine(x.Key);
            x.Value.OrderByDescending(y => y.Value)
                   .ToList()
                   .ForEach(z => Console.WriteLine("#  {0} -> {1}", z.Key, z.Value));
        });
    }
}