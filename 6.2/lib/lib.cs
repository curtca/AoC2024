using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class Lib
{
    static char[,] grid = null;
    static bool[,,] traveled = null; // x, y, direction. Have I been here FACING this direction? (whether or not I can actually move out in this direction)
    public static long Function(string value)
    {
        var lines = value.Split(Environment.NewLine);
        grid = new char[lines[0].Length, lines.Length];

        var start = (x: 0, y: 0);
        for(int y = 0; y < lines.Length; y++)
        for(int x = 0; x < lines[0].Length; x++) {
            grid[x, y] = lines[y][x];
            if (grid[x, y] == '^') 
                start = (x, y);
        }

        // Lame brute force: Try an obstacle at every position
        int obstacles = 0;
        for(int y = 0; y < lines.Length; y++)
        for(int x = 0; x < lines[0].Length; x++) {
            if (grid[x, y] == '.') {
                grid[x, y] = '#';
                traveled = new bool[lines[0].Length, lines.Length, 4];

                if (!FindExit(grid, start))
                    obstacles++;
                grid[x, y] = '.';
            }
        }

        return obstacles;
}

    // returns whether can exit
    private static bool FindExit(char[,] grid, (int x, int y) loc)
    {
         (int x, int y)[] dirs = { (0, -1), (1, 0), (0, 1), (-1, 0) };
         int d = 0; // index into dirs
         while (true) {
            if (traveled[loc.x, loc.y, d])
                return false;

            traveled[loc.x, loc.y, d] = true;
            (int x, int y) newpos = (loc.x + dirs[d].x, loc.y + dirs[d].y);
            if (newpos.x < 0 || newpos.y < 0 || newpos.x == grid.GetLength(0) || newpos.y == grid.GetLength(1)) 
                break; // exited the room

            if (grid[newpos.x, newpos.y] == '#') 
                d = (d + 1) % 4; 
            else 
                loc = newpos;
         }
         return true;
    }
}
 
