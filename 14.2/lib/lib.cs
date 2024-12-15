using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

public class Lib
{
    public static long Function(string value, (int x, int y) size)
    {
        var robots = value.Split(Environment.NewLine).Select(line => {
            var r = Regex.Matches(line, @"-?\d+").Select(m => int.Parse(m.Value)).ToList();
            return new Robot((r[0], r[1]), ((r[2] + size.x) % size.x, (r[3] + size.y) % size.y));
        }).ToList();

        int itree = 0;
        int [,] tree = null!;

        while (true) {
            itree++;
            tree = new int[size.x, size.y]; // count of robots at each space
            foreach (var robot in robots) {
                robot.p = ((int) ((robot.p.x + robot.v.x) % size.x), (int) ((robot.p.y + robot.v.y) % size.y));
                tree[robot.p.x, robot.p.y]++;
            }

            if (IsPossibleTree()) {
                StringBuilder sb = new StringBuilder(size.y * (size.x + 2));

                for (int y = 0; y < size.y; y++) {
                    for (int x = 0; x < size.x; x++) 
                        sb.Append((char) (tree[x,y] > 0 ? 'A' - 1 + tree[x,y] : ' '));
                    sb.AppendLine();
                }
                Debug.WriteLine($"After {itree} iterations:\n{sb.ToString()}\n");
                return itree;
            }
            if (itree % 100 == 0)
                Debug.WriteLine($"{itree} iterations");
        } 

        bool IsPossibleTree() 
        {
            int contig = 0;
            int last = 0;
            for (int y = 0; y < size.y; y++)
            for (int x = 0; x < size.x; x++) {
                if (tree[x, y] == last && last > 0) {
                    if (contig++ >= 10)
                        return true;
                }
                else {
                    contig = 0;
                    last = tree[x, y];
                }

            }
                
            return false;
        }

        return 0;
    }

    class Robot
    {
        public (int x, int y) p;
        public (int x, int y) v;

        public Robot((int x, int y) p, (int x, int y) v)
        {
            this.p = p;
            this.v = v;
        }
    }
}
