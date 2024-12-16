using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public class Lib
{
    public static long Function(string value)
    {
        var parts = value.Split(Environment.NewLine + Environment.NewLine);
        var maplines = parts[0].Split(Environment.NewLine);
        char [,] grid = new char[2 * maplines[0].Length, maplines.Length];
        (int x, int y) robot = (0,0);
        for(int x = 0; x < maplines[0].Length; x++)
        for(int y = 0; y < maplines.Length; y++) {
            grid[2 * x, y] = maplines[y][x];
            if (maplines[y][x] == '@') {
                robot = (2 * x, y);
                grid[2 * x, y] = '.';
            }
            grid[2 * x + 1, y] = grid[2 * x, y];
            if (maplines[y][x] == 'O') {
                grid[2 * x, y] = '['; grid[2 * x + 1, y] = ']';
            }
        }
        (int x, int y)[] dirs = {(-1, 0), (1, 0), (0, -1), (0, 1)}; // 0=left 1=right 2=up 3=down
        var charmoves = parts[1].Split(Environment.NewLine).SelectMany(line => line.ToCharArray()).ToList();
        var moves = charmoves.Select(c => Array.IndexOf(new char[] {'<', '>', '^', 'v'}, c)).ToList();
        int left=0, right=1, up=2, down=3;
        string[] strdir = {"left", "right", "up", "down"};
        Dump(grid, robot);

        for (int imove = 0; imove < moves.Count; imove++) {
            int move = moves[imove];
            Debug.WriteLine($"{imove}: {strdir[move]}");
            var dir = dirs[move];
            (int x, int y) newloc = (robot.x + dir.x, robot.y + dir.y);
            char cnext = grid[newloc.x, newloc.y];
            if (cnext == '.' || ((cnext == '[' || cnext == ']') && TryPush(newloc, move))) // Can either walk there unobstructed, or can push box
                robot = newloc;
            Dump(grid, robot);
        }

        long sum = 0;
        for(int y = 0; y < grid.GetLength(1); y++) 
            for(int x = 0; x < grid.GetLength(0); x++) 
                if (grid[x, y] == '[')
                    sum += x + 100 * y;
        
        return sum;

        bool TryPush((int x, int y) box1, int idir) // if possible, push the block that is HERE in the given direction, and all blocks behind
        {
            var dir = dirs[idir];

            var boxes = new List<(int x, int y)>();
            if (CanMove(box1, idir, boxes)) {
                foreach(var box in boxes) {
                    grid[box.x, box.y] = '.';
                    grid[box.x + 1, box.y] = '.';
                    grid[box.x + dir.x, box.y + dir.y] = '[';
                    grid[box.x + dir.x + 1, box.y + dir.y] = ']';
                }
                return true;
            }

            return false;
        }



        bool CanMove((int x, int y) box1, int idir, List<(int x, int y)> boxes)
        {
            /* Concepts of a plan:

                Recursively CHECK for moving block(s) behind this one.
                Build BOTTOMS-UP list of boxes to move

                Sideways: Just get list of boxes behind this one.

                Vertical: Check up to 2 blocks behind this one. 
                Note (again): When moving boxes, must move them "bottoms up" from leaf nodes to avoid stomping on other boxes.
            */
            char here = grid[box1.x, box1.y];
            Debug.Assert(here == '[' || here == ']');
            var dir = dirs[idir];
            var box2 = (x: box1.x + (here == '[' ? 1 : -1), y: box1.y);
            if (here == ']')
                (box1, box2) = (box2, box1); // box1 is left side of box, regardless of which side we hit coming in

            if (idir == left || idir == right) {
                var pastboxloc = (x: box1.x + (idir == left ? -1 : 2), y: box1.y); // box1 can be left or right side of box here
                var pastboxchar = grid[pastboxloc.x, pastboxloc.y];
                if (pastboxchar == '#')
                    return false;
                else if (pastboxchar == '.') {
                    if (!boxes.Contains(box1)) boxes.Add(box1);
                    return true;
                } else { // box
                    bool canmove = CanMove(pastboxloc, idir, boxes);
                    if (canmove && (!boxes.Contains(box1))) boxes.Add(box1);
                    return canmove;
                }
            } else { // vertical
                var pastboxlocL = (x: box1.x, y: box1.y + dir.y);
                var pastboxlocR = (x: box2.x, y: box2.y + dir.y);
                var pastboxcharL = grid[pastboxlocL.x, pastboxlocL.y];
                var pastboxcharR = grid[pastboxlocR.x, pastboxlocR.y];
                if (pastboxcharL == '#' || pastboxcharR == '#')
                    return false;
                else if (pastboxcharL == '.' && pastboxcharR == '.') {
                    if (!boxes.Contains(box1)) boxes.Add(box1);
                    return true;
                }
                else { // at least one box
                    bool groovy = true;
                    (int x, int y) box = (0,0);
                    if (pastboxcharL == ']') {
                        box = (pastboxlocL.x -1, pastboxlocL.y);
                        groovy &= CanMove(box, idir, boxes);
                    }
                    if (pastboxcharL == '[') {
                        box = (pastboxlocL.x,    pastboxlocL.y);
                        groovy &= CanMove(box, idir, boxes);
                    }
                    if (pastboxcharR == '[') {
                        box = (pastboxlocL.x +1, pastboxlocL.y);
                        groovy &= CanMove(box, idir, boxes);
                    }
                    if (groovy && !boxes.Contains(box1)) boxes.Add(box1);
                    return groovy;
                }
            }

            throw new UnreachableException("This code path should never be reached");
        }
    }

    private static void Dump(char[,] grid, (int x, int y) robot)
    {
        for(int y = 0; y < grid.GetLength(1); y++) {
            StringBuilder sb = new StringBuilder(grid.GetLength(0));
            for(int x = 0; x < grid.GetLength(0); x++) 
                sb.Append("" + (x == robot.x && y == robot.y ? '@' : grid[x, y]));
            Debug.WriteLine(sb.ToString());
        }
    }
}
