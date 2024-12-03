using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace lib;

public class Lib
{
    public static long Function(string input)
    {
        Regex re = new Regex(@"(?:don't\(\)|do\(\)|mul\((\d+),(\d+)\))");
        long sum = 0;
        bool enabled = true;
        foreach (Match match in re.Matches(input)) {
            switch (match.Value) {
                case "do()":
                    enabled = true;
                    break;
                case "don't()":
                    enabled = false;
                    break;
                default:
                    if (enabled)
                        sum += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
                    break;
            }
        };
        return sum;
    }
}
