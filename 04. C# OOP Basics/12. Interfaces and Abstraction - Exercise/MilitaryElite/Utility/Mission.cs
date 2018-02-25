using System;

public class Mission
{
    private string codeName;
    private string state;

    public string CodeName
    {
        get
        {
            return this.codeName;
        }
        set
        {
            this.codeName = value;
        }
    }

    public string State
    {
        get
        {
            return this.state;
        }
        private set
        {
            if (value != "inProgress" && value != "Finished")
            {
                throw new ArgumentException();
            }

            this.state = value;
        }
    }

    public Mission(string codeName, string state = "inProgress")
    {
        CodeName = codeName;
        State = state;
    }

    public void CompleteMission()
    {
        if (State == "inProgress")
        {
            State = "Finished";
        }
    }

    public override string ToString()
    {
        return $"Code Name: {CodeName} State: {state}";
    }
}