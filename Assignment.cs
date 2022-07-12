david effiong effion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace ConsoleApplication1
{
    class Assignment
    {
      public void studentRegistration()
        {
            Console.WriteLine("Welcome to our student registration portal\n");
            Console.WriteLine("Kindly enter 1 to view all students\nKindly enter 2 to view students based on matric numbers\nKindly enter 3 to register a new student\nKindly enter 4 to modify an existing student information\nKindly enter 5 to delete a  student\nKindly enter 6 to either exit or repeat the instructions again\n");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Press enter at the end of the program to either exit or repeat the instruction again\n");
                viewStudentsAll();
               
                exitApp();
            }
            else if (choice == 2)
            {
                
                viewStudents();
                exitApp();

            }
            else if (choice == 3)
            {
              
                addStudents();
                exitApp();

            }
            else if (choice == 4)
            {
                Console.WriteLine("Press enter at the end of the program to either exit or repeat the instruction again\n");
                updateStudents();
                exitApp();

            }
            else if (choice == 5)
            {
                
                deleteStudents();
                exitApp();

            }
            else if (choice == 6)
            {
                exitApp();

            }
            else if (choice != 1 && choice != 2 && choice != 3 && choice != 4 && choice != 5 && choice != 6)
            {
                Console.WriteLine(" Please enter a correct option");
            }

        }

        //Function for viewing students
        private void viewStudentsAll()
        {
            Console.WriteLine("view students");
            using (var ctx = new schoolContext())
            {
                var studentList = ctx.students.ToList();
                foreach (var item in studentList)
                {
                    Console.WriteLine($"id: {item.StudentID}, Name:{item.StudentName}");
                }
                Console.ReadKey();
            }
        }
        //Function to view a single student
        private void viewStudents()
        {
            Console.WriteLine("Please Enter the StudentId of the student to view Student record");
            var Context = new schoolContext();
            int rowKey = Convert.ToInt32(Console.ReadLine());
            var student = Context.students.Find(rowKey);

            Console.WriteLine($"StudentID; {student.StudentID}, Name: {student.StudentName}, DateOfBirth {student.DateOfBirth}, Height: {student.Height}, Weight: {student.Weight}");
        }
        //Function to add new student
        private void addStudents()
        {
     
            Console.WriteLine("please enter your student_ID, name, folowed by DOB, height and lastly your weight");
            using (var context = new schoolContext())
            {
                var std = new student()
                {
                    StudentID = Convert.ToInt32(Console.ReadLine()),
                    StudentName = Console.In.ReadLine(),
                    DateOfBirth = Console.ReadLine(),
                    Height = Convert.ToInt32(Console.ReadLine()),
                    Weight = Convert.ToInt32(Console.ReadLine())


                };
                context.students.Add(std); context.SaveChanges();
                Console.WriteLine("Student details sucessfully added to database");
            }

        }
        //Function for updating students
        private void updateStudents()
        {
            Console.WriteLine("press 1 to update studentname\npress 2 to update dateofbirth\npress 3 to update Student Height\npress 4 to update Student Weight ");
            int selection = int.Parse(Console.In.ReadLine());
            if (selection == 1)
            {
                Console.WriteLine("enter primary key and update");
                var ctx = new schoolContext();


                var stud = ctx.students.Find(int.Parse(Console.In.ReadLine()));
                {
                    stud.StudentName = Console.In.ReadLine();
                }
                Console.WriteLine("student name sucessfully added");
                ctx.SaveChanges();



            }



            else if (selection == 2)
            {
                var ctx = new schoolContext();

                var stud = ctx.students.Find(int.Parse(Console.In.ReadLine()));
                {
                    stud.DateOfBirth = Console.In.ReadLine();

                }
                Console.WriteLine("Date of birth sucessfully added");
                ctx.SaveChanges();

            }
            else if (selection == 3)
            {
                var ctx = new schoolContext();
                {

                    var stud = ctx.students.Find(int.Parse(Console.In.ReadLine()));
                    stud.Height = Convert.ToInt32(Console.ReadLine());

                }
                Console.WriteLine("student height sucessfully added");
                ctx.SaveChanges();
            }


            else if (selection == 4)
            {
                var ctx = new schoolContext();

                var stud = ctx.students.Find(int.Parse(Console.In.ReadLine()));
                {
                    stud.Weight = int.Parse(Console.In.ReadLine());
                    ctx.SaveChanges();
                }
                Console.WriteLine("student weight sucessfully added");
                ctx.SaveChanges();
            }


            else
            {
                Console.WriteLine("no column to be updated");
            }
            Console.WriteLine("updated successfully");
            Console.ReadKey();
        }

        //Function to delete students
        private void deleteStudents()
        {
            Console.WriteLine("To Delete : Enter Student id");
            using (var ctx = new schoolContext())
            {
                int key = Convert.ToInt32(Console.ReadLine());
                var stud = ctx.students.Find(key);
                ctx.students.Remove(stud);
                Console.WriteLine("student data sucessfully deleted");
                ctx.SaveChanges();
            }

        }
        //Function to exit App
        private void exitApp()
        {
            Console.WriteLine("\nNOTE:enter 0 to exit or 8 to repeat the instructions again");
            int reChoose = Convert.ToInt32(Console.ReadLine());
            if (reChoose == 0)
            {
                Console.WriteLine("Thank you for using our Application, Have a nice day");
                Environment.Exit(0);
            }
            else if (reChoose == 8)
            {
                studentRegistration();
            }
        }
    }
 

}
