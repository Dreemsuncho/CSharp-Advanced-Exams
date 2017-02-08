using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class Startup
{
    public static void Main()
    {
        string input = Console.ReadLine().ToUpper();

        MatchCollection matches = Regex.Matches(input, @"(\D+)(\d+)");
        StringBuilder results = new StringBuilder();

        foreach (Match match in matches)
        {
            int repeat = int.Parse(match.Groups[2].Value);
            results.Append(string.Format("{0}", string.Join("", Enumerable.Repeat(match.Groups[1].Value, repeat))));
        }

        Console.WriteLine("Unique symbols used: {0}", results.ToString().Distinct().Count());
        Console.WriteLine(results);
    }
}