namespace Employees.App.Core.IO.Contracts
{
    public interface IOutputWriter
    {
        void WriteLine(string line);

        void Write(string line);
    }
}