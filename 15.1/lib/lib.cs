using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class Lib
{
    public static long Function(string value)
    {
        var parts = value.Split(Environment.NewLine + Environment.NewLine);
        var maplines = parts[0].Split(Environment.NewLine);
        char [,] grid = new char[maplines[0].Length, maplines.Length];
        (int x, int y) robot = (0,0);
        for(int x = 0; x < maplines[0].Length; x++)
        for(int y = 0; y < maplines.Length; y++) {
            grid[x, y] = maplines[y][x];
            if (grid[x, y] == '@') {
                robot = (x, y);
                grid[x, y] = '.';
            }
        }
        (int x, int y)[] dirs = {(-1, 0), (1, 0), (0, -1), (0, 1)}; // 0=left 1=right 2=up 3=down
        var charmoves = parts[1].Split(Environment.NewLine).SelectMany(line => line.ToCharArray()).ToList();
        var moves = charmoves.Select(c => Array.IndexOf(new char[] {'<', '>', '^', 'v'}, c)).ToList();

        foreach(var move in moves) {
            (int x, int y) newloc = (robot.x + dirs[move].x, robot.y + dirs[move].y);
            if (grid[newloc.x, newloc.y] == '.') 
                robot = (newloc.x, newloc.y);
            else {
                int cbox = 0;
                while (grid[newloc.x, newloc.y] == 'O') {
                    cbox++;
                    newloc = (newloc.x + dirs[move].x, newloc.y + dirs[move].y);
                }
                if (grid[newloc.x, newloc.y] == '.') { // push is happening
                    newloc = (robot.x + dirs[move].x, robot.y + dirs[move].y);
                    robot = (newloc.x, newloc.y);
                    grid[robot.x, robot.y] = '.'; // where first box (closest to robot) was
                    while (cbox-- > 0) 
                        newloc = (newloc.x + dirs[move].x, newloc.y + dirs[move].y);
                    grid[newloc.x, newloc.y] = 'O'; // where last box (farthest from robot) now is
                }
            }
        }

        Dump(grid, robot);

        long sum = 0;
        for(int y = 0; y < grid.GetLength(1); y++) 
            for(int x = 0; x < grid.GetLength(0); x++) 
                if (grid[x, y] == 'O')
                    sum += x + 100 * y;
        
        return sum;
    }

    private static void Dump(char[,] grid, (int x, int y) robot)
    {
        for(int y = 0; y < grid.GetLength(1); y++) {
            for(int x = 0; x < grid.GetLength(0); x++) 
                Debug.Write("" + (x == robot.x && y == robot.y ? '@' : grid[x, y]));
            Debug.WriteLine(null);
        }
    }
}
