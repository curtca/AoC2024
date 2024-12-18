using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Lib
{
    public static string Function(string input)
    {
        var lines = input.Split("\r\n").ToList();
        int A = int.Parse(Regex.Match(lines[0], @"\d+").Value);
        int B = int.Parse(Regex.Match(lines[1], @"\d+").Value);
        int C = int.Parse(Regex.Match(lines[2], @"\d+").Value);
        var program = Regex.Matches(lines[4], @"\d+").Select(m => int.Parse(m.Value)).ToList();

        int ip = 0;
        var output = new List<int>();

        while (ip < program.Count) {
            int lop = program[ip + 1];
            int cop = lop;
            if      (cop == 4) cop = A;
            else if (cop == 5) cop = B;
            else if (cop == 6) cop = C;

            switch(program[ip]) {
                case 0: // adv
                    A = A / (1 << cop);
                    break;
                case 1: // bxl
                    B ^= lop;
                    break;
                case 2: // bst
                    B = cop % 8;
                    break;
                case 3: // jnz
                    if (A != 0) {
                        ip = lop;
                        ip -= 2;
                    }
                    break;
                case 4: // bxc
                    B ^= C;
                    break;
                case 5: // out
                    output.Add(cop % 8);
                    break;
                case 6: // bdv
                    B = A / (1 << cop);
                    break;
                case 7: // cdv
                    C = A / (1 << cop);
                    break;

            }

            ip += 2;
        }

        return string.Join(",", output);
    }
}

/* 2,4,1,3,7,5,1,5,0,3,4,1,5,5,3,0

 0: 2,4 B = A % 8
 2: 1,3 B = B ^ 3
 4: 7,5 C = A / (1 << B)
 6: 1,5 B = B ^ 5
 8: 0,3 A = A / 8
10: 4,1 B = B ^ C
12: 5,5 Output B % 8
14: 3,0 If A!=0 GOTO 0




*/