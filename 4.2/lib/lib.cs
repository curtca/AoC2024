using System.Collections.Generic;
using System.Linq;

public class Lib
{
    static List<char[]> valid = new List<char[]> {
        new char[] {'M', 'M', 'S', 'S'}, 
        new char[] {'S', 'M', 'M', 'S'}, 
        new char[] {'S', 'S', 'M', 'M'}, 
        new char[] {'M', 'S', 'S', 'M'}, };

    public static long Function(string value)
    {
        var lines = value.Split("\r\n").ToArray();

        return Enumerable.Range(1, lines.Length - 2)
            .SelectMany(r => Enumerable.Range(1, lines[0].Length - 2).Select(c => (Row: r, Col: c)))
            .Count(start => IsAinMAS(lines, start.Row, start.Col));
    }

    private static bool IsAinMAS(string[] lines, int row, int col)
    {
        if (lines[row][col] != 'A') return false;

        char[] c = new char[] {lines[row-1][col-1], lines[row-1][col+1], lines[row+1][col+1], lines[row+1][col-1]};
        return valid.Any(v => v.SequenceEqual(c));
    }
}    

