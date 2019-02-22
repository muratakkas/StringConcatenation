 using StringConcatenation.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StringConcatenation.ConcatenaTypes
{
    public class JoinConcatenate : ConcatenateOperationBase, IConcatenateOperation
    {
        public override string ConcatenateString(string concatenated, List<string> list)
        { 
            return String.Join("", list.ToArray());
        }

        public string OperationName
        {
            get { return "String.Join"; }
        }
    }
}
