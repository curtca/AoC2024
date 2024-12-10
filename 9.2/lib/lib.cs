using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Lib
{
    public static long Function(string value)
    {
        List<int> input = value.ToCharArray().Select(c => c - '0').ToList();
        List<(int id, int size)> blocks = input.Select((n, i) => (i % 2 == 0 ? i / 2 : -1, n)).ToList(); // (blocknum, size) -- blocknum == -1 means free space

        for (int i = blocks.Count - 1; i >= 0; i--) {
            if (blocks[i].id == -1) continue;

            int ifree = blocks.FindIndex(b => b.id == -1 && b.size >= blocks[i].size);
            if (ifree > i || ifree == -1) continue; 

            var block = blocks[i];
            blocks[i] = (-1, block.size); 
            int free = blocks[ifree].size;
            if (block.size < free) {
                blocks[ifree] = (-1, free - block.size);
                blocks.Insert(ifree, block);
                i++; 
            }
            else
                blocks[ifree] = block;
        }

        long n = 0, sum = 0;
        for (int i = 0; i < blocks.Count; i++) {
            for (int j = 0; j < blocks[i].size; j++) {
                if (blocks[i].id != -1) 
                    sum += n * blocks[i].id;
                n++;
            }
        }

        return sum;
    }
}
