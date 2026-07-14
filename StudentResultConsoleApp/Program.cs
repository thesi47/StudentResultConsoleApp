using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentResultConsoleApp
{
    public class Program
    {
        static List<Student> students = new List<Student>();
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine("\n\n\t\t\t\t\t\tStudent Result Console App\n\n");
                    Console.WriteLine("1. Add a Student");
                    Console.WriteLine("2. View All Students");
                    Console.WriteLine("3. Search Student by ID");
                    Console.WriteLine("4. Update Student");
                    Console.WriteLine("5. Delete Student");
                    Console.WriteLine("0. Exit");

                    Console.Write("Enter your Choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();


                    if (choice == 0) return;
                    else if (choice == 1) AddStudent();
                    else if (choice == 2) ViewStudents();
                    else if (choice == 3) SearchStudent();
                    else if (choice == 4) UpdateStudent();
                    else if (choice == 5) DeleteStudent();
                    else Console.WriteLine("Invalid Choice...");

                    Console.WriteLine("\n\nPress any Key to End the Program...");
                    Console.ReadKey();
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.WriteLine("Press any Key to continue...");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    Console.WriteLine("Press any Key to continue...");
                    Console.ReadKey();
                }
            }
        }
        static void AddStudent()
        {
            try
            {
                Student student = new Student();

                Console.Write("Enter ID: ");
                student.Id = Convert.ToInt32(Console.ReadLine());
                if (students.Any(x => x.Id == student.Id))
                {
                    Console.WriteLine("ID Already Exists....");
                    return;
                }

                Console.Write("Enter Name: ");
                student.Name = Console.ReadLine();

                Console.Write("Enter Department: ");
                student.Department = Console.ReadLine();

                Console.Write("Enter Age: ");
                student.Age = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Choose For Grade: ");
                Console.WriteLine("1. A+");
                Console.WriteLine("2. A");
                Console.WriteLine("3. A-");
                Console.WriteLine("4. B");
                Console.WriteLine("5. C");
                Console.WriteLine("6. D");
                Console.WriteLine("7. F");
                int c = Convert.ToInt32(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        student.Grade = "A+";
                        student.CGPA = 4.00;
                        break;
                    case 2:
                        student.Grade = "A";
                        student.CGPA = 3.75;
                        break;
                    case 3:
                        student.Grade = "A-";
                        student.CGPA = 3.50;
                        break;
                    case 4:
                        student.Grade = "B";
                        student.CGPA = 3.00;
                        break;
                    case 5:
                        student.Grade = "C";
                        student.CGPA = 2.00;
                        break;
                    case 6:
                        student.Grade = "D";
                        student.CGPA = 1.00;
                        break;
                    case 7:
                        student.Grade = "F";
                        student.CGPA = 0.00;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        return;
                }

                students.Add(student);
                Console.WriteLine($"Student {student.Name} was Added");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter valid numbers for ID and Age.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void ViewStudents()
        {
            if (!students.Any())
            {
                Console.WriteLine("No Students Were Found!");
                return;
            }
            Console.WriteLine("ID\t\tName\t\tDepartment\t\tAge\t\tCGPA\t\tGrade");
            foreach (var item in students)
            {
                Console.WriteLine($"{item.Id}\t\t{item.Name}\t\t{item.Department}\t\t\t{item.Age}\t\t{item.CGPA}\t\t{item.Grade}");
            }
        }
        static void SearchStudent()
        {
            try
            {
                Console.Write("Enter the Student's ID you want to find: ");
                int id = Convert.ToInt32(Console.ReadLine());
                var s = students.FirstOrDefault(x => x.Id == id);
                if (s == null)
                {
                    Console.WriteLine("No Students Found...");
                    return;
                }
                Console.WriteLine($"Information for ID {s.Id}");
                Console.WriteLine($"Student's Name: {s.Name}");
                Console.WriteLine($"Student's Department: {s.Department}");
                Console.WriteLine($"Student's Age: {s.Age}");
                Console.WriteLine($"Student's CGPA: {s.CGPA}");
                Console.WriteLine($"Student's Grade: {s.Grade}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid ID number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void DeleteStudent()
        {
            try
            {
                Console.Write("Enter the Student's ID you want to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());
                var s = students.FirstOrDefault(x => x.Id == id);
                if (s == null)
                {
                    Console.WriteLine("No Students Found...");
                    return;
                }
                students.Remove(s);
                Console.WriteLine($"Student {s.Name} has been deleted.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid ID number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void UpdateStudent()
        {
            try
            {
                Console.Write("Enter the Student's ID you want to update: ");
                int id = Convert.ToInt32(Console.ReadLine());
                var s = students.FirstOrDefault(x => x.Id == id);
                if (s == null)
                {
                    Console.WriteLine("No Students Found...");
                    return;
                }

                Console.Write("Enter New Name: ");
                s.Name = Console.ReadLine();

                Console.Write("Enter New Department: ");
                s.Department = Console.ReadLine();

                Console.Write("Enter New Age: ");
                s.Age = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Choose For New Grade: ");
                Console.WriteLine("1. A+");
                Console.WriteLine("2. A");
                Console.WriteLine("3. A-");
                Console.WriteLine("4. B");
                Console.WriteLine("5. C");
                Console.WriteLine("6. D");
                Console.WriteLine("7. F");
                int c = Convert.ToInt32(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        s.Grade = "A+";
                        s.CGPA = 4.00;
                        break;
                    case 2:
                        s.Grade = "A";
                        s.CGPA = 3.75;
                        break;
                    case 3:
                        s.Grade = "A-";
                        s.CGPA = 3.50;
                        break;
                    case 4:
                        s.Grade = "B";
                        s.CGPA = 3.00;
                        break;
                    case 5:
                        s.Grade = "C";
                        s.CGPA = 2.00;
                        break;
                    case 6:
                        s.Grade = "D";
                        s.CGPA = 1.00;
                        break;
                    case 7:
                        s.Grade = "F";
                        s.CGPA = 0.00;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        return;
                }
                Console.WriteLine($"Student {s.Name} has been updated.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter valid numbers for ID and Age.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}

https://www.codewars.com/kata/56a5d994ac971f1ac500003e/train/javascript
function longestConsec(strarr, k)
{
    let lengtharr = [];
    for (let i = 0; i < k; i += 1)
    {
        lengtharr.push((strarr[i] + strarr[i + 1]).length);
    }

}