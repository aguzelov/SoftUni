using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CommandInterpreter
{
    private List<Hardware> hardwares;
    private List<Software> softwares;
    private List<Hardware> dump;

    public CommandInterpreter()
    {
        this.hardwares = new List<Hardware>();
        this.softwares = new List<Software>();
        this.dump = new List<Hardware>();
    }

    public void Execute()
    {
        while (true)
        {
            string[] commandArgs = GetCommand();

            string command = commandArgs[0];
            switch (command)
            {
                case "RegisterPowerHardware":
                    Hardware hardware = HardwareFactory.CreateHardware("Power", commandArgs.Skip(1).ToArray());

                    this.hardwares.Add(hardware);
                    break;

                case "RegisterHeavyHardware":
                    hardware = HardwareFactory.CreateHardware("Heavy", commandArgs.Skip(1).ToArray());

                    this.hardwares.Add(hardware);
                    break;

                case "RegisterExpressSoftware":
                    string hardwareComponentName = commandArgs[1];

                    try
                    {
                        hardware = hardwares.FirstOrDefault(h => h.Name == hardwareComponentName);

                        Software software = SoftwareFactory.CreateSoftware("Express", commandArgs.Skip(2).ToArray());

                        hardware.AddSoftwareComponent(software);
                        softwares.Add(software);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    break;

                case "RegisterLightSoftware":
                    hardwareComponentName = commandArgs[1];

                    try
                    {
                        hardware = hardwares.FirstOrDefault(h => h.Name == hardwareComponentName);

                        Software software = SoftwareFactory.CreateSoftware("Light", commandArgs.Skip(2).ToArray());

                        hardware.AddSoftwareComponent(software);
                        softwares.Add(software);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    break;

                case "ReleaseSoftwareComponent":
                    hardwareComponentName = commandArgs[1];
                    string softwareComponentName = commandArgs[2];

                    try
                    {
                        hardware = hardwares.FirstOrDefault(h => h.Name == hardwareComponentName);
                        Software software = hardware.ReleaseSoftwareComponent(softwareComponentName);
                        softwares.Remove(software);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    break;

                case "Dump":
                    hardwareComponentName = commandArgs[1];

                    if (!hardwares.Exists(h => h.Name == hardwareComponentName))
                    {
                        continue;
                    }
                    try
                    {
                        hardware = hardwares.FirstOrDefault(h => h.Name == hardwareComponentName);

                        hardwares.Remove(hardware);

                        dump.Add(hardware);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    break;

                case "Restore":
                    hardwareComponentName = commandArgs[1];

                    if (!dump.Exists(h => h.Name == hardwareComponentName))
                    {
                        continue;
                    }

                    try
                    {
                        hardware = dump.FirstOrDefault(h => h.Name == hardwareComponentName);

                        dump.Remove(hardware);

                        hardwares.Add(hardware);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    break;

                case "Destroy":
                    hardwareComponentName = commandArgs[1];

                    if (!hardwares.Exists(h => h.Name == hardwareComponentName))
                    {
                        continue;
                    }

                    try
                    {
                        hardware = dump.FirstOrDefault(h => h.Name == hardwareComponentName);

                        dump.Remove(hardware);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    break;

                case "DumpAnalyze":
                    StringBuilder sb = new StringBuilder();

                    sb.Append($"Dump Analysis{Environment.NewLine}");

                    int countOfPowerHardwareComponents = dump.Where(c => c.GetType().Name == "Power").Count();
                    int countOfHeavyHardwareComponents = dump.Where(c => c.GetType().Name == "Heavy").Count();
                    int countOfExpressSoftwareComponents = dump.Sum(c => c.Softwares.Where(s => s.GetType().Name == "Express").Count());
                    int countOfLightSoftwareComponents = dump.Sum(c => c.Softwares.Where(s => s.GetType().Name == "Light").Count()); ;
                    int totalDumpedMemory = dump.Sum(c => c.TotalOperationalMemoryInUse);
                    int totalDumpedCapacity = dump.Sum(c => c.TotalCapacityTaken);

                    sb.Append($"Power Hardware Components: {countOfPowerHardwareComponents}{Environment.NewLine}");
                    sb.Append($"Heavy Hardware Components: {countOfHeavyHardwareComponents}{Environment.NewLine}");
                    sb.Append($"Express Software Components: {countOfExpressSoftwareComponents}{Environment.NewLine}");
                    sb.Append($"Light Software Components: {countOfLightSoftwareComponents}{Environment.NewLine}");
                    sb.Append($"Total Dumped Memory: {totalDumpedMemory}{Environment.NewLine}");
                    sb.Append($"Total Dumped Capacity: {totalDumpedCapacity}{Environment.NewLine}");

                    Console.Write(sb.ToString());
                    break;

                case "Analyze":
                    sb = new StringBuilder();

                    sb.Append($"System Analysis{Environment.NewLine}");

                    sb.Append($"Hardware Components: {hardwares.Count}{Environment.NewLine}");
                    sb.Append($"Software Components: {hardwares.Sum(s => s.Softwares.Count)}{Environment.NewLine}");

                    int TotalOperationalMemoryInUse = hardwares.Sum(h => h.TotalOperationalMemoryInUse);
                    int TotalMemory = hardwares.Sum(h => h.MaximumMemory);
                    sb.Append($"Total Operational Memory: {TotalOperationalMemoryInUse} / {TotalMemory}{Environment.NewLine}");

                    int TotalCapacityTaken = hardwares.Sum(h => h.TotalCapacityTaken);
                    int TotalCapacity = hardwares.Sum(h => h.MaximumCapacity);
                    sb.Append($"Total Capacity Taken: {TotalCapacityTaken} / {TotalCapacity}");
                    Console.WriteLine(sb.ToString());
                    break;

                case "System":
                    Console.Write(SystemInformation());
                    return;
            }
        }
    }

    private string SystemInformation()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var component in hardwares.OrderByDescending(h => h.GetType().Name))
        {
            sb.Append($"Hardware Component - {component.Name}{Environment.NewLine}");

            var softwareComponents = component.Softwares;

            int countOfExpressSoftwareComponents = softwareComponents.Where(s => s.GetType().Name == "Express").Count();
            sb.Append($"Express Software Components - {countOfExpressSoftwareComponents}{Environment.NewLine}");

            int countOfLightSoftwareComponents = Math.Abs(softwareComponents.Count - countOfExpressSoftwareComponents);
            sb.Append($"Light Software Components - {countOfLightSoftwareComponents}{Environment.NewLine}");

            sb.Append($"Memory Usage: {component.TotalOperationalMemoryInUse} / {component.MaximumMemory}{Environment.NewLine}");
            sb.Append($"Capacity Usage: {component.TotalCapacityTaken} / {component.MaximumCapacity}{Environment.NewLine}");

            sb.Append($"Type: {component.GetType().Name}{Environment.NewLine}");

            string softwares = softwareComponents.Count == 0 ? "None" : string.Join(", ", softwareComponents);
            sb.Append($"Software Components: {softwares}{Environment.NewLine}");
        }

        return sb.ToString();
    }

    private string[] GetCommand()
    {
        string input = System.Console.ReadLine();
        string[] commandArgs = input.Split(new char[] { '(', ' ', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);

        return commandArgs;
    }
}