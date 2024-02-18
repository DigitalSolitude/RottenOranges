/* Recieve 3 inputs, int row, int column and int[] oranges
 oranges is a 1D representation of a 2D array where rows and columns
define the scope of the 2D array.

 The array represents a crate of oranges, 0 for an empty slot, 1 for a fresh orange
and 2 for a rotten orange

 If a fresh orange has a rotten orange touching it will be rotten by tomorrow.

 Return how many days it takes to rot all the oranges or -1 if it is impossible to rot all the oranges*/

using Spectre.Console;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

internal class Program
{
    private static void Main(string[] args)
    {
        var rows = 3; 
        int cols = 5;
        int[] oranges = new int[]{ 0, 1, 2, 0, 1, 2, 0, 1, 2, 0, 1, 2, 0, 1, 2};
        PrintCrate(rows, cols, oranges);
    }
    
    public static void PrintCrate(int rows, int columns, int[] oranges)
    {
        Table crate = new Table();
        int currentOrange = 0;
        for (int j = 0; j < columns; j++)
        {
            crate.AddColumn($"Column {j}");
        }
        for (int i = 0; i < rows; i++)
        {
            crate.AddEmptyRow();
            for (int j = 0; j < columns; j++)
            {
                crate.UpdateCell(i, j, oranges[currentOrange].ToString());
                currentOrange++;
            }
        }
        AnsiConsole.Write(crate);
    }

    public void PrintAnswer(int numberOfDays)
    {
        string result = string.Empty;
        if (numberOfDays == -1)
        {
            result = "It is impossible to rot all the oranges";
        }
        else
        {
            result = "It took {numberOfDays} days to rot all the oranges";
        }
        Console.WriteLine(result);
    }
}