using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace lib;

public class Lib
{
    public static long Function(string value)
    {
        int[][] dirs = new int[][] {new int[] {0, 1}, new int[] {1, 0}, new int[] {0, -1}, new int[] {-1, 0}, new int[] {-1, 1}, new int[] {1, 1}, new int[] {1, -1}, new int[] {-1, -1}};        
    
        var lines = value.Split("\r\n").ToArray();

        long count = Enumerable.Range(0, lines.Length)
            .SelectMany(r => Enumerable.Range(0, lines[0].Length)
                .Select(c => (Row: r, Col: c)))
            .Sum(start => dirs.Count(dir => SearchWord(lines, "XMAS", start.Row, start.Col, dir[0], dir[1])));

        return count;
    }

    private static bool SearchWord(string[] lines, string word, int row, int col, int dx, int dy, int index = 0)
    {
        if (index == 0 && lines[row][col] != word[0]) return false;

        if (index == word.Length - 1) return true;        

        int nextRow = row + dx;
        int nextCol = col + dy;

        if (nextRow < 0 || nextRow >= lines.Length || 
            nextCol < 0 || nextCol >= lines[0].Length || 
            lines[nextRow][nextCol] != word[index + 1])
            return false;

        return SearchWord(lines, word, nextRow, nextCol, dx, dy, index + 1);
    }
}    

