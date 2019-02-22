using StringConcatenation.ConcatenaTypes;
using System;
using System.Collections.Generic;
using System.IO;

namespace StringConcatLibrary
{
    public class ConcatHelper
    {
        #region Fields

        static string LONG_TEXT = @"Loremipsumdolorsitamet,consecteturadipiscingelit,seddoeiusmodtemporincididuntutlaboreetdoloremagnaaliqua.Porttitormassaidnequealiquamvestibulummorbibseddoeiusmodtemporincididuntutlaboreetdoloremagnaaliqua.Porttitormassaidnequealiquamvestibulummorb";
        static string ResultFormat = "Execution time for '{0}' was {1:F1} microseconds. for {2} Line and {3} Column";
        static string logPathFormat = @"C:\temp\concatResults{0}.txt";
        static string logPath = "";
        #endregion

        private static List<string> PrepareDataForTest(int linecount, int columncount)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < linecount; i++)
            {
                result.Add(LONG_TEXT.Substring(0, columncount));
            }

            return result;
        }
        private static void TestForLineEffect()
        {
            LogTofile("Testing for line effect");
            LogTofile(Environment.NewLine);
            TestAllMethods(PrepareDataForTest(1000, 100));
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            TestAllMethods(PrepareDataForTest(2100, 100));
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            TestAllMethods(PrepareDataForTest(4250, 100));
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            TestAllMethods(PrepareDataForTest(8500, 100));
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
        }

        private static void TestForColumnEffect()
        {
            LogTofile("Testing for column effect");
            LogTofile(Environment.NewLine);
            TestAllMethods(PrepareDataForTest(4250, 25));
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            TestAllMethods(PrepareDataForTest(4250, 50));
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            TestAllMethods(PrepareDataForTest(4250, 100));
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            TestAllMethods(PrepareDataForTest(4250, 200));
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
        }

        private static void TestAllMethods(List<string> data)
        {
            ExecuteLogToConsole(new OperatorConcatenate(), data);
            ExecuteLogToConsole(new StringBuilderConcatenate(), data);
            ExecuteLogToConsole(new ConcatConcatenate(), data);
            ExecuteLogToConsole(new ConcatWithListConcatenate(), data);
            ExecuteLogToConsole(new JoinConcatenate(), data);
            ExecuteLogToConsole(new LinqConcatenate(), data);
        }

        private static void ExecuteLogToConsole(IConcatenateOperation operation, List<string> data)
        {
            decimal duration = operation.Execute(data);
            string message = string.Format(ResultFormat, operation.OperationName, duration, data.Count, data[0].Length);
            LogTofile(message);
            LogTofile(Environment.NewLine); 
        }

        public static void StartTest(string netCoreversion)
        {
            logPath = string.Format(logPathFormat, netCoreversion); 
            if (File.Exists(logPath)) File.Delete(logPath);
            string runtime = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
            LogTofile(string.Format("Testing for {0} - {1}", runtime, netCoreversion));
            LogTofile(Environment.NewLine);
            TestForLineEffect();
            TestForColumnEffect();
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine(); 
        }

        private static void LogTofile(string message)
        {
            File.AppendAllText(logPath, message); 
            Console.WriteLine(message);
        }
    }
}
