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
            if (n % m != 0) { return NWD(m, n % m); }

 
            while (a != b)
                if (a > b)
                    a -= b; //lub a = a - b;
                else
                    b -= a; //lub b = b-a
            return a; // lub b - obie zmienne przechowują wynik NWD(a,b)

           
        }
    }
}
