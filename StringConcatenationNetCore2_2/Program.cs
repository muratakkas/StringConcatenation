using StringConcatLibrary;
using System;
using System.Collections.Generic;

namespace StringConcatenationNetCore2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> blockNames = new Dictionary<string, string>();
            blockNames.Add(ConcatHelper.BLOCK_1, "C");
            blockNames.Add(ConcatHelper.BLOCK_2, "F");
            blockNames.Add(ConcatHelper.BLOCK_3, "I");
            blockNames.Add(ConcatHelper.BLOCK_4, "L");
            ConcatHelper.StartTest("2_2", blockNames);
        }
    }
}
