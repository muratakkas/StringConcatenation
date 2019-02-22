 using StringConcatenation.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StringConcatenation.ConcatenaTypes
{
    public class ConcatWithListConcatenate : ConcatenateOperationBase, IConcatenateOperation
    {
        public override string ConcatenateString(string concatenated, List<string> list)
        { 
            return String.Concat(list.ToArray()); 
        }

        public string OperationName
        {
            get { return "String.Concat(lst.ToArray())"; }
        }
    }
}
