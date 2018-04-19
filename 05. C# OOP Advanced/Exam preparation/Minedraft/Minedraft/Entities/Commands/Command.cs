﻿using System.Collections.Generic;

public abstract class Command : ICommand
{
    protected Command(IList<string> arguments)
    {
        this.Arguments = arguments;
    }

    protected IList<string> Arguments { get; }

    public abstract string Execute();
}