using System.Collections.Generic;

public abstract class AbstractCommand : ICommand
{
    private List<string> argsList;
    private IManager manager;

    protected AbstractCommand(List<string> args, IManager manager)
    {
        this.ArgsList = args;
        this.manager = manager;
    }

    public List<string> ArgsList
    {
        get { return argsList; }
        private set
        {
            this.argsList = value;
        }
    }

    public IManager Manager
    {
        get
        {
            return this.manager;
        }
        private set
        {
            this.manager = value;
        }
    }

    public abstract string Execute();
}