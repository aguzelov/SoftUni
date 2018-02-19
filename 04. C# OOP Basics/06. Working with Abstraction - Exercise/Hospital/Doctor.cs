using System;
using System.Collections.Generic;

class Doctor
{
    private string firstName;
    private string surname;
    private string fullName;
    private List<Patient> patients;

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }
    
    public string Surname
    {
        get { return surname; }
        set { surname = value; }
    }
    
    public string FullName
    {
        get { return fullName; }
        set { fullName = value; }
    }

    public List<Patient> Patients
    {
        get { return patients; }
        set { patients = value; }
    }

    public Doctor()
    {
        this.patients = new List<Patient>();
    }

    public Doctor(string firstName, string surname):this()
    {
        this.firstName = firstName;
        this.surname = surname;

        this.fullName = firstName + surname;
    }

    public void AddPatient(string patient)
    {
        this.patients.Add(new Patient(patient));
    }
}
