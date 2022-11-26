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
            var b = new Ułamek(-10, 2);
            var a = new Ułamek("5/4");
            // var c = new Ułamek("2/2");

            //    var d = new Ułamek(Console.ReadLine());
            //  Console.WriteLine(d.ToDouble());
            //  Console.WriteLine(l1/l2);
            //     Narzędzia.NWD(2,2);


            Console.WriteLine($"Ułamek a = ({a}) ");
            Console.WriteLine($"Ułamek b = ({b}) ");
            Console.WriteLine($"-({a}) = {-a}, jako double = {a.ToDouble()}");
            Console.WriteLine($"({a})+({b}) = {a + b}, jako double = {(a.ToDouble() + b.ToDouble())}");
            Console.WriteLine($"({a})-({b}) = {a - b}, jako double = {(a.ToDouble() - b.ToDouble())}");
            Console.WriteLine($"({a})*({b}) = {a * b}, jako double = {(a.ToDouble() * b.ToDouble())}");
            Console.WriteLine($"({a})/({b}) = {a / b}, jako double = {(a.ToDouble() / b.ToDouble())}");

        }
    }
}
