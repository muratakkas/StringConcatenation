using System;
using System.Collections.Generic;
using System.Text;

namespace StringConcatenation.ConcatenaTypes
{
    interface IConcatenateOperation
    {
        //Returns Calculated time as ticks
        decimal Execute(List<string> data, int averageCount = 5);

        string OperationName { get; }
    }
}
