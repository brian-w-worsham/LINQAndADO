using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemoApp
{
    class GroupByOperatorInLINQ
    {
        static void Main(string[] args)
        {
            // IGrouping<TKey, TValue>

            IEnumerable<IGrouping<string, Student>> groupByMS = Student.GetStudents().GroupBy(s => s.Branch);

            IEnumerable<IGrouping<string, Student>> groupByQS = (from std in Student.GetStudents()
                                                                 group std by std.Branch);


            foreach (IGrouping<string, Student> group in groupByMS)
            {
                Console.WriteLine(group.Key + " : " + group.Count());

                foreach (var student in group)
                {
                    Console.WriteLine("  Name :" + student.Name + ", Age: " + student.Age + ", Gender :" + student.Gender);
                }
            }


            // Group by Gender in DESC order and names in ASC order
            var groupByMsExampleTwo = Student.GetStudents()
                .GroupBy(s => s.Gender)
                .OrderByDescending(g => g.Key)
                .Select(std => new
                {
                    Key = std.Key,
                    Students = std.OrderBy(s => s.Name)
                });

            var groupdByQsExampleTwo = from std in Student.GetStudents()
                                       group std by std.Gender into stdGroup
                                       orderby stdGroup.Key descending
                                       select new
                                       {
                                           Key = stdGroup.Key,
                                           Students = stdGroup.OrderBy(x => x.Name)
                                       };

            foreach (var group in groupByMsExampleTwo)
            {
                Console.WriteLine(group.Key + ":" + group.Students.Count());

                foreach (var student in group.Students)
                {
                    Console.WriteLine("  Name :" + student.Name + ", Age: " + student.Age + ", Branch :" + student.Branch);
                }
            }


            Console.WriteLine("----------");

            var groupdByMultipleKeysMS = Student.GetStudents()
                .GroupBy(x => new { x.Branch, x.Gender })
                .Select(g => new
                {
                    Branch = g.Key.Branch,
                    Gender = g.Key.Gender,
                    Students = g.OrderBy(x => x.Name)
                });

            var groupByMultipleKeysQS = from std in Student.GetStudents()
                                        group std by new
                                        {
                                            std.Branch,
                                            std.Gender
                                        } into stdGroup
                                        select new
                                        {
                                            Branch = stdGroup.Key.Branch,
                                            Gender = stdGroup.Key.Gender,
                                            Students = stdGroup.OrderBy(x => x.Name)
                                        };

            foreach (var group in groupByMultipleKeysQS)
            {
                Console.WriteLine($"Branch : {group.Branch} Gender: {group.Gender} No of Students = {group.Students.Count()}");
                //It will iterate through each item of a group
                foreach (var student in group.Students)
                {
                    Console.WriteLine($"  ID: {student.ID}, Name: {student.Name}, Age: {student.Age} ");
                }
                Console.WriteLine();
            }

            // Group students based on the branch and gender. Then order by descending branch and then by gender, and return the list in DESC order of names
            var students = Student.GetStudents();

            var groupedStudents = students
            .GroupBy(s => new { s.Branch, s.Gender }) // Group by Branch and Gender
            .OrderByDescending(g => g.Key.Branch)      // Order groups by descending Branch
            .ThenByDescending(g => g.Key.Gender)       // Then order groups by descending Gender
            .SelectMany(g => g.OrderByDescending(s => s.Name)) // Sort students' names in each group in descending order
            .ToList(); // Convert the result to a List<Student>

            foreach (var student in groupedStudents)
            {
                Console.WriteLine($"Name: {student.Name}, Branch: {student.Branch}, Gender: {student.Gender}");
            }

            Console.Read();

        }
    }
}