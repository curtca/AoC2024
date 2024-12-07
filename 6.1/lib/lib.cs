using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class Lib
{
    static char[,] grid = null;
    static HashSet<(int, int)> visited = null;
    public static long Function(string value)
    {
        var lines = value.Split(Environment.NewLine);
        grid = new char[lines[0].Length, lines.Length];
        visited = new HashSet<(int, int)>();
        var start = (x: 0, y: 0);
        for(int y = 0; y < lines.Length; y++)
        for(int x = 0; x < lines[0].Length; x++) {
            grid[x, y] = lines[y][x];
            if (grid[x, y] == '^') {
                start = (x, y);
                grid[x, y] = '.';
            }
        }

        FindExit(grid, start);

        return visited.Count;
}

    private static void FindExit(char[,] grid, (int x, int y) loc)
    {
         (int x, int y)[] dirs = { (0, -1), (1, 0), (0, 1), (-1, 0) };
         int d = 0; // index into dirs
         while (true) {
             visited.Add(loc);
            (int x, int y) newpos = (loc.x + dirs[d].x, loc.y + dirs[d].y);
            if (newpos.x < 0 || newpos.y < 0 || newpos.x == grid.GetLength(0) || newpos.y == grid.GetLength(1)) 
                break;

             if (grid[newpos.x, newpos.y] == '#') {
                d = (d + 1) % 4; 
                newpos = (loc.x + dirs[d].x, loc.y + dirs[d].y);
             }

             loc = newpos;
         }
    }
}
 
