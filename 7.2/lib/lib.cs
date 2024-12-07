using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualBasic;

public class Lib
{
    public static long Function(string value)
    {
        var eqs = value.Split(Environment.NewLine).Select(line => {
            var parts = line.Split(":");
            return new EQ(long.Parse(parts[0]), parts[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(n => long.Parse(n)).ToList());
        });

        return eqs.Where(Solveable).Sum(eq => eq.result);   
    }

    private static bool Solveable(EQ eq)
    {
        long first = eq.operands.First();
        var rest = eq.operands.Skip(1).ToList();

        return SolveHelper(eq.result, first, Ops.Plus, rest)
            || SolveHelper(eq.result, first, Ops.Times, rest)
            || SolveHelper(eq.result, first, Ops.Concat, rest);
    }

    private static bool SolveHelper(long result, long sofar, Ops op, List<long> operands)
    {
        if (operands.Count == 0)
            return result == sofar;

        long next = operands.First();

        switch (op) {
        case Ops.Plus:
            sofar += next;
            break;
        case Ops.Times:
            sofar *= next;
            break;
        case Ops.Concat:
            sofar = long.Parse(sofar.ToString() + next.ToString());
            break;
        default:
            break;
        }

        var rest = operands.Skip(1).ToList();
        return SolveHelper(result, sofar, Ops.Plus,   rest) 
            || SolveHelper(result, sofar, Ops.Times,  rest)
            || SolveHelper(result, sofar, Ops.Concat, rest);
    }
}

public enum Ops
{
    Plus, Times, Concat
}

public struct EQ
{
    public long result;
    public List<long> operands;

    public EQ(long result, List<long> operands)
    {
        this.result = result;
        this.operands = operands;
    }
}

