using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private readonly Dictionary<string, Driver> drivers;
    private readonly Dictionary<Driver, string> unfinishedDrivers;
    private int numberOfLaps;
    private int currentLap;
    private Weather weather;
    public Driver Winner { get; private set; }
    public int LenghtOfTrack { get; set; }
    public bool IsEndOfRace { get; private set; }

    public RaceTower()
    {
        this.drivers = new Dictionary<string, Driver>();
        this.unfinishedDrivers = new Dictionary<Driver, string>();
        this.weather = Weather.Sunny;
        this.currentLap = 0;
        this.IsEndOfRace = false;
    }

    public int NumberOfLaps
    {
        get => this.numberOfLaps;
        set
        {
            if (value < 0)
            {
                throw new InvalidOperationException($"There is no time! On lap {this.currentLap}.");
            }

            this.numberOfLaps = value;
        }
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            var tyreArgs = commandArgs.Skip(4).ToList();
            var carArgs = commandArgs.Skip(2).Take(2).ToList();
            var driverArgs = commandArgs.Take(2).ToList();

            var tyre = TyreFactory.Create(tyreArgs);
            var car = CarFactory.Create(carArgs, tyre);
            var driver = DriverFactory.Create(driverArgs, car);

            this.drivers.Add(driverArgs[1], driver);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        var result = new StringBuilder();

        var currentNumberOfLaps = int.Parse(commandArgs[0]);

        try
        {
            this.NumberOfLaps -= currentNumberOfLaps;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        for (int i = 0; i < currentNumberOfLaps; i++)
        {
            SetTotalTimeOfDrivers();
            DoDriverContinueTheRace();
            RemoveIneligibleDriversFromDictionary();

            this.currentLap++;
            var driversToOvertaken = this.drivers.Values.OrderByDescending(d => d.TotalTime).ToList();

            CheckForOvertaking(result, driversToOvertaken);
        }

        if (this.NumberOfLaps == 0)
        {
            this.IsEndOfRace = true;
            this.Winner = this.drivers.Values.OrderBy(d => d.TotalTime).FirstOrDefault();
        }

        return result.ToString().Trim();
    }

    private void RemoveIneligibleDriversFromDictionary()
    {
        foreach (var crashDriver in this.unfinishedDrivers)
        {
            if (this.drivers.ContainsKey(crashDriver.Key.Name))
            {
                this.drivers.Remove(crashDriver.Key.Name);
            }
        }
    }

    private void CheckForOvertaking(StringBuilder result, List<Driver> driversToOvertaken)
    {
        for (int j = 0; j < driversToOvertaken.Count - 1; j++)
        {
            var firstDriver = driversToOvertaken[j];
            var secondDriver = driversToOvertaken[j + 1];
            var timeFirstDriver = firstDriver.TotalTime;
            var timeSecondDriver = secondDriver.TotalTime;
            var difference = Math.Abs(timeFirstDriver - timeSecondDriver);
            var intervalToOvertake = 2;

            bool isCrash = CheckForSpecialConditions(firstDriver, ref intervalToOvertake);

            if (difference <= intervalToOvertake)
            {
                if (isCrash)
                {
                    this.unfinishedDrivers.Add(firstDriver, "Crashed");
                    foreach (var crashDriver in this.unfinishedDrivers)
                    {
                        if (this.drivers.ContainsKey(crashDriver.Key.Name))
                        {
                            this.drivers.Remove(crashDriver.Key.Name);
                        }
                    }
                    continue;
                }

                PrintOvertakenDrivers(result, firstDriver, secondDriver, intervalToOvertake);
            }
        }
    }

    private bool CheckForSpecialConditions(Driver firstDriver, ref int intervalToOvertake)
    {
        bool isCrash = false;

        if (firstDriver.GetType().Name == "AggressiveDriver"
            && firstDriver.Car.Tyre.GetType().Name == "UltrasoftTyre")
        {
            intervalToOvertake = 3;
            if (this.weather == Weather.Foggy)
            {
                isCrash = true;
            }
        }

        if (firstDriver.GetType().Name == "EnduranceDriver"
            && firstDriver.Car.Tyre.GetType().Name == "HardTyre")
        {
            intervalToOvertake = 3;
            if (this.weather == Weather.Rainy)
            {
                isCrash = true;
            }
        }

        return isCrash;
    }

    private void PrintOvertakenDrivers(StringBuilder result, Driver firstDriver, Driver secondDriver, int intervalToOvertake)
    {
        firstDriver.TotalTime -= intervalToOvertake;
        secondDriver.TotalTime += intervalToOvertake;
        result.AppendLine(
            $"{firstDriver.Name} has overtaken {secondDriver.Name} on lap {this.currentLap}.");
    }

    private void DoDriverContinueTheRace()
    {
        foreach (var driver in this.drivers.Values)
        {
            try
            {
                driver.ReduceFuelAmount(this.LenghtOfTrack);
                driver.Car.Tyre.ReduceDegradation();
            }
            catch (Exception e)
            {
                this.unfinishedDrivers.Add(driver, e.Message);
            }
        }
    }

    private void SetTotalTimeOfDrivers()
    {
        foreach (var driver in this.drivers.Values)
        {
            driver.TotalTime += 60 / (this.LenghtOfTrack / driver.Speed);
        }
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.NumberOfLaps = lapsNumber;
        this.LenghtOfTrack = trackLength;
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var boxReasonType = commandArgs[0];
        var driversName = commandArgs[1];
        var driver = this.drivers[driversName];
        driver.TotalTime += 20;

        switch (boxReasonType)
        {
            case "Refuel":
                var fuelAmount = double.Parse(commandArgs[2]);
                driver.Car.Refuel(fuelAmount);
                break;

            case "ChangeTyres":
                var tyreArgs = commandArgs.Skip(2).ToList();
                var newTyre = TyreFactory.Create(tyreArgs);
                driver.Car.ChangeTyre(newTyre);
                break;
        }
    }

    public string GetLeaderboard()
    {
        var result = new StringBuilder();
        var counter = 1;
        result.AppendLine($"Lap {this.currentLap}/{this.currentLap + this.NumberOfLaps}");

        foreach (var driver in this.drivers.Values.OrderBy(d => d.TotalTime))
        {
            result.AppendLine($"{counter++} {driver.Name} {driver.TotalTime:F3}");
        }

        var crashesToPrint = this.unfinishedDrivers.Reverse();
        foreach (var driver in crashesToPrint)
        {
            result.AppendLine($"{counter++} {driver.Key.Name} {driver.Value}");
        }

        return result.ToString().Trim();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        var weatherToString = commandArgs[0];
        this.weather = (Weather)Enum.Parse(typeof(Weather), weatherToString);
    }
}