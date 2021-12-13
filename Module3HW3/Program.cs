using System;

namespace Module3HW3
{
    public class Program
    {
        public void Show(bool result)
        {
            Console.WriteLine($"Result is: {result}");
        }

        public static void Main()
        {
            var program = new Program();

            var class1 = new Class1();
            class1.ShowHandler = program.Show;

            var class2 = new Class2();

            Func<double, double, double> powHandler = class1.Pow;
            Predicate<double> predicate = class2.Calc(powHandler, 4.0, 5.0);

            class1.ShowHandler?.Invoke(predicate.Invoke(3));
        }

        public class Class1
        {
            public Action<bool> ShowHandler { get; set; }

            public double Pow(double x, double y)
            {
                return x * y;
            }
        }

        public class Class2
        {
            public static double? CalcResult { get; private set; }
            public Predicate<double> Calc(Func<double, double, double> func, double x, double y)
            {
                CalcResult = func?.Invoke(x, y);
                Predicate<double> resultHandler = Result;

                return resultHandler;
            }

            public bool Result(double d)
            {
                return CalcResult % d == 0.0;
            }
        }
    }
}
