using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemoApp
{
    class ElementOperatorsInLINQ
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int ms = nums.ElementAt(1);

            int qs = (from num in nums
                      select num).ElementAt(1);

            Console.WriteLine(ms);

            //qs = (from num in nums
            //      select num).ElementAt(100);

            //Console.WriteLine(ms);


            //nums = new List<int>();

            //Console.WriteLine(nums.ElementAt(1));

            // ElementAtOrDefault

            Console.WriteLine("-----------");
            nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine(nums.ElementAtOrDefault(1));
            Console.WriteLine((from num in nums
                               select num).ElementAtOrDefault(1));


            Console.WriteLine($"Value at index position 100: {nums.ElementAtOrDefault(100)}" );

            nums = new List<int>();
            Console.WriteLine($"Value at index position 100 in Empty List: {nums.ElementAtOrDefault(100)}");

            Console.WriteLine($"Value at index position NEGATIVE 100 in Empty List: {nums.ElementAtOrDefault(-100)}");

            //nums = null;
            //Console.WriteLine($"Value at index position 100 in null List: {nums.ElementAtOrDefault(100)}");


            Console.WriteLine(Student.GetStudents().ElementAt(1).Name);
            Console.WriteLine(Student.GetStudents().ElementAtOrDefault(1).Name);

            // Console.WriteLine(Student.GetStudents().ElementAt(1000).Name);
            Console.WriteLine(Student.GetStudents().ElementAtOrDefault(1000)); // returns NULL


            Console.WriteLine("-----------------------");
            nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            ms = nums.First();

            qs = (from num in nums
                  select num).First();

            Console.WriteLine(ms);

            Console.WriteLine(nums.First(num => num % 2 == 0));

            nums = new List<int>();

            //  Console.WriteLine(nums.First());

            // Console.WriteLine(nums.First(num => num > 10000));
            Console.WriteLine("-----------------------");

            nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine(nums.FirstOrDefault());
            Console.WriteLine((from num in nums select num).FirstOrDefault());

            Console.WriteLine(nums.FirstOrDefault(num => num > 5));

            Console.WriteLine(nums.FirstOrDefault(num => num > 500));

            nums = new List<int>();
            Console.WriteLine(nums.FirstOrDefault());

            Console.WriteLine("-----------------------");

            Console.WriteLine(Student.GetStudents().First().Name);

            Console.WriteLine(Student.GetStudents().First(stu => stu.Gender == "Male").Name);

            // Console.WriteLine(Student.GetStudents().FirstOrDefault(stu => stu.Branch == "MEC").Name);

            Console.ReadKey();
        }
    }
}
