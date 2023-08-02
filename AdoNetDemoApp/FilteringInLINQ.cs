using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemoApp
{
    class FilteringInLINQ
    {
        static void Main1(string[] args)
        {
            List<object> dataSource = new List<object>()
            {
                "Tom", "Mary", "Jane", 12, 20, "James", "Bond", 67, 192, 34
            };

            List<int> intData = dataSource.OfType<int>().Where(num => num > 30).ToList();

            foreach(int number in intData)
            {
                Console.Write(number + " ");
            }

            Console.ReadKey();
        }
    }
}
