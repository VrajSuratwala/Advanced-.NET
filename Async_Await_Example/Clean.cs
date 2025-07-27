using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_Await_Example_With_Different_Test_Case_AND_Comparison_With_Sync_Flow
{
    internal class Clean
    {
        public async Task<string> Started_Cleaning()
        {
            await Task.Delay(1500); // takes 1.5 seconds
            return "Started Room Cleaning";
        }

        public async Task<string> End_Cleaning()
        {
            await Task.Delay(1000); // takes 1 second
            return "End Room Cleaning";
        }
    }
}
