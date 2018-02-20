using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;
    private List<Player> players;
    private double rating;

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.name = value;
        }
    }

    public double Rating
    {
        get
        {
            CalculateRating();
            return this.rating;
        }
    }

    public Team(string name)
    {
        this.players = new List<Player>();
        Name = name;
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        if (!players.Any(p => p.Name == playerName))
        {
            throw new ArgumentException($"Player {playerName} is not in {this.name} team.");
        }

        players.RemoveAll(p => p.Name == playerName);
    }

    private void CalculateRating()
    {
        try
        {
            double averageSkillLevel = this.players.Average(p => p.SkillLevel);
            rating = averageSkillLevel;
        }
        catch (InvalidOperationException ex)
        {
            return;
        }

    }

    public override string ToString()
    {
        return $"{this.name} - {this.Rating:F0}";
    }
}