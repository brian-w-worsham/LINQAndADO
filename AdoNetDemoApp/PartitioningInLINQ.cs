using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemoApp
{
    class PartitioningInLINQ
    {
        static void Main1(string[] args)
        {
            // Take
            List<int> nums = new List<int>()
            {
                1,2,3,4,5,6,7,8,9,10
            };

            List<int> methodSyntax = nums.Take(4).ToList();

            List<int> querySyntax = (from num in nums
                                     select num).Take(4).ToList();

            foreach(var item in methodSyntax)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();

            foreach(var item in nums.Where(num => num > 3).Take(4).ToList())
            {
                Console.Write($"{item} ");
            }

            querySyntax = (from num in nums
                           where num > 3
                           select num).Take(4).ToList();
            Console.WriteLine();

            foreach (var item in querySyntax)
            {
                Console.Write($"{item} ");
            }


            Console.WriteLine();

            foreach (var item in nums.Take(5).Where(num => num % 2 == 0))
            {
                Console.Write($"{item} ");
            }


            querySyntax = (from num in nums
                           select num)
                           .Take(4)
                           .Where(num => num % 2 == 0)
                           .ToList();


            Console.WriteLine();

            //List<int> nullNums = null;

            //foreach (var item in nullNums.Take(4).ToList())
            //{
            //    Console.Write($"{item} ");
            //}

            List<Employee> employees = Employee.GetEmployees()
                .OrderByDescending(emp => emp.Salary)
                .Take(4)
                .ToList();

            foreach (var item in employees)
            {
                Console.WriteLine($"{item.Name} : {item.Salary}");
            }

            employees = (from emp in Employee.GetEmployees()
                         orderby emp.Salary descending
                         select emp)
                         .Take(4).ToList();

            Console.WriteLine("Using QuerySyntax");
            foreach (var item in employees)
            {
                Console.WriteLine($"{item.Name} : {item.Salary}");
            }

            // Skip

            Console.WriteLine("Skip method demo:");
            foreach (var item in nums.Skip(5).ToList())
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine("Using QuerySyntax");
            foreach (var item in (from num in nums
                                  select num).Skip(5).ToList())
            {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine("Where with skip demo");

            foreach (var item in nums.Where(num => num % 2 == 0).Skip(3).ToList())
            {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine("Where with skip demo (filtering after skip)");

            foreach (var item in nums.Skip(3).Where(num => num % 2 == 0).ToList())
            {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine("Applying Skip to Complex Data types:");

            employees = Employee.GetEmployees()
                         .OrderByDescending(emp => emp.Salary)
                         .Skip(1)
                         .ToList() ;

            foreach(var item in employees)
            {
                Console.WriteLine($"{item.ID}, Salary: ${item.Salary}");
            }


            Console.WriteLine("Take while and skip while:");

            foreach (var item in nums.TakeWhile(num => num % 2 != 0).ToList())
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine("TakeWhile vs Where");

            nums = new List<int>() { 1, 2, 3, 6, 7, 8, 9, 10, 4, 5 };


            foreach (var item in nums.TakeWhile(num => num < 6).ToList())
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();

            foreach (var item in nums.Where(num => num < 6).ToList())
            {
                Console.Write($"{item} ");
            }


            List<string> names = new List<string>() { "Sara", "Rahul", "John", "Pam", "Priyanka" };
            Console.WriteLine();
            foreach (var name in names.TakeWhile(name => name.Length > 3).ToList())
            {
                Console.Write($"{name} ");
            }


            Console.WriteLine();
            foreach (var name in names.TakeWhile((name, index) => name.Length > index).ToList())
            {
                Console.Write($"{name} ");
            }


            nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4 };

            Console.WriteLine();
            Console.WriteLine("SkipWhile demo:");

            foreach(var num in nums.SkipWhile(num => num < 5).ToList())
            {
                Console.WriteLine($"{num} ");
            }

            Console.WriteLine("SkipWhile demo (query syntax):");

            foreach (var num in (from num in nums
                                 select num).SkipWhile(num => num < 5).ToList())
            {
                Console.WriteLine($"{num} ");
            }

            Console.WriteLine("Where demo:");
            foreach (var num in nums.Where(num => num < 5).ToList())
            {
                Console.WriteLine($"{num} ");
            }
            Console.ReadKey();
        }
    }
}
