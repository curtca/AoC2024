using System.Collections.Generic;
using System.Linq;

public class Lib
{
    public static long Function(string value)
    {
        var stones = value.Split(' ').Select(long.Parse).ToList();
        for (int b = 0; b < 25; b++) {
            for (int i = 0; i < stones.Count; i++) {
                string str = stones[i].ToString();
                if (stones[i] == 0) 
                    stones[i] = 1;
                else if (str.Length % 2 == 0) {
                    stones[i] = long.Parse(str.Substring(str.Length / 2, str.Length / 2));
                    stones.Insert(i, long.Parse(str.Substring(0, str.Length / 2)));
                    i++;
                }
                else
                    stones[i] *= 2024;
            }
        }  
        return stones.Count;    }
}
