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
        static string concatTestValuesFile = @"C:\temp\concatTestValuesFile.csv";
        static string logPath = "";
        public static string BLOCK_1 = "1";
        public static string BLOCK_2 = "2";
        public static string BLOCK_3 = "3";
        public static string BLOCK_4 = "4";
        #endregion

        private static List<string> PrepareDataForTest(int linecount, int columncount)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < linecount; i++)
            {
                result.Add(LONG_TEXT.Substring(0, columncount) + Environment.NewLine);
            }

            return result;
        }
        private static void TestForLineEffect()
        {
            LogTofile("Testing for line effect");
            LogTofile(Environment.NewLine);
            TestAllMethodsForRowEffect(PrepareDataForTest(1000, 100), BlockColumnNames[BLOCK_1]);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            TestAllMethodsForRowEffect(PrepareDataForTest(2100, 100), BlockColumnNames[BLOCK_2]);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            TestAllMethodsForRowEffect(PrepareDataForTest(4250, 100), BlockColumnNames[BLOCK_3]);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            TestAllMethodsForRowEffect(PrepareDataForTest(8500, 100), BlockColumnNames[BLOCK_4]);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
        }

        private static void TestForColumnEffect()
        {
            LogTofile("Testing for column effect");
            LogTofile(Environment.NewLine);
            TestAllMethodsForColumnEffect(PrepareDataForTest(4250, 25), BlockColumnNames[BLOCK_1]);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            TestAllMethodsForColumnEffect(PrepareDataForTest(4250, 50), BlockColumnNames[BLOCK_2]);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            TestAllMethodsForColumnEffect(PrepareDataForTest(4250, 100), BlockColumnNames[BLOCK_3]);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            TestAllMethodsForColumnEffect(PrepareDataForTest(4250, 200), BlockColumnNames[BLOCK_4]);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
            LogTofile(Environment.NewLine);
        }

        private static void TestAllMethodsForRowEffect(List<string> data, string Column)
        {
            ExecuteLogToConsole(new OperatorConcatenate(), data, Column,"1");
            ExecuteLogToConsole(new StringBuilderConcatenate(), data, Column, "2");
            ExecuteLogToConsole(new ConcatConcatenate(), data, Column,"3");
            ExecuteLogToConsole(new ConcatWithListConcatenate(), data, Column, "4");
            ExecuteLogToConsole(new JoinConcatenate(), data, Column, "5");
            ExecuteLogToConsole(new LinqConcatenate(), data, Column, "6");
        }

        private static void TestAllMethodsForColumnEffect(List<string> data, string Column)
        {
            ExecuteLogToConsole(new OperatorConcatenate(), data, Column, "7");
            ExecuteLogToConsole(new StringBuilderConcatenate(), data, Column, "8");
            ExecuteLogToConsole(new ConcatConcatenate(), data, Column, "9");
            ExecuteLogToConsole(new ConcatWithListConcatenate(), data, Column, "X10");
            ExecuteLogToConsole(new JoinConcatenate(), data, Column, "X11");
            ExecuteLogToConsole(new LinqConcatenate(), data, Column, "X12");
        }

        private static void ExecuteLogToConsole(IConcatenateOperation operation, List<string> data,string Column, string Row)
        {
            decimal duration = operation.Execute(data);
            string message = string.Format(ResultFormat, operation.OperationName, duration, data.Count, data[0].Length); 

            string oldText = File.Exists(concatTestValuesFile) ?  File.ReadAllText(concatTestValuesFile) : ""; 
            File.WriteAllText(concatTestValuesFile,oldText.Replace(string.Format("{0}{1}", Column, Row), duration.ToString()));
            LogTofile(message);
            LogTofile(Environment.NewLine); 
        }
        public static Dictionary<string, string> BlockColumnNames;
        public static void StartTest(string netCoreversion, Dictionary<string, string> blockColumnNames)
        {
            BlockColumnNames = blockColumnNames;
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
            //File.AppendAllText(logPath, message); 
            Console.WriteLine(message);
        }
    }
}
