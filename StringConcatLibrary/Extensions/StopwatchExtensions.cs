using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace StringConcatenation.Extensions
{
   public static class StopwatchExtensions
    {
        public static decimal ToMicroSecond( this Stopwatch timer)
        {
            return (decimal)timer.Elapsed.Ticks / 10M;
        }
    }
}
