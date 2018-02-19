using System;
using System.Linq;

class Coordinate
{
    private int row;

    public int Row
    {
        get { return row; }
        set { row = value; }
    }

    private int col;

    public int Col
    {
        get { return col; }
        set { col = value; }
    }

    public Coordinate(int row, int col)
    {
        this.row = row;
        this.col = col;
    }

    public Coordinate(string command)
    {
        int[] coordinates = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        this.row = coordinates[0];
        this.col = coordinates[1];
    }

    public Coordinate(Func<string> readCoordinates)
    {
        int[] coordinates = readCoordinates().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        this.row = coordinates[0];
        this.col = coordinates[1];
    }
}
