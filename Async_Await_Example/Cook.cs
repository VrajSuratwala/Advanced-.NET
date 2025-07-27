using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_Await_Example_With_Different_Test_Case_AND_Comparison_With_Sync_Flow
{
    internal class Cook
    {
        public async Task<string> Start_Cooking()
        {
            await Task.Delay(1000);
            return "The Bacon is going to be Fry!";
        }

        public async Task<string> Getting_Cook()
        {
            await Task.Delay(2000);
            return "The Bacon is Getting Fried!";
        }

        public async Task<string> End_Cook()
        {
            await Task.Delay(1000);
            return "The Bacon Fried!";
        }
    }
}
