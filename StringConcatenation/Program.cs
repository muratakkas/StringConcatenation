
using StringConcatLibrary;
using System;
using System.Collections.Generic;

namespace StringConcatenation
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Dictionary<string, string> blockNames = new Dictionary<string, string>();
            blockNames.Add(ConcatHelper.BLOCK_1, "A");
            blockNames.Add(ConcatHelper.BLOCK_2, "D");
            blockNames.Add(ConcatHelper.BLOCK_3, "G");
            blockNames.Add(ConcatHelper.BLOCK_4, "J");
            ConcatHelper.StartTest("2_0", blockNames);
        } 

        
    }
}
