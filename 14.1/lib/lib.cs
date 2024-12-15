using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

public class Lib
{
    public static long Function(string value, long reps, (int x, int y) size)
    {
        var robots = value.Split(Environment.NewLine).Select(line => {
            var r = Regex.Matches(line, @"-?\d+").Select(m => int.Parse(m.Value)).ToList();
            return new Robot((r[0], r[1]), ((r[2] + size.x) % size.x, (r[3] + size.y) % size.y));
        }).ToList();

        foreach (var robot in robots) 
            robot.p = ((int) ((robot.p.x + reps * robot.v.x) % size.x), (int) ((robot.p.y + reps * robot.v.y) % size.y));

        int NW = robots.Where(r => r.p.x < size.x / 2 && r.p.y < size.y / 2).Count();
        int NE = robots.Where(r => r.p.x > size.x / 2 && r.p.y < size.y / 2).Count();
        int SW = robots.Where(r => r.p.x < size.x / 2 && r.p.y > size.y / 2).Count();
        int SE = robots.Where(r => r.p.x > size.x / 2 && r.p.y > size.y / 2).Count();

        return NW * NE * SW * SE;
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
