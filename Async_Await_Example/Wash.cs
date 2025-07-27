using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_Await_Example_With_Different_Test_Case_AND_Comparison_With_Sync_Flow
{
    internal class Wash
    {
        public async Task Start_Washing_Cloth()
        {
            Console.WriteLine("Time : " + DateTime.Now.ToString("hh:mm:ss.fff") + " \t The Clothes are getting started to Washed!");
            await Task.Delay(3000); // simulate 3 seconds of washing
        }

        public async Task End_Washing_Cloth()
        {
            await Task.Delay(2000); // simulate drying
            Console.WriteLine("Time : " + DateTime.Now.ToString("hh:mm:ss.fff") + " \t The Clothes are Washed!");
        }
    }
}
