using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

public class Lib
{
    public static (int x, int y) S = (0,0);
    public static (int x, int y) E = (0,0);
    public static char[,] grid = null!;
    public static Dictionary<(int x, int y, int idir), long> shortesttohere = null!;
    public static HashSet<(int x, int y)> onshortpath = null!;
    
    public static long Function(string value)
    {
        var lines = value.Split("\r\n");
        grid = new char [lines[0].Length, lines.Length];
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
        shortesttohere = new Dictionary<(int x, int y, int idir), long>(); // shortest distance to here at EACH facing
        shortesttohere[(S.x, S.y, 1)] = 0;

        onshortpath = new HashSet<(int x, int y)>();
        long bestscore = 0;
        
        while (queue.Count > 0) {
            step = queue.Dequeue();
            if (step.Remain == 0) { // reached 'E'
                if (bestscore == 0)
                    bestscore = step.Total;
                if (bestscore == step.Total) {
                    Debug.WriteLine("Best path found!");
                    while (step != null) { // record steps in a valid shortest path, but don't exit loop because there could be more paths
                        onshortpath.Add(step.loc);
                        step = step.prev;
                }   }
            } else { // have not reached 'E'
                for (int idir = 0; idir < dirs.Length; idir++) {
                    (int x, int y) loc = (step.loc.x + dirs[idir].x, step.loc.y + dirs[idir].y);
                    if (grid[loc.x, loc.y] != '#') {
                        var next = new Step(loc, step, idir);
                        long shortest;
                        if (!shortesttohere.TryGetValue((next.loc.x, next.loc.y, idir), out shortest) || shortest >= next.cost) {
                            queue.Enqueue(next, next.Total);
                            shortesttohere[(next.loc.x, next.loc.y, idir)] = next.cost;
        }   }   }   }   }

        Dump();
        return onshortpath.Count;

    }

    private static void Dump()
    {
        for(int y = 0; y < grid.GetLength(1); y++) {
            StringBuilder sb = new StringBuilder(grid.GetLength(0));
            for(int x = 0; x < grid.GetLength(0); x++) {
                char c = grid[x,y];
                if (onshortpath.Contains((x,y)))
                    c = 'O';
                sb.Append(c);
            }
            Debug.WriteLine(sb);
        }
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
