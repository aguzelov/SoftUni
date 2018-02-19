using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        Dictionary<string, Doctor> doctors = new Dictionary<string, Doctor>();
        Dictionary<string, Department> departments = new Dictionary<string, Department>();

        ReadData(doctors, departments);

        PrintData(doctors, departments);
    }

    private static void PrintData(Dictionary<string, Doctor> doctors, Dictionary<string, Department> departments)
    {
        string command = string.Empty;

        while ((command = Console.ReadLine()) != "End")
        {
            string[] args = command.Split();

            if (args.Length == 1)
            {
                string department = args[0];

                Console.WriteLine(string.Join($"{Environment.NewLine}", departments[department].Patients));
            }
            else if (args.Length == 2 && int.TryParse(args[1], out int room))
            {
                string department = args[0];
                Console.WriteLine(string.Join($"{Environment.NewLine}", departments[department].GetRoom(room).OrderBy(x => x.Name)));
            }
            else
            {
                string firstName = args[0];
                string surname = args[1];

                Console.WriteLine(string.Join($"{Environment.NewLine}", doctors[firstName + surname].Patients.OrderBy(x => x.Name)));
            }
        }
    }

    private static void ReadData(Dictionary<string, Doctor> doctors, Dictionary<string, Department> departments)
    {
        string command = string.Empty;
        while ((command = Console.ReadLine()) != "Output")
        {
            string[] tokens = command.Split();
            Department department = new Department(tokens[0]);
            Doctor doctor = new Doctor(tokens[1], tokens[2]);
            Patient patient = new Patient(tokens[3]);

            if (!doctors.ContainsKey(doctor.FullName))
            {
                doctors[doctor.FullName] = doctor;
            }

            if (!departments.ContainsKey(department.Name))
            {
                departments[department.Name] = department;

            }

            bool hasPlaces = departments[department.Name].Beds < 60;
            if (hasPlaces)
            {
                doctors[doctor.FullName].AddPatient(patient.Name);
                departments[department.Name].AddPatient(patient.Name);
            }
        }
    }
}
