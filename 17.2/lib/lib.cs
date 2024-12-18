using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

public class Lib
{
    public static string Function(string input)
    {
        var lines = input.Split(Environment.NewLine).ToList();
        int A = int.Parse(Regex.Match(lines[0], @"\d+").Value);
        int B = int.Parse(Regex.Match(lines[1], @"\d+").Value);
        int C = int.Parse(Regex.Match(lines[2], @"\d+").Value);
        var program = Regex.Matches(lines[4], @"\d+").Select(m => int.Parse(m.Value)).ToList();

        int ip = 0;
        var output = new List<int>();

        long big = 281474976710655;
        int count = 0;
        while (big > 0) {
            count++;
            big /=8;
            Debug.WriteLine($"Count: {count}: {big}");
        }


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

 0: 2,4 B = A % 8 // take last 3 bits of A
 2: 1,3 B = B ^ 3 // flip B's last 2 bits
 4: 7,5 C = A / (1 << B) // C starts at A, is divided by some number 2^B (B < 8), so divided by 128 max
 6: 1,5 B = B ^ 5 // flip last and 3rd-to-last 2 bits (bits 1 and 3 from the right)
 2+6: Flip 2nd and 3rd bits of B.
 8: 0,3 A = A / 8
10: 4,1 B = B ^ C
12: 5,5 Output B % 8
14: 3,0 If A!=0 GOTO 0

When B is output on ip12, 

A is 48 bits (16*3), with at least 1 bit non-zero
2 => 
Rightmost 3 bits of B = 010 (2)
Rightmost 3 bits of C = 101 (5)
A = 2^15 - 2^16

Backwards:
A = 0
B = 0
C = ?
Output 0
Rightmost 3 bits of B = 000 (0)
Rightmost 3 bits of C = 111 (7)
A *= 8 -- Amin = 0, Amax = 7
Rightmost 3 bits of B = 101 (5)





Starting A: 35,184,372,088,832 < A < 281,474,976,710,655


*/