using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Async_Await_Example_With_Different_Test_Case_AND_Comparison_With_Sync_Flow
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Clean clean = new Clean();
            Cook cook = new Cook();
            Wash wash = new Wash();

            Console.WriteLine("============== SYNC FLOW ==============");

            Stopwatch syncWatch = Stopwatch.StartNew();

            // Sync Flow (sequential execution)
            wash.Start_Washing_Cloth().Wait();
            wash.End_Washing_Cloth().Wait();

            Console.WriteLine("Time : " + DateTime.Now.ToString("hh:mm:ss.fff") + " \t " + clean.Started_Cleaning().Result);
            Console.WriteLine("Time : " + DateTime.Now.ToString("hh:mm:ss.fff") + " \t " + clean.End_Cleaning().Result);

            Console.WriteLine("Time : " + DateTime.Now.ToString("hh:mm:ss.fff") + " \t " + cook.Start_Cooking().Result);
            Console.WriteLine("Time : " + DateTime.Now.ToString("hh:mm:ss.fff") + " \t " + cook.Getting_Cook().Result);
            Console.WriteLine("Time : " + DateTime.Now.ToString("hh:mm:ss.fff") + " \t " + cook.End_Cook().Result);

            syncWatch.Stop();
            Console.WriteLine("SYNC TASK ENDED in " + syncWatch.ElapsedMilliseconds + " ms");

            Console.WriteLine("\n============== ASYNC FLOW ==============");

            Stopwatch asyncWatch = Stopwatch.StartNew();

            // Async Flow (parallel execution)
            Task washStart = wash.Start_Washing_Cloth();
            Task<string> cleanStart = clean.Started_Cleaning();
            Task<string> cleanEnd = clean.End_Cleaning();
            Task<string> cookStart = cook.Start_Cooking();
            Task<string> cookMid = cook.Getting_Cook();
            Task<string> cookEnd = cook.End_Cook();
            Task washEnd = wash.End_Washing_Cloth();

            await Task.WhenAll(washStart, cleanStart, cleanEnd, cookStart, cookMid, cookEnd, washEnd);

            Console.WriteLine("Time : " + DateTime.Now.ToString("hh:mm:ss.fff") + " \t " + cleanStart.Result);
            Console.WriteLine("Time : " + DateTime.Now.ToString("hh:mm:ss.fff") + " \t " + cleanEnd.Result);
            Console.WriteLine("Time : " + DateTime.Now.ToString("hh:mm:ss.fff") + " \t " + cookStart.Result);
            Console.WriteLine("Time : " + DateTime.Now.ToString("hh:mm:ss.fff") + " \t " + cookMid.Result);
            Console.WriteLine("Time : " + DateTime.Now.ToString("hh:mm:ss.fff") + " \t " + cookEnd.Result);

            asyncWatch.Stop();
            Console.WriteLine("ASYNC TASK ENDED in " + asyncWatch.ElapsedMilliseconds + " ms");
        }
    }
}
