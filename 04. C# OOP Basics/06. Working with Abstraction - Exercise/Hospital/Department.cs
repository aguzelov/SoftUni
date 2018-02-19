using System;
using System.Collections.Generic;
using System.Linq;

class Department
{
    private string name;
    private List<Patient> patients;

    private int beds;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public List<Patient> Patients
    {
        get { return patients; }
        set { patients = value; }
    }

    public int Beds
    {
        get { return beds; }
    }

    public Department()
    {
        beds = 0;
        this.patients = new List<Patient>();
    }

    public Department(string name) : this()
    {
        this.name = name;
    }
    
    public void AddPatient(string patient)
    {
        beds++;
        this.patients.Add(new Patient(patient));
    }

    public List<Patient> GetRoom(int room)
    {
        int skipBeds = (room - 1) * 3;
        return patients.Skip(skipBeds).Take(3).ToList();
    }
}
