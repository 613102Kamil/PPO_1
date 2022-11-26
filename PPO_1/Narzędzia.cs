using System;
using System.Collections.Generic;
using System.Text;

namespace PPO_1
{
    internal class Narzędzia
    {
        public static int NWD(int n, int m)
        {
            int a = n;
            int b = m;
            if (b != 0)
                return NWD(b, a % b);

            return a;


        }
    }
}
