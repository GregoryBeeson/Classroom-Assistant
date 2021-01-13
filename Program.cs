using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;

namespace Classroom_Assistant
{
    class Program
    {
        public static List<string> ClassList = new List<string>();
        public static List<List<student>> Classes = new List<List<student>>();
        static void Main(string[] args)
        {
            do
            {
                int menuoption;
                outputMenu();
                Console.WriteLine("Please choose an option:");
                menuoption = Convert.ToInt32(Console.ReadLine());
                switch(menuoption)
                {
                    case 1:
                        viewClass();
                        break;
                    case 2:
                        viewStudent();
                        break;
                    case 3:
                        removeStudent();
                        break;
                    case 4:
                        addStudent();
                        break;
                    case 5:
                        addClass();
                        break;
                    case 6:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Error, please enter a valid option");
                        break;
                }

            } while (true);

        }
        static void outputMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. View Class");
            Console.WriteLine("2. View Student");
            Console.WriteLine("3. Remove Student");
            Console.WriteLine("4. Add Student");
            Console.WriteLine("5. Add Class");
            Console.WriteLine("6. Exit");
        }

        static void addClass()
        {
            int classize = 1;
            string ClassName = "";
            Console.WriteLine("Please enter Class Name");
            ClassName = Console.ReadLine();
            Console.WriteLine("Please enter class size");
            classize = Convert.ToInt32(Console.ReadLine());

            List<student> classa = new List<student>();

            for (int I = 0; I < classize; I++)
            {
                classa.Add(new student());
                Console.WriteLine("Please Enter the students name");
                classa[I].setName(Console.ReadLine());
                Console.WriteLine("Please enter the Students Age");
                classa[I].setAge(Convert.ToInt32(Console.ReadLine()));
            }

            ClassList.Add(ClassName);
            Classes.Add(classa);

            
        }
        static void viewClass()
        {
            string classname;
            int index;
            Console.WriteLine("Please enter the classes name");
            classname = Console.ReadLine();
            index = ClassList.IndexOf(classname);
            foreach(var item in Classes[index])
            {
                Console.WriteLine("Name {0}", item.returnName());
                Console.WriteLine("Age {0}", item.returnAge());
            }


        }

        static void viewStudent()
        {
            string className;
            string studentName;
            int index;
            bool found = false;
            string repeat;

            Console.WriteLine("Please enter the classes name");
            className = Console.ReadLine();
            Console.WriteLine("Please enter students name");
            studentName = Console.ReadLine();
            index = ClassList.IndexOf(className);
            foreach (var item in Classes[index])
            {
                if(studentName == item.returnName())
                {
                    Console.WriteLine("Name: {0}", item.returnName());
                    Console.WriteLine("Age: {0}", item.returnAge());
                    found = true;
                }
            }
            if(found != true)
            {
                Console.WriteLine("Student can not be found. Would you like to try again? Y/N");
                repeat = Console.ReadLine();
                if (repeat == "Y")
                    viewStudent();
            }
        }

        static void removeStudent()
        { 
            string className;
            string studentName;
            int index;
            bool found = false;
            string repeat;
            int indexOfStudent = 0;
            int count = 0;

            Console.WriteLine("Please enter the classes name");
            className = Console.ReadLine();
            Console.WriteLine("Please enter students name you would like to remove");
            studentName = Console.ReadLine();
            index = ClassList.IndexOf(className);
            foreach(var item in Classes[index])
            {
                if(studentName == item.returnName())
                {
                    indexOfStudent = count;
                    found = true;
                }
                count = count + 1;
            }
            if (found == true)
                Classes[index].RemoveAt(indexOfStudent);
            else if (found != true)
            {
                Console.WriteLine("Student can not be found. Would you like to try again? Y/N");
                repeat = Console.ReadLine();
                if (repeat == "Y")
                    removeStudent();
            }
        }

        static void addStudent()
        {

            string className;
            int index;


            Console.WriteLine("Please enter the classes name");
            className = Console.ReadLine();
            index = ClassList.IndexOf(className);
            student newClassMember = new student();

            Console.WriteLine("Please Enter the students name");
            newClassMember.setName(Console.ReadLine());
            Console.WriteLine("Please enter the Students Age");
            newClassMember.setAge(Convert.ToInt32(Console.ReadLine()));
            Classes[index].Add(newClassMember);

        }


    }
}

