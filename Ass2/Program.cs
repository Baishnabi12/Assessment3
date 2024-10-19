namespace Ass2
{
    using System;

  
        public class Source
        {
            public int Add(int a, int b, int c)
            {
                return a + b + c;
            }
            public double Add(double a, double b, double c)
            {
                return a + b + c;
            }
        }
        public class Program
        {
            static void Main(string[] args)
            {
                Source source = new Source();
                Console.WriteLine(source.Add(1, 2, 3));
                Console.WriteLine(source.Add(1.2, 2.3, 3.4));
            }
        }

    }


