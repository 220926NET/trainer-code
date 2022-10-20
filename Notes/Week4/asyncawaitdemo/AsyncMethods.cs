using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asyncawaitdemo
{
    public class AsyncMethods
    {
        public async Task<string> Am1()
        {
            await Task.Delay(2000); // this is a built-in way to simulate a call that tales the noted amount of milliseconds.
            return "This ";
        }

        public async Task<string> Am2()
        {
            await Task.Delay(5000);
            return "is ";
        }

        public async Task<string> Am3()
        {
            await Task.Delay(2000);
            return "async ";
        }

        public async Task<string> Am4()
        {
            await Task.Delay(2000);
            return "await ";
        }


        public async Task<string> Am5()
        {
            await Task.Delay(2000);
            return "programming.";
        }












    }
}