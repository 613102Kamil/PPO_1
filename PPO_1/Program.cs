using System;

namespace PPO_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int l1 = 11;
            int l2 = 3;
            Console.WriteLine("Hello World!");
          //  var a = new Ułamek(5, 4);
          //  var b = new Ułamek(1, 2);
          //  var c = new Ułamek("2/2");
 
               var d = new Ułamek(Console.ReadLine());
             Console.WriteLine(d.ToDouble());
          //  Console.WriteLine(l1/l2);
            //     Narzędzia.NWD(2,2);


            /*
            Console.WriteLine(-a);   // output: -5 / 4
            Console.WriteLine(a + b);  // output: 14 / 8
            Console.WriteLine(a - b);  // output: 6 / 8
            Console.WriteLine(a * b);  // output: 5 / 8
            Console.WriteLine(a / b);  // output: 10 / 4
            */
            // testowa zmiana
        }
    }
}
