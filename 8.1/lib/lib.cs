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
                int x = 2 * flocs[f1].x - flocs[f2].x;
                int y = 2 * flocs[f1].y - flocs[f2].y;
                if (x >= 0 && y >= 0 && x < lines[0].Length && y < lines.Count)
                    antinodelocs.Add((x, y));
                x = 2 * flocs[f2].x - flocs[f1].x;
                y = 2 * flocs[f2].y - flocs[f1].y;
                if (x >= 0 && y >= 0 && x < lines[0].Length && y < lines.Count)
                    antinodelocs.Add((x, y));
            }
        }

        return antinodelocs.Count;
    }
}
