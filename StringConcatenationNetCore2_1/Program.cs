using StringConcatLibrary;
using System;
using System.Collections.Generic;

namespace StringConcatenationNetCore2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> blockNames = new Dictionary<string, string>();
            blockNames.Add(ConcatHelper.BLOCK_1, "B");
            blockNames.Add(ConcatHelper.BLOCK_2, "E");
            blockNames.Add(ConcatHelper.BLOCK_3, "H");
            blockNames.Add(ConcatHelper.BLOCK_4, "K");
            ConcatHelper.StartTest("2_1", blockNames);
        }
    }
}
