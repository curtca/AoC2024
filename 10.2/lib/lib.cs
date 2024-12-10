using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class Lib
{
    static int[,] grid = null!;
    public static long Function(string value)
    {
        var lines = value.Split("\r\n");
        grid = new int[lines[0].Length, lines.Length];
        List<(int x, int y)> trailheads = new List<(int x, int y)>();

        for(int x = 0; x < lines[0].Length; x++)
        for(int y = 0; y < lines.Length; y++) {
            grid[x, y] = lines[y][x] - '0';
            if (grid[x,y] == 0) 
                trailheads.Add((x,y));
        }

        long sum = trailheads.Sum(Trails);

        return sum;
    }

    private static long Trails((int x, int y) loc)
    {
        var queue = new Queue<(int x, int y)>();
        queue.Enqueue(loc);
        (int x, int y)[] dirs = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };
        long nines = 0;
        while (queue.Count > 0) {
            loc = queue.Dequeue();
            if (grid[loc.x, loc.y] == 9) 
                nines++;
            foreach (var dir in dirs) {
                var next = (x: loc.x + dir.x, y: loc.y + dir.y);
                if (next.x >= 0 && next.y >= 0 && next.x < grid.GetLength(0) && next.y < grid.GetLength(1) 
                    && grid[next.x, next.y] == grid[loc.x, loc.y] + 1)
                    queue.Enqueue(next);
            }
        }
        return nines;
    }
}
