using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> li = new List<int> { 1, 2, 1, 3, 4, 5, 6, 7, 8, 9, 10 ,99};
            float n1 = (float)Math.Round(li.Average(),2);
            var min = li.Min();
            var max = li.Max();
            Console.WriteLine("List的平均值为{0}",n1);
            Console.WriteLine("List最小值为{0},最大值为{1}", min,max);
            Console.ReadKey();
            IEnumerable<int> result = from s in li
                                      where s <= 5
                                      select s;
            foreach (var item in result)
            {
                Console.WriteLine("{0}  ",item);
                Console.ReadKey();
            }
        }
    }
}
