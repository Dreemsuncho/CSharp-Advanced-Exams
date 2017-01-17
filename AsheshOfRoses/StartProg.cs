using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class StartProg
{
    public static void Main()
    {
        Dictionary<string, Dictionary<string, long>> regions = new Dictionary<string, Dictionary<string, long>>();

        while (true)
        {
            string pattern = @"Grow <([A-Z][a-z]+)> <([a-zA-Z0-9]+)> ([0-9]+)";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();
            if (input.Equals("Icarus, Ignite!"))
                break;

            MatchCollection matches = regex.Matches(input);

            if (matches.Count > 0)
            {
                foreach (Match m in matches)
                {
                    string region = m.Groups[1].Value;
                    string colorName = m.Groups[2].Value;
                    long amount = long.Parse(m.Groups[3].Value);

                    if (!regions.ContainsKey(region))
                    {
                        regions.Add(region, new Dictionary<string, long>());
                    }

                    if (!regions[region].ContainsKey(colorName))
                    {
                        regions[region].Add(colorName, 0);
                    }

                    regions[region][colorName] += amount;
                }
            }
        }

        regions.OrderByDescending(r => r.Value.Values.Sum())
               .ThenBy(r => r.Key)
               .ToList()
               .ForEach(c =>
               {
                   Console.WriteLine(c.Key);

                   c.Value.OrderBy(color => color.Value)
                          .ThenBy(color => color.Key)
                          .ToList()
                          .ForEach(color =>
                          {
                              Console.WriteLine("*--{0} | {1}", color.Key, color.Value);
                          });
               });
    }
}