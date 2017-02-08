using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        Dictionary<string, Dictionary<string, long>> countries = new Dictionary<string, Dictionary<string, long>>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input.Equals("report"))
                break;

            string[] countryArgs = input.Split('|');
            string town = countryArgs[0];
            string country = countryArgs[1];
            int population = int.Parse(countryArgs[2]);

            if (!countries.ContainsKey(country))
            {
                countries.Add(country, new Dictionary<string, long>());
                countries[country].Add(town, 0);
            }

            countries[country][town] = population;
        }

        countries.OrderByDescending(c => c.Value.Values.Sum())
                 .ToList()
                 .ForEach(c =>
                 {
                     Console.WriteLine("{0} (total population: {1})", c.Key, c.Value.Values.Sum());
                     c.Value.OrderByDescending(t => t.Value)
                            .ToList()
                            .ForEach(t => Console.WriteLine("=>{0}: {1}", t.Key, t.Value));
                 });
    }
}