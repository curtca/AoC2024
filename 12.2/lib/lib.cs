using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

public class Lib
{
    public static long Function(string value)
    {

        var lines = value.Split(Environment.NewLine);
        int rows = lines.Length, cols = lines[0].Length;
        char[,] grid = new char[cols, rows];
        for(int y = 0; y < lines.Length; y++)
        for(int x = 0; x < lines[0].Length; x++) 
            grid[x, y] = lines[y][x];        
        bool[,] visited = new bool[rows, cols];
        var groups = new List<List<(int x, int y)>>();
        int targetValue = 0;
        List<(int x, int y)> group = null!;
        (int x, int y)[] dirs = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++)
        {
            if (visited[i, j]) continue;

            group = new List<(int x, int y)>();
            targetValue = grid[i, j];
            DFS(i, j);
            groups.Add(group);
        }

        return groups.Sum(g => g.Count * Sides(g));

        void DFS(int x, int y)
        {
            if (x < 0 || x >= rows || y < 0 || y >= cols || visited[x, y] || grid[x, y] != targetValue)
                return;

            visited[x, y] = true;
            group.Add((x, y));

            foreach (var dir in dirs)
                DFS(x + dir.x, y + dir.y);
        }

        int Sides(List<(int x, int y)> g)
        {
            /* Concepts of a plan:
                Given a completed group,
                for each loc
                    for each direction
                        if there is no neighbor in that direction (it's on the perimeter)
                            if there IS NOT a shared edge to the left (it's the "first" space on that edge)
                                sides++
            */

            int sides = g.Sum(loc => dirs.Count(d => {
                var nbr = (x: loc.x + d.x, y: loc.y + d.y);
                bool side = false;
                if (!(nbr.x >= 0 && nbr.x < cols && nbr.y >= 0 && nbr.y < rows && grid[nbr.x, nbr.y] == grid[loc.x, loc.y])) { // next loc in this dir NOT in group?
                    var left = (x: -d.y, y: d.x);
                    var lnbr = (x: loc.x + left.x, y: loc.y + left.y);
                    side = true;
                    if (lnbr.x >= 0 && lnbr.x < cols && lnbr.y >= 0 && lnbr.y < rows && grid[lnbr.x, lnbr.y] == grid[loc.x, loc.y]) { // left neighbor in group?
                        var cnr = (x: loc.x + d.x + left.x, y: loc.y + d.y + left.y);
                        side = cnr.x >= 0 && cnr.x < cols && cnr.y >= 0 && cnr.y < rows && grid[cnr.x, cnr.y] == grid[loc.x, loc.y]; 
                    }
                }
                return side;
            }));
            return sides;
        }
    }
}


