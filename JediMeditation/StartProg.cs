using System;
using System.Collections.Generic;
using System.Linq;

public class StartProg
{
    public static void Main()
    {
        List<string> jedies = new List<string>();

        int jediLines = int.Parse(Console.ReadLine());
        for (int line = 0; line < jediLines; line++)
        {
            string[] jediLine = Console.ReadLine().Split();
            jedies.AddRange(jediLine);
        }

        IEnumerable<string> orderedJedies;
        if (jedies.Any(j => j.StartsWith("y")))
        {
            orderedJedies = jedies.Where(j => !j.StartsWith("y"))
                                  .OrderBy(j => j.StartsWith("p"))
                                  .ThenBy(j => j.StartsWith("t") || j.StartsWith("s"))
                                  .ThenBy(j => j.StartsWith("k"))
                                  .ThenBy(j => j.StartsWith("m"));
        }
        else
        {
            orderedJedies = jedies.OrderBy(j => j.StartsWith("p"))
                                  .ThenBy(j => j.StartsWith("k"))
                                  .ThenBy(j => j.StartsWith("m"));
        }

        Console.WriteLine(string.Join(" ", orderedJedies));
    }
}