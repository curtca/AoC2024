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
        var lines = value.Split(Environment.NewLine).ToArray();

        return Enumerable.Range(1, lines.Length - 2)
            .SelectMany(r => Enumerable.Range(1, lines[0].Length - 2).Select(c => (row: r, col: c)))
            .Count(start => {
                if (lines[start.row][start.col] != 'A') return false;

                char[] c = new char[] {
                    lines[start.row-1][start.col-1], 
                    lines[start.row-1][start.col+1], 
                    lines[start.row+1][start.col+1], 
                    lines[start.row+1][start.col-1]};
                return valid.Any(v => v.SequenceEqual(c));
            });
    }
}    

