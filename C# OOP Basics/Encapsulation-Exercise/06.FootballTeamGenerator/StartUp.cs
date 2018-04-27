using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var teams = new List<Team>();

        var inputLine = string.Empty;
        while ((inputLine = Console.ReadLine()) != "END")
        {
            var tokens = inputLine.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
            var command = tokens[0];
            switch (command.ToLower())
            {
                case "team":
                    var currentTeam = new Team(tokens[1]);
                    teams.Add(currentTeam);
                    break;

                case "add":
                    AddPlayersToTeam(teams, tokens);
                    break;

                case "remove":
                    RemovePlayersFromTeam(teams, tokens);
                    break;

                case "rating":
                    GetTeamRating(teams, tokens);
                    break;
            }
        }
    }

    private static void GetTeamRating(List<Team> teams, string[] tokens)
    {
        var teamToRating = tokens[1];
        var findedTeamToRating = teams.FirstOrDefault(t => t.Name == teamToRating);
        if (findedTeamToRating != null)
        {
            var rating = findedTeamToRating.GetRating();

            Console.WriteLine($"{teamToRating} - {rating}");
        }
        else
        {
            Console.WriteLine($"Team {teamToRating} does not exist.");
        }
    }

    private static void RemovePlayersFromTeam(List<Team> teams, string[] tokens)
    {
        //Remove;Arsenal;Aaron_Ramsey
        var nameOfTeam = tokens[1];
        var playerToRemove = tokens[2];
        var findedCurrentTeam = teams.FirstOrDefault(t => t.Name == nameOfTeam);
        if (findedCurrentTeam != null)
        {
            try
            {
                findedCurrentTeam.RemovePlayer(playerToRemove);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine($"Team {nameOfTeam} does not exist.");
        }
    }

    private static void AddPlayersToTeam(List<Team> teams, string[] tokens)
    {
        var teamName = tokens[1];
        var findedTeam = teams.FirstOrDefault(t => t.Name == teamName);
        if (findedTeam != null)
        {
            try
            {
                var playerName = tokens[2];
                var currentPlayer = new Player(playerName);
                var playersStats = new List<decimal>();
                for (int i = 3; i < tokens.Length; i++)
                {
                    playersStats.Add(decimal.Parse(tokens[i]));
                }
                currentPlayer.AddStats(playersStats);
                findedTeam.AddPlayer(currentPlayer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine($"Team {teamName} does not exist.");
        }
    }
}

