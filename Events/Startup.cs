using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Event
{
    public string location { get; set; }
    public Dictionary<string, List<TimeSpan>> organizers { get; set; }

    public Event(string location, Dictionary<string, List<TimeSpan>> organizers)
    {
        this.location = location;
        this.organizers = organizers;
    }
}

public class Startup
{
    public static void Main()
    {
        int eventsCount = int.Parse(Console.ReadLine());

        List<Event> events = new List<Event>();
        string eventPattern = @"^#([a-zA-Z]+):\s*?@([a-zA-Z]+)\s*?((0?[0-9]|1[0-9]|2[0-3]):(0?[0-9]|1[0-9]|2[0-9]|3[0-9]|4[0-9]|5[0-9]))$";

        for (int eve = 0; eve < eventsCount; eve++)
        {
            string inputEvent = Console.ReadLine();

            if (Regex.IsMatch(inputEvent, eventPattern))
            {
                Match eventMatch = Regex.Match(inputEvent, eventPattern);

                string town = eventMatch.Groups[2].Value;
                string organizer = eventMatch.Groups[1].Value;
                int[] hour = eventMatch.Groups[3].Value.Split(':').Select(int.Parse).ToArray();
                int hours = hour[0];
                int minutes = hour[1];

                if (!events.Any(ev => ev.location == town))
                {
                    events.Add(new Event(town, new Dictionary<string, List<TimeSpan>>()));
                }

                int currIndexEv = events.FindIndex(ev => ev.location == town);
                if (!events[currIndexEv].organizers.ContainsKey(organizer))
                {
                    events[currIndexEv].organizers.Add(organizer, new List<TimeSpan>());
                }

                events[currIndexEv].organizers[organizer].Add(new TimeSpan(hours, minutes, 0));
            }
        }

        string[] locations = Console.ReadLine().Split(',');
        events.OrderBy(x => x.location).ToList().ForEach(y =>
        {
            if (locations.Contains(y.location))
            {
                Console.WriteLine("{0}:", y.location);
                int countOrg = 1;

                y.organizers.OrderBy(z => z.Key).ToList().ForEach(z =>
                {
                    List<string> resultTimes = new List<string>();

                    Console.Write("{0}. {1} -> ", countOrg, z.Key);
                    countOrg++;
                    foreach (var time in z.Value.OrderBy(t => t.Hours).ThenBy(t => t.Minutes))
                    {
                        resultTimes.Add(string.Format("{0:hh\\:mm}", time));
                    }
                    resultTimes[resultTimes.Count - 1] = resultTimes[resultTimes.Count - 1].Trim(" ,".ToCharArray());
                    Console.WriteLine(string.Join(", ", resultTimes));
                });
            }
        });
    }
}