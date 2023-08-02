using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemoApp
{
    class ConversionMethodsInLINQ
    {
        static void Main1(string[] args)
        {
            // ToList
            int[] nums = { 1,2,3,4,5,6,7,8,9,10};

            // Convert Array to a List using ToList()

            List<int> numsList = nums.ToList();

            foreach (var num in numsList)
            {
                Console.Write($"{num} ");
            }

            Employee[] EmployeesArray = new Employee[]
            {
                new Employee() {ID = 1, Name = "Pranaya", Department = "IT" },
                new Employee() {ID = 2, Name = "Priyanka", Department = "HR" },
                new Employee() {ID = 3, Name = "Preety", Department = "HR" },
                new Employee() {ID = 4, Name = "Sambit", Department = "IT" },
                new Employee() {ID = 5, Name = "Sudhanshu", Department = "IT"}
            };

            List<Employee> employees = EmployeesArray.ToList();

            Console.WriteLine();

            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.ID}, Name: {emp.Name}, Department: {emp.Department}");
            }

            int[] numbersArray = numsList.ToArray();

            foreach(var num in numbersArray)
            {
                Console.Write($"{num} ");
            }

            Console.WriteLine();

            Employee[] empArray = Employee.GetEmployees().ToArray();


            foreach (var emp in empArray)
            {
                Console.WriteLine($"ID: {emp.ID}, Name: {emp.Name}, Department: {emp.Department}");
            }


            // ToDictionary

            List<Product> listProducts = new List<Product>
            {
                new Product { ID= 1001, Name = "Mobile", Price = 800 },
                new Product { ID= 1002, Name = "Laptop", Price = 900 },
                new Product { ID= 1003, Name = "Desktop", Price = 800 },
                // new Product { ID= 1003, Name = "Desktop", Price = 800 }
            };

            Dictionary<int, Product> productsDict = listProducts.ToDictionary(x => x.ID);

            Console.WriteLine();
            Console.WriteLine();
            foreach (KeyValuePair<int, Product> keyValue in productsDict)
            {
                Console.WriteLine($"Name: {keyValue.Value.Name}, ID: {keyValue.Key}, Price: {keyValue.Value.Price}");
            }

            Console.WriteLine();
            Console.WriteLine();

            Dictionary<int, string> productsDictNew = listProducts.ToDictionary(x => x.ID, x => x.Name);

            foreach (KeyValuePair<int, string> kvp  in productsDictNew)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            Console.WriteLine();
            Console.WriteLine();

            var toLookUpMS = Student.GetStudents()
                 .ToLookup(s => s.Branch);

            var toLookUpQS = (from std in Student.GetStudents()
                              select std).ToLookup(x => x.Branch);

            foreach(var group in toLookUpMS)
            {
                Console.WriteLine(group.Key + ":" + group.Count());

                foreach (var student in group)
                {
                    Console.WriteLine("Name :" + student.Name + ", Age: " + student.Age + ", Gender :" + student.Gender);
                }
            }

            // Group by Gender in DESC, Names in ASC
            // Group by gender
            // Sort the group DESC
            // Sort the student names in ASC

            var groupByMS = Student.GetStudents()
                .ToLookup(s => s.Gender)
                .OrderByDescending(c => c.Key)
                .Select(std => new StudentGroup
                {
                    Key = std.Key,
                    Students = std.OrderBy(x => x.Name).ToList()
                });

            var groupByQS = (from std in Student.GetStudents()
                             select std)
                             .ToLookup(s => s.Gender)
                .OrderByDescending(c => c.Key)
                .Select(std => new
                {
                    Key = std.Key,
                    Students = std.OrderBy(x => x.Name)
                });

            Console.WriteLine();
            Console.WriteLine();

            foreach (var group in groupByMS)
            {
                Console.WriteLine(group.Key + ":" + group.Students.Count());

                // iterate over each group of students

                foreach(var student in group.Students)
                {
                    Console.WriteLine("Name :" + student.Name + ", Age: " + student.Age + ", Branch :" + student.Branch);
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            // GRup students first on the branch of study, and then by Gender

            var groupByMultipleKeysMS = Student.GetStudents()
                .ToLookup(x => new
                {
                    x.Branch, x.Gender
                })
                .Select(g => new
                {
                    Branch = g.Key.Branch,
                    Gender = g.Key.Gender,
                    Students = g.OrderBy(x => x.Name)
                });

            foreach (var group in groupByMultipleKeysMS)
            {
                Console.WriteLine($"branch : {group.Branch} Gender: {group.Gender} No of Students = {group.Students.Count()}");
                //It will iterate through each item of a group
                foreach (var student in group.Students)
                {
                    Console.WriteLine($"  ID: {student.ID}, Name: {student.Name}, Age: {student.Age} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();

            // Group the students by Branch DESC, and then Gender ASC. Then sort by their Names

            groupByMultipleKeysMS = Student.GetStudents()
                .ToLookup(x => new
                {
                    x.Branch,
                    x.Gender
                })
                .OrderByDescending(g => g.Key.Branch)
                .ThenBy(g => g.Key.Gender)
                .Select(g => new
                {
                    Branch = g.Key.Branch,
                    Gender = g.Key.Gender,
                    Students = g.OrderBy(x => x.Name)
                });

            foreach (var group in groupByMultipleKeysMS)
            {
                Console.WriteLine($"branch : {group.Branch} Gender: {group.Gender} No of Students = {group.Students.Count()}");
                //It will iterate through each item of a group
                foreach (var student in group.Students)
                {
                    Console.WriteLine($"  ID: {student.ID}, Name: {student.Name}, Age: {student.Age} ");
                }
                Console.WriteLine();
            }

            // Cast

            ArrayList list = new ArrayList
            {
                10,
                20,
                30
            };

            list.Add("40");

            // list = null;

            // IEnumerable<int> result = list.Cast<int>();

            IEnumerable<int> result = list.OfType<int>();
            foreach (int i in result)
            {
                Console.WriteLine(i);
            }


            // Cast vs OfType
            Console.ReadKey();
        }
    }

    class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }

    class StudentGroup
    {
        public string Key { get; set; }
        public List<Student> Students { get; set; }
    }
}
