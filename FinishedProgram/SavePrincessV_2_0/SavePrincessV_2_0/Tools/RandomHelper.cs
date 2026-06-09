using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavePrincessV_2_0.Tools
{
    public static class RandomHelper
    {
        public static Random r = new Random();

        public static int Next(int min, int max)
        {
            return r.Next(min, max);
        }
    }
}
