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
    static int rows = 4;
    static int cols = 6;
    static int[] todaysOranges = new int[] { 0, 1, 2, 0, 0, 2, 0, 1, 2, 0, 1, 2, 0, 1, 2, 1, 1,1 ,1,2,1,1,1,1 };
    static int[] tomorrowsOranges = new int[todaysOranges.Length];
    static int daysPassed = 0;
    private static void Main(string[] args)
    {
        PrintCrate(rows, cols, todaysOranges);
        MainLoop();
    }

    private static void MainLoop()
      {
        EdgeChecker(rows, cols, todaysOranges);
        if (todaysOranges == tomorrowsOranges)
        {
            PrintCrate(rows, cols, todaysOranges);
            if (todaysOranges.Contains(1))
            {
                PrintAnswer(-1);
                return;
            }
            else
            {
                PrintAnswer(daysPassed);
                return;
            }
        }
        todaysOranges = tomorrowsOranges;
        tomorrowsOranges.ToList().Clear();
        PrintCrate(rows, cols, todaysOranges);
        daysPassed++;
        MainLoop();
    }

    private static void EdgeChecker(int rows, int cols, int[] oranges)
    {
        for (int i = 0; i < oranges.Length; i++) 
        {
            if (oranges[i] != 0)
            {
                tomorrowsOranges[i] = oranges[i];
            }
            Edge edge = new Edge();
            edge = Edge.NotEdge;
            //Edge Represents different sides/corners
            if (i < cols)
            {
                edge = Edge.Top;
            }
            if (i > oranges.Length - cols)
            {
                edge = Edge.Bottom;
            }
            if (i % cols == 0)
            {
                if (i == 0)
                {
                    edge = Edge.TopLeft;
                }
                if (i == oranges.Length-cols)
                {
                    edge = Edge.BottomLeft;
                }
                else
                {
                    edge = Edge.Left;
                }
            }
            if (i % cols == 4)
            {
                if (i == cols-1)
                {
                    edge = Edge.TopRight;
                }
                else if (i == oranges.Length-1)
                {
                    edge = Edge.BottomRight;
                }
                else
                {
                    edge = Edge.Right;
                }
            }
            RotOranges(rows, cols, oranges, edge, i);
        }
    }

    private static void RotOranges(int rows, int cols, int[] oranges, Edge edge, int currentSlot)
    {
        
        if (oranges[currentSlot] == 2)
        {
            if (edge == Edge.NotEdge)
            {
                var slotLeft = oranges[currentSlot - 1];
                var slotRight = oranges[currentSlot + 1];
                var slotAbove = oranges[currentSlot - cols];
                var slotBelow = oranges[currentSlot + cols];
                if (slotLeft == 1)
                {
                    tomorrowsOranges[currentSlot - 1] = 2;
                    todaysOranges[currentSlot] =4; 
                }
                if (oranges[slotRight] == 1)
                {
                    tomorrowsOranges[currentSlot + 1] = 2;
                }
                if (oranges[slotBelow] == 1)
                {
                    tomorrowsOranges[currentSlot + cols] = 2;
                }
                if (oranges[slotAbove] == 1)
                {
                    tomorrowsOranges[currentSlot - cols] = 2;
                }
            }
            else if (edge == Edge.TopLeft)
            {
                var slotRight = oranges[currentSlot + 1];
                var slotBelow = oranges[currentSlot + cols];
                if (oranges[slotRight] == 1)
                {
                    tomorrowsOranges[currentSlot + 1] = 2;
                }
                if (oranges[slotBelow] == 1)
                {
                    tomorrowsOranges[currentSlot + cols] = 2;
                }
            }
            else if (edge == Edge.Top)
            {
                var slotLeft = oranges[currentSlot - 1];
                var slotRight = oranges[currentSlot + 1];
                var slotBelow = oranges[currentSlot + cols];
                if (slotLeft == 1)
                {
                    tomorrowsOranges[currentSlot-1] = 2;
                }
                if (oranges[slotRight] == 1)
                {
                    tomorrowsOranges[currentSlot+1] = 2;
                }
                if (oranges[slotBelow] == 1)
                {
                    tomorrowsOranges[currentSlot + cols] = 2;
                }
            }
            else if (edge == Edge.TopRight)
            {
                var slotLeft = oranges[currentSlot - 1];
                var slotBelow = oranges[currentSlot + cols];
                if (slotLeft == 1)
                {
                    tomorrowsOranges[currentSlot - 1] = 2;
                }
                if (oranges[slotBelow] == 1)
                {
                    tomorrowsOranges[currentSlot + cols] = 2;
                }
            }
            else if (edge == Edge.Right)
            {
                var slotLeft = oranges[currentSlot - 1];
                var slotAbove = oranges[currentSlot - cols];
                var slotBelow = oranges[currentSlot + cols];
                if (slotLeft == 1)
                {
                    tomorrowsOranges[currentSlot - 1] = 2;
                }
                if (oranges[slotBelow] == 1)
                {
                    tomorrowsOranges[currentSlot + cols] = 2;
                }
                if (oranges[slotAbove] == 1)
                {
                    tomorrowsOranges[currentSlot - cols] = 2;
                }
            }
            else if (edge == Edge.BottomRight)
            {
                var slotLeft = oranges[currentSlot - 1];
                var slotAbove = oranges[currentSlot - cols];
                if (slotLeft == 1)
                {
                    tomorrowsOranges[currentSlot - 1] = 2;
                }
                if (oranges[slotAbove] == 1)
                {
                    tomorrowsOranges[currentSlot - cols] = 2;
                }
            }
            else if (edge == Edge.Bottom)
            {
                var slotLeft = oranges[currentSlot - 1];
                var slotRight = oranges[currentSlot + 1];
                var slotAbove = oranges[currentSlot - cols];
                if (slotLeft == 1)
                {
                    tomorrowsOranges[currentSlot - 1] = 2;
                }
                if (oranges[slotRight] == 1)
                {
                    tomorrowsOranges[currentSlot + 1] = 2;
                }
                if (oranges[slotAbove] == 1)
                {
                    tomorrowsOranges[currentSlot - cols] = 2;
                }
            }
            else if (edge == Edge.BottomLeft)
            {
                var slotRight = oranges[currentSlot + 1];
                var slotAbove = oranges[currentSlot - cols];
                if (oranges[slotRight] == 1)
                {
                    tomorrowsOranges[currentSlot + 1] = 2;
                }
                if (oranges[slotAbove] == 1)
                {
                    tomorrowsOranges[currentSlot - cols] = 2;
                }
            }
            else if (edge == Edge.Left)
            {
                var slotRight = oranges[currentSlot + 1];
                var slotAbove = oranges[currentSlot - cols];
                var slotBelow = oranges[currentSlot + cols];
                if (oranges[slotRight] == 1)
                {
                    tomorrowsOranges[currentSlot + 1] = 2;
                }
                if (oranges[slotBelow] == 1)
                {
                    tomorrowsOranges[currentSlot + cols] = 2;
                }
                if (oranges[slotAbove] == 1)
                {
                    tomorrowsOranges[currentSlot - cols] = 2;
                }
            }
        }
        
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

    public static void PrintAnswer(int numberOfDays)
    {
        string result = string.Empty;
        if (numberOfDays == -1)
        {
            result = "It is impossible to rot all the oranges";
        }
        else
        {
            result = $"It took {numberOfDays} days to rot all the oranges";
        }
        Console.WriteLine(result);
    }
}