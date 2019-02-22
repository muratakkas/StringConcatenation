using StringConcatenation.Extensions;
using System.Collections.Generic;
using System.Diagnostics; 

namespace StringConcatenation.ConcatenaTypes
{
    public abstract class ConcatenateOperationBase
    {
        //Returns Calculated time as ticks
        public decimal Execute(List<string> list,int averageCount = 5)
        {
            decimal averageTotal = 0;
            for (int i = 0; i < averageCount; i++)
            {
                averageTotal += CalculateAndConcatenateString(list);
            } 
            return averageTotal / averageCount;
           
        } 
        private decimal CalculateAndConcatenateString(List<string> list)
        {
            string concatenated = string.Empty;
            Stopwatch timer = new Stopwatch();
            timer.Start();
            concatenated = ConcatenateString(concatenated, list);
            timer.Stop();
            return timer.ToMicroSecond();
        }

        public abstract string ConcatenateString(string concatenated, List<string> list);
         

    }
}
