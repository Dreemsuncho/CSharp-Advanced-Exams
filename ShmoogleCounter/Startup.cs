using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Startup
{
    public static void Main()
    {
        List<string> ints = new List<string>();
        List<string> doubles = new List<string>();

        Regex regex = new Regex(@"(double|int)\s+([a-z][a-zA-Z]*)");

        string lineCode;
        while (!(lineCode = Console.ReadLine()).StartsWith("//"))
        {
            foreach (Match item in regex.Matches(lineCode))
            {
                string type = item.Groups[1].Value;
                string name = item.Groups[2].Value;

                if (type == "double")
                {
                    doubles.Add(name);
                    continue;
                }

                ints.Add(name);
            }
        }
        Console.WriteLine("Doubles: {0}", Print(doubles));
        Console.WriteLine("Ints: {0}", Print(ints));
    }

    private static string Print(ICollection<string> names)
    {
        return names.Count > 0 ? string.Join(", ", names.OrderBy(n => n)) : "None";
    }
}