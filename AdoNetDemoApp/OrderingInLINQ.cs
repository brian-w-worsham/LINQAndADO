using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemoApp
{
    class OrderingInLINQ
    {
        static void Main1(string[] args)
        {
            // Order By
            List<int> nums = new List<int>()
            {
                10,25,1,23,56,12,45,11, 50
            };

            Console.WriteLine("Before ordering:");

            foreach (var item in nums)
            {
                Console.Write(item + " ");
            }

            var methodSyntax = nums.OrderBy(num => num);

            var querySyntax = (from num in nums
                               orderby num
                               select num).ToList();

            Console.WriteLine();
            Console.WriteLine("After ordering:");

            foreach (var item in querySyntax)
            {
                Console.Write(item + " ");
            }


            Console.WriteLine();

            List<string> strings = new List<string>()
            {
                "Jane", "John", "Bob", "Alice", "Barbie"
            };

            var querySyntaxStrings = (from name in strings
                           orderby name ascending // optional ascending keyword
                           select name).ToList();

            var methodSyntaxStrings = strings.OrderBy(name => name);

            Console.WriteLine();
            Console.WriteLine("After ordering:");

            foreach (var item in querySyntaxStrings)
            {
                Console.Write(item + " ");
            }


            Console.WriteLine();

            var methodSyntaxStudents = Student.GetStudents()
                .OrderBy(x => x.Name).ToList();

            Console.WriteLine("Before sorting the students by name:");

            foreach(var student in Student.GetStudents())
            {
                Console.Write(student.Name + " ");
            }

            Console.WriteLine();

            Console.WriteLine("After sorting the students by name:");

            foreach(var student in methodSyntaxStudents)
            {
                Console.Write(student.Name + " ");
            }

            Console.WriteLine();

            var methodSyntaxForEmployees = Employee.GetEmployees()
                .Where(emp => emp.Department == "IT")
                .OrderBy(emp => emp.Name).ToList();


            var querySyntaxForEmployees = (from emp in Employee.GetEmployees()
                                           where emp.Department == "IT"
                                           orderby emp.Name
                                           select emp).ToList();


            foreach (var item in querySyntaxForEmployees)
            {
                Console.WriteLine(item.Name + " " + item.Department);
            }

            Console.WriteLine("Custom ordering:");

            CaseInsensitiveComparer caseInsensitiveComparer = new CaseInsensitiveComparer();

            string[] Alphabets = { "a", "b", "c", "A", "B", "C" };

            var msForAlphabets = Alphabets.OrderBy(alphabet => alphabet).ToList();

            var msForAlphabetsUsingCustomComparer = Alphabets.OrderBy(alphabet => alphabet, caseInsensitiveComparer);


            Console.WriteLine("Default comparer:");
            foreach(var item in msForAlphabets)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Custom Comparer:");

            foreach (var item in msForAlphabetsUsingCustomComparer)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("-----------");


            methodSyntax = nums.OrderByDescending(num => num);

            foreach(var item in methodSyntax)
            {
                Console.Write(item + " ");
            }


            methodSyntaxStrings = strings.OrderByDescending(name => name);

            Console.WriteLine();
            Console.WriteLine("After ordering:");

            foreach (var item in methodSyntaxStrings)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("-----------");

            var msThenByEmployees = Employee.GetEmployees()
                .OrderBy(emp => emp.Name) // or OrderByDescending
                .ThenBy(emp => emp.Department).ToList();

            foreach(var item in msThenByEmployees)
            {
                Console.WriteLine(item.Name +  " " + item.Department);
            }

            Console.WriteLine("-----------");

            msThenByEmployees = Employee.GetEmployees()
                .OrderBy(emp => emp.Name) // or OrderByDescending
                .OrderBy(emp => emp.Department).ToList();

            foreach (var item in msThenByEmployees)
            {
                Console.WriteLine(item.Name + " " + item.Department);
            }

            Console.WriteLine("-----------");

            var querySyntaxForThenBy = (from emp in Employee.GetEmployees()
                                        orderby emp.Name ascending, emp.Department descending
                                        select emp).ToList();

            foreach (var item in querySyntaxForThenBy)
            {
                Console.WriteLine(item.Name + " " + item.Department);
            }

            Console.WriteLine("-----------");
            msThenByEmployees = Employee.GetEmployees()
                .OrderBy(emp => emp.Name) // or OrderByDescending
                .ThenByDescending(emp => emp.Department).ToList();

            foreach (var item in msThenByEmployees)
            {
                Console.WriteLine(item.Name + " " + item.Department);
            }

            Console.WriteLine("-----------");
            Console.WriteLine("Before reversing:");
            

            foreach (var item in nums)
            {
                Console.Write(item + " ");
            }

            nums.Reverse();

            Console.WriteLine();

            Console.WriteLine("After reversing:");
            foreach (var item in nums)
            {
                Console.Write(item + " ");
            }

            IEnumerable<int> numsReversed =  (from num in nums
             select num).Reverse();

            Console.WriteLine("After reversing:");
            foreach (var item in numsReversed)
            {
                Console.Write(item + " ");
            }

            int[] numsArr = new int[] { 1,2,3,4,5,6,7,8,9 };

            IEnumerable<int> reversedNums =  numsArr.Reverse();

            Console.WriteLine();

            Console.WriteLine("Before reversing:");
            foreach (var item in numsArr)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            Console.WriteLine("After reversing:");
            foreach (var item in reversedNums)
            {
                Console.Write(item + " ");
            }

            List<string> strList = new List<string>() { "A", "B", "C", "D" };

            Console.WriteLine();

            foreach (var item in strList)
            {
                Console.WriteLine(item + " " );
            }

            IEnumerable<string> reversedStrings = strList.AsEnumerable().Reverse();

            reversedStrings = strList.AsQueryable().Reverse();

            // strList.Reverse();

            foreach (var item in strList)
            {
                Console.WriteLine(item + " ");
            }

            Console.ReadKey();
        }
    }

    class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, true);
        }
    }
}
