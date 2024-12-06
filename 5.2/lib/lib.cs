using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

public class Lib
{
    static List<List<int>> rules;
    static List<int> fullrules; 
    public static long Function(string value)
    {
        var parts = value.Split("\n\n");
        rules = parts[0].Split("\n").Select(line => line.Split('|').Select(n => int.Parse(n)).ToList()).ToList();
        List<int[]> orders = parts[1].Split("\n").Select(line => line.Split(',').Select(n => int.Parse(n)).ToArray()).ToList();

        return orders.Where(o => {
           fullrules = SortOrder(rules.Where(r => o.Contains(r[0]) && o.Contains(r[1])).ToList());
           return !ValidOrder(o);})
           .Sum(o => {
                var sorted = Sorted(o).ToArray();
                long i = sorted[o.Length/2];
                return i;
            });
    }

    private static List<int> Sorted(int[] o)
    {
        var sorted = o.ToList();
        sorted.Sort(OrderSorter);
        return sorted;
    }

    private static int OrderSorter(int x, int y)
    {
        return fullrules.IndexOf(x) < fullrules.IndexOf(y) ? -1 : 1;
    }

    private static bool ValidOrder(int[] o)
    {
        bool valid = Enumerable.Range(0, o.Length - 1).All(i => fullrules.IndexOf(o[i]) < fullrules.IndexOf(o[i + 1]));
        return valid;
    }

    // For a given set of rules, produce the proper sort order
    public static List<int> SortOrder(List<List<int>> rules)
    {
        // Create graph of dependencies
        var graph = new Dictionary<int, HashSet<int>>();
        var inDegree = new Dictionary<int, int>();
        var allNodes = new HashSet<int>();

        // Build graph and track in-degrees
        foreach (var c in rules) {
            // Ensure nodes exist in graph
            if (!graph.ContainsKey(c[0])) graph[c[0]] = new HashSet<int>();
            if (!graph.ContainsKey(c[1])) graph[c[1]] = new HashSet<int>();

            // Update graph and in-degrees
            if (!graph[c[0]].Contains(c[1])){
                graph[c[0]].Add(c[1]);
                inDegree[c[1]] = inDegree.GetValueOrDefault(c[1], 0) + 1;
                inDegree[c[0]] = inDegree.GetValueOrDefault(c[0], 0);
            }

            // Track all nodes
            allNodes.Add(c[0]);
            allNodes.Add(c[1]);
        }

        // Queue nodes with no incoming edges
        var queue = new Queue<int>(allNodes.Where(node => !inDegree.ContainsKey(node) || inDegree[node] == 0));

        var result = new List<int>();

        // Topological sorting
        while (queue.Count > 0) {
            var current = queue.Dequeue();
            result.Add(current);

            if (graph.ContainsKey(current)) {
                foreach (var neighbor in graph[current])
                {
                    inDegree[neighbor]--;
                    if (inDegree[neighbor] == 0)
                        queue.Enqueue(neighbor);
                }
            }
        }

        if (result.Count != allNodes.Count)
            throw new InvalidOperationException("Cyclic dependencies detected");
            
        return result;
    }
}
