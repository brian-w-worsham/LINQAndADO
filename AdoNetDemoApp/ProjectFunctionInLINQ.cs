using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemoApp
{
    class ProjectFunctionInLINQ
    {
        static void Main1(string[] args)
        {
            var ids = Employee.GetEmployees().Select(emp => emp.ID);

            foreach(var id in ids)
            {
                Console.WriteLine($"ID :  {id}");
            }


            IEnumerable<EmployeeBasicInfo> selectQuery = Employee.GetEmployees()
                .Select(emp => new EmployeeBasicInfo()
                {
                    ID = emp.ID,
                    Salary = emp.Salary
                }).ToList();

            foreach (var emp in selectQuery)
            {
                Console.WriteLine($"ID : {emp.ID} has a salary of {emp.Salary}");
            }

            List<string> names = new List<string>() { "DELL", "Technologies" };

            IEnumerable<char> chars = names.SelectMany(x => x);

            foreach (char c in chars)
            {
                Console.WriteLine(c + " ");
            }

            //IEnumerable<string> querySyntax = (from std in Student.GetStudents()
            //                                   from program in std.Programming
            //                                   select program).Distinct().ToList() ;

            //List<string> methodSyntax = Student.GetStudents()
            //    .SelectMany(std => std.Programming)
            //    .Distinct()
            //    .ToList();

            //foreach (string program in methodSyntax)
            //{
            //    Console.WriteLine(program);
            //}

            Console.ReadKey();
        }
    }

    class EmployeeBasicInfo
    {
        public int ID { get; set; }

        public int Salary { get; set; }
    }
}
