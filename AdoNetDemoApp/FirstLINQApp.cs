using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemoApp
{
    class FirstLINQApp
    {
        static void Main1(string[] args)
        {
            // Data Source

            List<int> integersList = new List<int>()
            {
                1,2,3,4,5,6,7,8,9,10
            };

            // Query
            var querySyntax = from obj in integersList //Data source
                              where obj > 5 // Condition
                              select obj; // Selection

            // var querySyntax = integersList.Where(obj => obj > 5).ToList();

            // Execution
            foreach(var item in querySyntax)
            {
                Console.Write(item + " ");
            }


            var mixedSyntax = (from obj in integersList
                               where obj > 5
                               select obj).Sum();

            Console.WriteLine("Sum is:" + mixedSyntax);
            Console.ReadKey();
        }
    }
}
