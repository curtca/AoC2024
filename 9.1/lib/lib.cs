using System.Collections.Generic;
using System.Linq;

public class Lib
{
    public static long Function(string value)
    {
        List<int> input = value.ToCharArray().Select(c => c - '0').ToList();
        if (input.Count % 2 == 0)
            input.RemoveAt(input.Count - 2); // make sure we start with a file block on the end, not free space

        List<int> output = new List<int>();
        for (int i = 0; i < input.Count; i += 2)
        {
            int block = i / 2;
            int size = input[i];
            int free = i < input.Count - 1 ? input[i + 1] : 0;
            while (size-- > 0)
                output.Add(block);

            while (free-- > 0) {
                output.Add(input.Count / 2);
                if (--input[input.Count - 1] == 0)
                    input.RemoveRange(input.Count - 2, 2); // eat the free space before the block that is now fully moved
            }
        }
        
        return Enumerable.Range(0, output.Count).Sum(i => (long) i * output[i]);
    }
}
