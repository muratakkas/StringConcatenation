 using StringConcatenation.Extensions;
using System.Collections.Generic;
using System.Diagnostics;

namespace StringConcatenation.ConcatenaTypes
{
    public class ConcatConcatenate : ConcatenateOperationBase, IConcatenateOperation
    {
        public override string ConcatenateString(string concatenated, List<string> list)
        {
            list.ForEach(word =>
            {
                concatenated = string.Concat(concatenated, word);
            }); 
            return concatenated;
        }

        public string OperationName
        {
            get { return "string.Concat"; }
        }
    }
}
