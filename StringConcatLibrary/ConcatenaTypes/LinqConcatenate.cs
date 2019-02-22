using StringConcatenation.Extensions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace StringConcatenation.ConcatenaTypes
{
    public class LinqConcatenate : ConcatenateOperationBase, IConcatenateOperation
    {
        public override string ConcatenateString(string concatenated, List<string> list)
        { 
            return list.ToArray().Aggregate((partialPhrase, wordtoConcantenate) => $"{partialPhrase} {wordtoConcantenate}");
        }

        public string OperationName
        {
            get { return "Linq - Aggregate"; }
        }
    }
}
