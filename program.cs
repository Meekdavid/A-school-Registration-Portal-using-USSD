
using GTBTech.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Assignment take = new Assignment();
            take.studentRegistration();
            Console.ReadKey();
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
            }
        }


    
        public static void LetGetStarted()
        {
            char[] ducks = { 'a', 'b', 'c', 'd', ' ', 'a', 'b', 'c', 'd', 'e'};
            string[] mboko = { "akp", "ble", "name", "dog" };
            string name = "" ;

            int[] a = new int[10];
            for (int i = 0; i < ducks.Length; i++)
            {
                name += ducks[i];
                a[i] = i + 1;
                SendMessage(name, a[i]);
            }
        }
        private void viewStudents()
        {
            Console.WriteLine("halleluiah");
        }
        public void addStudents()
        {
           using (var ctx = new schoolContext())
            {
                var stud = new student()
                {
                    StudentName = Console.ReadLine(),

                };
            }
        }

        public static void SendMessage(string name, int message)
        {
            Console.WriteLine("Hello" + name + "!!! " + "Count to " + message);
        }
    }
    
}
