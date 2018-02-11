using System;
using System.Collections.Generic;
using System.Linq;

public class Hospital
{
    private static Dictionary<string, List<Patient>> hospital = new Dictionary<string, List<Patient>>();
    private static Dictionary<string, List<Patient>> patientsByDoctor = new Dictionary<string, List<Patient>>();

    public static void Main()
    {

        while (TakeInfo(out string info))
        {
            AddPatient(new Patient(info));
        }

        while (TakeCommand(out string command))
        {
            if (hospital.ContainsKey(command))
            {
                PrintAllPatienInDepartment(command);
            }
            else
            {
                string[] parameters = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                bool hasParsed = int.TryParse(parameters.Last(), out int room);
                if (hasParsed)
                {
                    string department = parameters[0];
                    PrintRoomInDepartment(department, room);
                }
                else
                {
                    string doctor = command;
                    PrintAllPatientByDoctor(doctor);
                }
            }
        }
    }

    private static void PrintAllPatientByDoctor(string doctor)
    {
        List<Patient> patrientByDoctor = new List<Patient>();
        foreach (var department in hospital)
        {
            foreach (var patient in department.Value.Where(p => p.Doctor == doctor))
            {
                patrientByDoctor.Add(patient);
            }
        }

        foreach (var patient in patrientByDoctor.OrderBy(p => p.Name))
        {
            Console.WriteLine(patient.Name);
        }
    }

    private static void PrintRoomInDepartment(string department, int room)
    {
        List<Patient> patientsInRoom = new List<Patient>();
        int roomToZeroBaseIndex = room - 1;
        int bedStartIndex = roomToZeroBaseIndex * 3;
        for (int i = 0; i < 3; i++)
        {
            patientsInRoom.Add(hospital[department][bedStartIndex + i]);
        }

        foreach (var patient in patientsInRoom.OrderBy(p => p.Name))
        {
            Console.WriteLine(patient.Name);
        }
    }

    private static void PrintAllPatienInDepartment(string department)
    {
        foreach (var patient in hospital[department])
        {
            Console.WriteLine(patient.Name);
        }
    }

    private static void AddPatient(Patient patient)
    {
        string department = patient.Department;

        if (!hospital.ContainsKey(department))
        {
            hospital.Add(department, new List<Patient>());
        }

        if (hospital[department].Count < 60)
        {
            hospital[department].Add(patient);
        }
    }

    private static bool TakeCommand(out string command)
    {
        command = null;

        string input = Console.ReadLine().Trim();
        if (input == "End")
        {
            return false;
        }

        command = input;

        return true;
    }

    private static bool TakeInfo(out string info)
    {
        info = string.Empty;

        string input = Console.ReadLine().Trim();
        if (input == "Output")
        {
            return false;
        }

        info = input;

        return true;
    }

}


public class Patient
{
    public string Name { get; set; }
    public string Doctor { get; set; }
    public string Department { get; set; }

    public Patient(string patientData)
    {
        int indexFirstSpace = patientData.IndexOf(' ');

        string department = patientData.Substring(0, indexFirstSpace);

        int indexLastSpace = patientData.LastIndexOf(' ');
        string doctor = patientData.Substring(indexFirstSpace, indexLastSpace - indexFirstSpace).Trim();
        string name = patientData.Substring(indexLastSpace).Trim();

        this.Name = name;
        this.Doctor = doctor;
        this.Department = department;
    }
}
