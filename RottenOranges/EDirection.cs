/* Recieve 3 inputs, int row, int column and int[] oranges
 oranges is a 1D representation of a 2D array where rows and columns
define the scope of the 2D array.

 The array represents a crate of oranges, 0 for an empty slot, 1 for a fresh orange
and 2 for a rotten orange

 If a fresh orange has a rotten orange touching it will be rotten by tomorrow.

 Return how many days it takes to rot all the oranges or -1 if it is impossible to rot all the oranges*/

internal enum EDirection
{
    Right, Left, Top, Bottom
}