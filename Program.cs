using System;

namespace _10
{
    class Program
    {
        private delegate T Operation<T>(dynamic a, dynamic b);
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number:");
            var ok = Int32.TryParse(Console.ReadLine(), out var a);
            if (!ok)
            {
                Console.WriteLine("Bad input");
                return;
            }

            Console.WriteLine("Enter number:");
            ok = Int32.TryParse(Console.ReadLine(), out var b);
            if (!ok)
            {
                Console.WriteLine("Bad input");
                return;
            }

            Console.WriteLine("Choose operation:");
            Console.WriteLine(@"
1. +
2. -
3. *
4. /");
            ok = Int32.TryParse(Console.ReadLine(), out var op);
            if (!ok)
            {
                Console.WriteLine("Bad input");
                return;
            }

            Operation<double> calculate = op switch {
                1 => Sum<double>,
                2 => Sub<double>,
                3 => Multiply<double>,
                4 => Divide<double>,
                _ => null
            };

            if (calculate == null)
            {
                Console.WriteLine("Bad input");
                return;
            }

            double result;
            try
            {
                result = calculate(a, b);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Do not divide on zero");
                return;
            }
            
            Console.WriteLine($"Result is {result}");
        }

        static T Sum<T>(dynamic a, dynamic b) => a + b; 
        static T Sub<T>(dynamic a, dynamic b) => a - b;
        static T Divide<T>(dynamic a, dynamic b) => a / b;
        static T Multiply<T>(dynamic a, dynamic b) => a * b;
    }
}
