using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

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
        var groups = new List<List<(int, int)>>();
        int targetValue = 0;
        List<(int, int)> group = null!;
        (int x, int y)[] dirs = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++)
        {
            if (visited[i, j]) continue;

            group = new List<(int, int)>();
            targetValue = grid[i, j];
            DFS(i, j);

            // Add non-empty groups
            Debug.Assert(group.Any());
            if (group.Any())
                groups.Add(group);
        }

        return groups.Sum(g => g.Count * Perimeter(g));

        void DFS(int x, int y)
        {
            if (x < 0 || x >= rows || y < 0 || y >= cols || visited[x, y] || grid[x, y] != targetValue)
                return;

            visited[x, y] = true;
            group.Add((x, y));

            foreach (var dir in dirs)
                DFS(x + dir.x, y + dir.y);
        }

        int Perimeter(List<(int x, int y)> g)
        {
            return g.Sum(loc => 4 - dirs.Count(d => {
                var nbr = (x: loc.x + d.x, y: loc.y + d.y);
                return nbr.x >= 0 && nbr.x < cols && nbr.y >= 0 && nbr.y < rows && grid[nbr.x, nbr.y] == grid[loc.x, loc.y];

            }));
        }
    }
}
