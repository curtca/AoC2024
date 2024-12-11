using System.Collections.Generic;
using System.Linq;

public class Lib
{
    private static Dictionary<long, long> stones = null!;
    public static long Function(string input, int blinks)
    {
        stones = new Dictionary<long, long>(); // key: stone number, value: quantity
        
        foreach (var stonenum in input.Split(' ').Select(long.Parse)) 
            stones.Add(stonenum, 1);

        for (int b = 0; b < blinks; b++) {
            var copy = stones; // going to need to add/remove elements while blinking
            stones = new Dictionary<long, long>();
            foreach (var stone in copy) {
                long num = stone.Key, count = stone.Value;
                string str = num.ToString();
                if (num == 0) 
                    AddStones(1, count);
                else if (str.Length % 2 == 0) {
                    AddStones(long.Parse(str.Substring(0, str.Length / 2)), count);
                    AddStones(long.Parse(str.Substring(str.Length / 2, str.Length / 2)), count);
                }
                else
                    AddStones(num * 2024, count);
            }
        }  
        return stones.Sum(s => s.Value);    
    }

    static void AddStones(long value, long count)
    {
        stones[value] = stones.GetValueOrDefault(value, 0) + count;
    }
}
