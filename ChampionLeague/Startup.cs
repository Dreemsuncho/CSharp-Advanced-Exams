using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Team
{
    public string teamName { get; set; }
    public int wins { get; set; }
    public SortedSet<string> opponents { get; set; }

    public Team(string teamName, int wins, SortedSet<string> opponents)
    {
        this.teamName = teamName;
        this.wins = wins;
        this.opponents = opponents;
    }
}

public class Startup
{
    public static void Main()
    {
        List<Team> teams = new List<Team>();

        while (true)
        {
            string teamsInput = Console.ReadLine();
            if (teamsInput.Equals("stop"))
                break;


            string[] teamsArgs = teamsInput.Split("|".ToCharArray(),
                                                      StringSplitOptions.RemoveEmptyEntries)
                                           .Select(arg => arg.Trim())
                                           .ToArray();

            string firstTeam = teamsArgs[0];
            string secondTeam = teamsArgs[1];
            if (!(Regex.IsMatch(firstTeam, @"[a-zA-Z]+\s*[a-zA-Z]*") &&
                  Regex.IsMatch(secondTeam, @"[a-zA-Z]+\s*[a-zA-Z]*")))
            {
                continue;
            }


            int firstTeamHostGoals = int.Parse(teamsArgs[2][0].ToString());
            int firstTeamGuestGoals = int.Parse(teamsArgs[3][2].ToString());
            int secondTeamHostGoals = int.Parse(teamsArgs[3][0].ToString());
            int secondTeamGuestGoals = int.Parse(teamsArgs[2][2].ToString());



            bool isFirstWinner = true;

            if ((firstTeamHostGoals + firstTeamGuestGoals) <
               (secondTeamHostGoals + secondTeamGuestGoals))
            {
                isFirstWinner = false;
            }
            else if ((firstTeamHostGoals + firstTeamGuestGoals) >
                     (secondTeamHostGoals + secondTeamGuestGoals))
            {
                isFirstWinner = true;
            }
            else if (firstTeamGuestGoals > secondTeamGuestGoals)
            {
                isFirstWinner = true;
            }
            else
            {
                isFirstWinner = false;
            }

            if (!teams.Any(t => t.teamName == firstTeam))
            {
                teams.Add(new Team(firstTeam, 0, new SortedSet<string>()));
            }
            if (!teams.Any(t => t.teamName == secondTeam))
            {
                teams.Add(new Team(secondTeam, 0, new SortedSet<string>()));
            }


            int firstIndex = teams.FindIndex(t => t.teamName == firstTeam);
            int secondIndex = teams.FindIndex(t => t.teamName == secondTeam);

            if (isFirstWinner)
            {
                teams[firstIndex].wins++;
            }
            else
            {
                teams[secondIndex].wins++;
            }

            teams[firstIndex].opponents.Add(secondTeam);
            teams[secondIndex].opponents.Add(firstTeam);
        }

        teams.OrderByDescending(t => t.wins)
             .ThenBy(t => t.teamName)
             .ToList()
             .ForEach(t =>
             {
                 Console.WriteLine(t.teamName);
                 Console.WriteLine("- Wins: {0}", t.wins);

                 Console.WriteLine("- Opponents: {0}", string.Join(", ", t.opponents));
             });
    }
}