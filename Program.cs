using System;
using System.Collections.Generic;
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
                        Console.WriteLine("To be added");
                        break;
                    case 3:
                        Console.WriteLine("To be added");
                        break;
                    case 4:
                        Console.WriteLine("To be added");
                        break;
                    case 5:
                        addClass();
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
            Console.WriteLine(ClassList.IndexOf(classname));
            index = ClassList.IndexOf(classname);
            foreach(var item in Classes[index])
            {
                Console.WriteLine("Name {0}", item.returnName());
                Console.WriteLine("Age {0}", item.returnAge());

            }


        }


    }
}

