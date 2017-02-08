using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class CountryStats
{
    public HashSet<string> Athlets { get; set; }
    public int Wins { get; set; }

    public CountryStats(HashSet<string> athlets, int wins)
    {
        this.Athlets = athlets;
        this.Wins = wins;
    }
}

public class Startup
{
    public static void Main()
    {
        Dictionary<string, CountryStats> countries = new Dictionary<string, CountryStats>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input.Equals("report"))
                break;

            string[] inputArgs = input.Split('|')
                                      .Select(x => x.Trim())
                                      .Select(y => Regex.Replace(y, @"\s{2,}", " "))
                                      .ToArray();
            string athlete = inputArgs[0];
            string country = inputArgs[1];


            if (!countries.ContainsKey(country))
                countries.Add(country, new CountryStats(new HashSet<string>(), 0));

            countries[country].Athlets.Add(athlete);
            countries[country].Wins++;
        }

        countries.OrderByDescending(c => c.Value.Wins).ToList()
            .ForEach(c => Console.WriteLine("{0} ({1} participants): {2} wins", c.Key, c.Value.Athlets.Count, c.Value.Wins));
    }
}