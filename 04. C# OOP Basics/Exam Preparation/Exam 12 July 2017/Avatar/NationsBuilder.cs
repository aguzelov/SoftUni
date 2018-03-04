using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private List<Bender> benders;
    private List<Monument> monuments;
    private List<War> wars;

    public NationsBuilder()
    {
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
        this.wars = new List<War>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        Bender bender = BenderFactory.CreateBender(benderArgs);
        this.benders.Add(bender);
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        Monument monument = MonumentFactory.CreateMonument(monumentArgs);
        this.monuments.Add(monument);
    }

    public string GetStatus(string nationsType)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"{nationsType} Nation{Environment.NewLine}");

        #region Print Current Benders

        var currentNationTypeBenders = this.benders.Where(b => b.Type == nationsType).ToList();

        string alternativeBenderText = currentNationTypeBenders.Count == 0 ? $" None{Environment.NewLine}" : $"{Environment.NewLine}";
        sb.Append($"Benders:{alternativeBenderText}");

        foreach (var bender in currentNationTypeBenders)
        {
            sb.Append($"###{bender}{Environment.NewLine}");
        }

        #endregion Print Current Benders

        #region Print Current Monuments

        var currentNationTypeMonuments = this.monuments.Where(b => b.Type == nationsType).ToList();

        string alternativeMonumnetText = currentNationTypeMonuments.Count == 0 ? $" None{Environment.NewLine}" : $"{Environment.NewLine}";
        sb.Append($"Monuments:{alternativeMonumnetText}");

        foreach (var monument in currentNationTypeMonuments)
        {
            sb.Append($"###{monument}{Environment.NewLine}");
        }

        #endregion Print Current Monuments

        return sb.ToString();
    }

    public void IssueWar(string nationsType)
    {
        wars.Add(new War(nationsType));

        double airPower = CalculateTotalPower("Air");
        double waterPower = CalculateTotalPower("Water");
        double filePower = CalculateTotalPower("Fire");
        double earthPower = CalculateTotalPower("Earth");

        List<KeyValuePair<double, string>> currentWarStats = new List<KeyValuePair<double, string>>
        {
            new KeyValuePair<double, string>(airPower, "Air"),
            new KeyValuePair<double, string>(waterPower, "Water"),
            new KeyValuePair<double, string>(filePower, "Fire"),
            new KeyValuePair<double, string>(earthPower, "Earth"),
        };

        double maxPower = double.MinValue;
        string maxNationType = string.Empty;
        foreach (var pair in currentWarStats)
        {
            if (pair.Key > maxPower)
            {
                benders.RemoveAll(b => b.Type == maxNationType);
                monuments.RemoveAll(m => m.Type == maxNationType);
                maxPower = pair.Key;
                maxNationType = pair.Value;
            }
            else
            {
                benders.RemoveAll(b => b.Type == pair.Value);
                monuments.RemoveAll(m => m.Type == pair.Value);
            }
        }
    }

    private double CalculateTotalPower(string nation)
    {
        double totalPower = benders.Where(b => b.Type == nation).Sum(b => b.TotalPower);
        double affinity = monuments.Where(m => m.Type == nation).Sum(m => m.Affinity);

        double result = totalPower + ((totalPower / 100) * affinity);
        return result;
    }

    public string GetWarsRecord()
    {
        StringBuilder sb = new StringBuilder();

        wars.ForEach(w => sb.Append($"{w}{Environment.NewLine}"));

        return sb.ToString();
    }
}