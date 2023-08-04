using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemoApp
{
    class ElementOperatorsInLINQ
    {
        static void Main1(string[] args)
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


            Console.WriteLine($"Value at index position 100: {nums.ElementAtOrDefault(100)}");

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

            Console.WriteLine("-----------------------");

            nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int lastMS = nums.Last();

            int lastQS = (from num in nums
                          select num).Last();

            Console.WriteLine($"Last number in the list is: {lastMS}");

            Console.WriteLine($"Last number that is divisible by 3 is: {nums.Last(num => num % 3 == 0)}");

            // nums = new List<int>();

            // nums.Last();

            // nums.Last(num => num > 100);

            Console.WriteLine($"LastOrDefault: {nums.LastOrDefault()}");

            Console.WriteLine($"LastOrDefault: {nums.LastOrDefault(num => num < 6)}");

            Console.WriteLine($"LastOrDefault with empty data source: {(new List<int>()).LastOrDefault()} ");

            Console.WriteLine($"LastOrDefault with empty data source: {nums.LastOrDefault(num => num > 10)} ");

            Employee employee = Employee.GetEmployees().Last();

            Console.WriteLine($"Name of the last employee is: {employee.Name}");

            employee = Employee.GetEmployees().Last(emp => emp.Department == "IT");

            Console.WriteLine($"Name of the last employee in IT is: {employee.Name}");

            employee = Employee.GetEmployees().LastOrDefault(emp => emp.Department == "HR");

            Console.WriteLine($"Name of the last employee in IT is: {employee}");

            Console.WriteLine("-----------------------");

            nums = new List<int>() { 100 };

            int singleMS = nums.Single();

            int singleQS = (from num in nums
                            select num).Single();

            Console.WriteLine($"Single element in the list is: {singleMS}");

            // Console.WriteLine($"Single element when data source is empty: {(new List<int>()).Single()}");

            nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine($"DOes the list of nums contain the number 10: {nums.Single(num => num == 10)}");

            // nums.Single(num => num > 1);

            // nums.Single(num => num > 100);

            Console.WriteLine($"SingleOrDefault: {nums.SingleOrDefault(num => num < 1)}");

            Console.WriteLine($"SingleOrDefault on empty data: {(new List<int>()).SingleOrDefault()}");

            Console.WriteLine("-----------------------");

            nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            IEnumerable<int> defaultMS = nums.DefaultIfEmpty();

            IEnumerable<int> defaultQS = (from num in nums
                                          select num).DefaultIfEmpty();

            foreach (int num in defaultMS)
            {
                Console.Write($"{num} ");
            }

            defaultMS = (new List<int>()).DefaultIfEmpty();

            Console.WriteLine();
            Console.WriteLine("DefaultIfEmpty on empty sequence");
            foreach (int num in defaultMS)
            {
                Console.Write($"{num} ");
            }


            defaultMS = (new List<int>()).DefaultIfEmpty(100);
            Console.WriteLine();
            Console.WriteLine("DefaultIfEmpty on empty sequence");
            foreach (int num in defaultMS)
            {
                Console.Write($"{num} ");
            }


            defaultMS = nums.DefaultIfEmpty(100);
            Console.WriteLine();
            Console.WriteLine("DefaultIfEmpty on empty sequence");
            foreach (int num in defaultMS)
            {
                Console.Write($"{num} ");
            }

            Console.WriteLine();


            Employee defaultEmployee = new Employee()
            {
                ID = 201,
                Department = "UNASSIGNED",
                Name = "NAME",
                Salary = 0
            };

            IEnumerable<Employee> employeesDefault = Employee.GetEmployees().DefaultIfEmpty(defaultEmployee);

            foreach (Employee emp in employeesDefault)
            {
                Console.WriteLine($"{emp.Name}");
            }


            employeesDefault = (new List<Employee>()).DefaultIfEmpty(defaultEmployee);

            foreach (Employee emp in employeesDefault)
            {
                Console.WriteLine($"{emp.Name}");
            }

            Console.ReadKey();
        }
    }
}