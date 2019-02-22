using StringConcatenation.Extensions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace StringConcatenation.ConcatenaTypes
{
    public class StringBuilderConcatenate : ConcatenateOperationBase, IConcatenateOperation
    {
        public override string ConcatenateString(string concatenated, List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            list.ForEach(word =>
            {
                sb.Append(word);
            });  
            return sb.ToString();
        }

        public string OperationName
        {
            get { return "StringBuilder"; }
        }
    }
}
