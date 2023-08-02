using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemoApp
{
    class AggregateFunctionInLINQ
    {
        static void Main1(string[] args)
        {
            int[] nums = new int[] { 10, 20, 45, 223, 34, 67, 123};

            int total = nums.Sum();

            int qsTotal = (from num in nums
                           select num).Sum();

            Console.WriteLine("Sum is:" + total);

            total = nums.Where(num => num % 2 != 0).Sum();

            total = (from num in nums
                     where num % 2 != 0
                     select num).Sum();

            Console.WriteLine("Sum of ODD numbers is:" + total);


            total = nums.Sum(num =>
            {
                if (num > 100)
                {
                    return num;
                }
                else
                {
                    return 0;
                }
            });

            Console.WriteLine("Sum of numbers > 100 :" + total);

            var totalSalary = Employee.GetEmployees().Sum(emp => emp.Salary);
            Console.WriteLine("Sum of salaries is: " + totalSalary);

            totalSalary = Employee.GetEmployees()
                .Where(emp => emp.Department == "IT")
                .Sum(emp => emp.Salary);
            Console.WriteLine("Sum of IT salaries is: " + totalSalary);


            Console.WriteLine("-----------------");

            Console.WriteLine("Maximum number is:" +  nums.Max());

            Console.WriteLine("Minimum number is:" + nums.Min());


            Console.WriteLine("Maximum number greater than 50 is:" + nums.Where(num => num > 50).Max());

            Console.WriteLine("Maximum number greater than 50 is:" + nums.Max(num =>
            {
                if (num > 50)
                {
                    return num;
                }
                else
                {
                    return 0;
                }
            }));

            Console.WriteLine("Maximum salary in all departments" + Employee.GetEmployees().Max(emp => emp.Salary));
            Console.WriteLine("Minimum salary in all departments" + Employee.GetEmployees().Min(emp => emp.Salary));

            Console.WriteLine("Maximum salary in IT departments" + Employee.GetEmployees().Where(emp => emp.Department == "IT")
                .Max(emp => emp.Salary));

            Console.WriteLine("--------------");

            Console.WriteLine("Average of the numbers is " + nums.Average());
            Console.WriteLine("Average of the numbers > 100 is " + nums.Where(num => num > 100).Average());

            Console.WriteLine("Average salary of all departments:" + Employee.GetEmployees().Average(e => e.Salary));

            Console.WriteLine("Average salary of IT departments:" + Employee.GetEmployees()
                .Where(e => e.Department == "IT")
                .Average(e => e.Salary));


            Console.WriteLine("----------------");

            Console.WriteLine("Total number of nums: " + nums.Count());

            Console.WriteLine("Total number of nums < 100" + nums.Where(num => num < 100).Count());

            Console.WriteLine("Total NUmber of employees: " + Employee.GetEmployees().Count());

            Console.WriteLine("Total NUmber of employees in IT: " + Employee.GetEmployees().Where(e => e.Department == "IT").Count());

            Console.WriteLine("Total NUmber of employees in IT whose salary is > 25000: " + Employee.GetEmployees()
                .Where(e => e.Department == "IT" && e.Salary > 25000)
                .Count());

            Console.WriteLine("----------------");

            string[] skills = { "C#.Net", "MVC", "WF", "SQL", "ASP.NET", "LINQ" };

            string result = string.Empty;

            foreach (string skill in skills)
            {
                result += skill + ",";
            }

            int lastIndex = result.LastIndexOf(",");

            result = result.Remove(lastIndex);

            Console.WriteLine(result);

            Console.WriteLine(skills.Aggregate((s1, s2) => s1 + "," + s2));

            Console.WriteLine(nums.Aggregate((n1, n2) => n1 * n2));

            Console.ReadKey();
        }
    }

    
}
