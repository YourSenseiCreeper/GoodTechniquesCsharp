using CsvHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CodeTimeConsumption
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //ViewHelper.AskForDoubleOptimised("write optimised");
            //TestStdDev();
            ViewHelperTimeImprovement();
            //DollarFormattingTest();
            //ViewHelperTest();
            Console.ReadLine();
        }

        public static void TestStdDev()
        {
            //List<int> integers = new List<int> { 3, 4, 5, 6, 7 };
            List<double> doubles = new List<double> { 3.0, 4.0, 5.0, 6.0, 7.0 };
            double doubleStdDev = StatisticsHelper.StdDev(doubles);
            Console.WriteLine(doubleStdDev);
        }

        private static void StaticVSNonStaticAccessTest()
        {

        }

        /// <summary>
        /// 1: Using While ViewHelper.AskForDoubleWhile <br/>
        /// 2: Do-While loop AskForDouble <br/>
        /// 3: No clear arg: AskForDoubleNoClearArg <br/>
        /// 4: AskForDoubleNoClearArgBreakLoop ->
        /// 5: AskForDoubleNoClearArgBreakLoopWriteOptimised
        /// </summary>
        private static void ViewHelperTimeImprovement()
        {
            Dictionary<string, List<double>> triesData = new Dictionary<string, List<double>>
            {
                { "UsingWhile", new List<double>() },
                { "UsingDoWhile", new List<double>() },
                { "ViewHelper as an object", new List<double>() },
                { "BreakLoop", new List<double>() },
                { "tryparse", new List<double>() },
                { "WriteFormatting", new List<double>() }
            };
            List<ViewHelperData> viewHelperData = new List<ViewHelperData>();
            Stopwatch watch = new Stopwatch();
            ViewHelperData vhdata;
            var vhconst = new ViewHelperConstructor();
            for (int i = 0; i < 2500; i++)
            {
                //Mean: 0,5192 Median: 0,37765
                vhdata = new ViewHelperData();
                watch.Start();
                ViewHelper.AskForDoubleWhile("while");
                watch.Stop();
                triesData["UsingWhile"].Add(watch.Elapsed.TotalMilliseconds);
                vhdata.UsingWhile = watch.Elapsed.TotalMilliseconds;
                watch.Reset();

                //Mean: 0,4811 Median: 0,3746
                watch.Start();
                ViewHelper.AskForDouble("default");
                watch.Stop();
                triesData["UsingDoWhile"].Add(watch.Elapsed.TotalMilliseconds);
                vhdata.UsingDoWhile = watch.Elapsed.TotalMilliseconds;
                watch.Reset();

                //Mean: 0,4813 Median: 0,37515
                watch.Start();
                vhconst.AskForDouble("vhconst hello");
                watch.Stop();
                triesData["ViewHelper as an object"].Add(watch.Elapsed.TotalMilliseconds);
                vhdata.ViewHelperAsAnObject = watch.Elapsed.TotalMilliseconds;
                watch.Reset();

                //Mean: 0,4360 Median: 0,3569
                watch.Start();
                ViewHelper.AskForDoubleBreakLoop("break loop!");
                watch.Stop();
                triesData["BreakLoop"].Add(watch.Elapsed.TotalMilliseconds);
                vhdata.BreakLoop = watch.Elapsed.TotalMilliseconds;
                watch.Reset();

                // What happened?
                //Mean: 0,1703 Median: 0,0531
                watch.Start();
                ViewHelper.AskForDoubleTryParse("tryparse");
                watch.Stop();
                triesData["tryparse"].Add(watch.Elapsed.TotalMilliseconds);
                vhdata.TryParse = watch.Elapsed.TotalMilliseconds;
                watch.Reset();

                //Mean: 0,4446 Median: 0,3784
                watch.Start();
                ViewHelper.AskForDoubleOptimised("write optimised");
                watch.Stop();
                triesData["WriteFormatting"].Add(watch.Elapsed.TotalMilliseconds);
                vhdata.WriteOptimised = watch.Elapsed.TotalMilliseconds;
                watch.Reset();

                viewHelperData.Add(vhdata);
            }
            Console.WriteLine();
            string outputFormat = "{0,-20} Min: {1,-9} Mean: {2,-9} Median: {3,-9} StDev: {4,-9} Max: {5,-9}";
            foreach (var element in triesData)
            {
                Console.WriteLine(outputFormat, element.Key, element.Value.Min(), element.Value.Average(),
                    StatisticsHelper.GetMedian(element.Value), StatisticsHelper.StdDev(element.Value), element.Value.Max());
            }
            Console.WriteLine("Allocated memory: {0}kb", GC.GetTotalAllocatedBytes(true)/1024);
            string filename = $"viewHelperImprovement_{DateTime.Now.Millisecond}.csv";
            using (var writer = new StreamWriter(filename))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(viewHelperData);
            }
            Console.WriteLine("Data saved to: " + filename);
        }

        /// <summary>
        /// This tests which formatting is faster, string interpolation or
        /// native console.writeline formatting.
        /// Native is faster of course
        /// </summary>
        private static void DollarFormattingTest()
        {
            double oneDollar, manyDollar, oneFormat, manyFormat;
            int testDollar = 2137;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine($"OneDollar {testDollar}");
            }
            watch.Stop();
            oneDollar = watch.Elapsed.TotalMilliseconds;
            watch.Reset();

            watch.Start();
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine($"ManyDollar {testDollar}, {testDollar}, {testDollar}, {testDollar}, {testDollar}");
            }
            watch.Stop();
            manyDollar = watch.Elapsed.TotalMilliseconds;
            watch.Reset();

            watch.Start();
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("OneFormat {0}", testDollar);
            }
            watch.Stop();
            oneFormat = watch.Elapsed.TotalMilliseconds;
            watch.Reset();

            watch.Start();
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("ManyFormat {0}, {1}, {2}, {3}, {4}", testDollar, testDollar, testDollar, testDollar, testDollar);
            }
            watch.Stop();
            manyFormat = watch.Elapsed.TotalMilliseconds;

            Console.WriteLine("OneDollar: {0}", oneDollar);
            Console.WriteLine("ManyDollar: {0}", manyDollar);
            Console.WriteLine("OneFormat: {0}", oneFormat);
            Console.WriteLine("ManyFormat: {0}", manyFormat);
        }


        /// <summary>
        /// This tests which is faster ViewHelper static method using do-while loop
        /// or in place code
        /// Edit: Need to compare all results with outside method and the same code inside
        /// </summary>
        private static void ViewHelperTest()
        {
            List<double> viewHelper = new List<double>();
            List<double> normal = new List<double>();
            List<double> outsideMethod = new List<double>();

            Stopwatch watch = new Stopwatch();
            for (int i = 0; i < 400; i++)
            {
                watch.Start();
                Console.WriteLine($"AskForInt {ViewHelper.AskForInt("Podaj liczbe")}");
                watch.Stop();

                Console.WriteLine($"Czas: {watch.Elapsed.TotalMilliseconds}");
                Console.WriteLine();
                if (i != 0)
                {
                    viewHelper.Add(watch.Elapsed.TotalMilliseconds);
                }
                watch.Reset();

                watch.Start();
                int result = 0;
                bool clear = false;
                if (clear) Console.Clear();
                Console.WriteLine("Podaj liczbe nonAsk");
                string answer = "13";//Console.ReadLine();
                try { result = Convert.ToInt32(answer); }
                catch (FormatException) { ViewHelper.WriteAndWait($"{answer} nie jest liczbą!"); }
                Console.WriteLine($"NonAsk: {result}");
                watch.Stop();

                Console.WriteLine($"Czas: {watch.Elapsed.TotalMilliseconds}");
                Console.WriteLine();
                normal.Add(watch.Elapsed.TotalMilliseconds);
                watch.Reset();

                watch.Start();
                ViewHelperInplaceMethod();
                watch.Stop();

                Console.WriteLine($"Czas: {watch.Elapsed.TotalMilliseconds}");
                Console.WriteLine();
                outsideMethod.Add(watch.Elapsed.TotalMilliseconds);

            }
            Console.WriteLine($"ViewHelper: Min: {viewHelper.Min()}, Mean: {viewHelper.Average()}, Max: {viewHelper.Max()}");
            Console.WriteLine($"Normal: Min: {normal.Min()}, Mean: {normal.Average()}, Max: {normal.Max()}");
            Console.WriteLine($"OutsideMethod: Min: {outsideMethod.Min()}, Mean: {outsideMethod.Average()}, Max: {outsideMethod.Max()}");
        }

        private static void ViewHelperInplaceMethod()
        {
            int result = 0;
            bool clear = false;
            if (clear) Console.Clear();
            Console.WriteLine("Podaj liczbe outsideNoLoop");
            string answer = "13";//Console.ReadLine();
            try { result = Convert.ToInt32(answer); }
            catch (FormatException) { ViewHelper.WriteAndWait($"{answer} nie jest liczbą!"); }
            Console.WriteLine($"outsideNoLoop: {result}");
        }
    }

    public class ViewHelperData
    {
        public double UsingWhile { get; set; }
        public double UsingDoWhile { get; set; }
        public double ViewHelperAsAnObject { get; set; }
        public double BreakLoop { get; set; }
        public double TryParse { get; set; }
        public double WriteOptimised { get; set; }
    }
}
