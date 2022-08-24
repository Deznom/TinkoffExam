using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private class Team
    {
        public int victoryCount;
        
        private string[] teamNames;

        public Team(string names)
        {
            victoryCount = 1;
            teamNames = names.Split(' ');
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() == typeof(Team))
            {
                var otherTeam = (Team) obj;
                var orderedNames0 = teamNames.OrderBy(name => name).ToArray();
                var orderedNames1 = otherTeam.teamNames.OrderBy(name => name).ToArray();
                var same = true;

                for (var i = 0; i < 3; i++)
                {
                    if (orderedNames0[i] != orderedNames1[i])
                    {
                        same = false;
                    }
                }

                if (same)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public static void Main(string[] args)
    {
        var teamCount = int.Parse(Console.ReadLine());
        var teamList = new List<Team>();
        
        for (var i = 0; i < teamCount; i++)
        {
            var newTeam = new Team(Console.ReadLine());
            if (!teamList.Contains(newTeam))
            {
                teamList.Add(newTeam);
            }
            else
            {
                teamList[teamList.IndexOf(newTeam)].victoryCount++;
            }
        }
        
        var first = teamList.OrderByDescending(team => team.victoryCount).FirstOrDefault();

        Console.WriteLine(first.victoryCount);
    }
}