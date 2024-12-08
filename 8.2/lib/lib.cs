using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;

public class Lib
{
    public static long Function(string value)
    {
        var lines = value.Split(Environment.NewLine).ToList();
        char[,] grid = new char[lines[0].Length, lines.Count];
        HashSet<(int,int)> antinodelocs = new HashSet<(int, int)>();
        Dictionary<char, List<(int x, int y)>> antennas = new Dictionary<char, List<(int, int)>>();

        for (int x = 0; x < lines[0].Length; x++)
        for (int y = 0; y < lines.Count; y++)
            if (lines[y][x] != '.') {
                if (!antennas.ContainsKey(lines[y][x]))
                    antennas[lines[y][x]] = new List<(int, int)>();
                antennas[lines[y][x]].Add((x, y));
            }

        foreach (var ant in antennas) {
            char freq = ant.Key;
            var flocs = ant.Value; // freqeuency locations
            for (int f1 = 0; f1 < flocs.Count - 1; f1++)
            for (int f2 = f1 + 1; f2 < flocs.Count; f2++) {
                (int dx, int dy) = (flocs[f1].x - flocs[f2].x, flocs[f1].y - flocs[f2].y);
                (int x, int y) loc = flocs[f1];
                while (loc.x >= 0 && loc.x < lines[0].Length && loc.y >= 0 && loc.y < lines.Count) {
                    antinodelocs.Add(loc);
                    loc.x += dx;
                    loc.y += dy;
                }
                (dx, dy) = (-dx, -dy);
                loc = flocs[f1];
                while (loc.x >= 0 && loc.x < lines[0].Length && loc.y >= 0 && loc.y < lines.Count) {
                    antinodelocs.Add(loc);
                    loc.x += dx;
                    loc.y += dy;
                }
            }

        }

        return antinodelocs.Count;
    }
}
