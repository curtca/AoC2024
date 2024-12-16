using System.Collections.Generic;
using System.Linq;

public class Lib
{
    public static (int x, int y) S = (0,0);
    public static (int x, int y) E = (0,0);
    public static HashSet<(int x, int y)> visited = null!;
    
    public static long Function(string value)
    {
        var lines = value.Split("\r\n");
        char[,] grid = new char [lines[0].Length, lines.Length];
        for (int x = 0; x < lines[0].Length; x++)
        for (int y = 0; y < lines   .Length; y++) {
            grid[x,y] = lines[y][x];
            if (grid[x,y] == 'S') S = (x,y);
            if (grid[x,y] == 'E') E = (x,y);
        }

        (int x, int y)[] dirs = {(-1, 0), (1, 0), (0, -1), (0, 1)};
        var queue = new PriorityQueue<Step, long>();
        Step? step = new Step(S, null, 1); // facing east
        queue.Enqueue(step, step.Total);
        visited = new HashSet<(int x, int y)>();
        visited.Add(step.loc);
        long score = 0;
        
        while (true) {
            step = queue.Dequeue();
            if (step.Remain == 0) {
                score = step.cost;
                break;
            }

            for (int idir = 0; idir < dirs.Length; idir++) {
                (int x, int y) loc = (step.loc.x + dirs[idir].x, step.loc.y + dirs[idir].y);
                if (grid[loc.x, loc.y] != '#' && !visited.Contains(loc)) {
                    var next = new Step(loc, step, idir);
                    queue.Enqueue(next, next.Total);
                    visited.Add(loc);
                }
            }
        }

        return score;
    }
}

public class Step
{
    public Step? prev = null!;
    public (int x, int y) loc; 
    public int idir;
    public long cost = 0;
    public int Remain { get =>  Lib.E.x - loc.x + loc.y - Lib.E.y;} // taking advantage of knowing E is in the corner
    public long Total { get => cost + Remain; }
    public Step((int x, int y) loc, Step? prev, int idir) {
        this.loc = loc;
        this.prev = prev;
        this.idir = idir;
        this.cost = prev == null ? 0 : prev.cost + 1;
        if (prev != null && prev.idir != idir)
            cost += 1000;
    }
}
