using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;

namespace Classroom_Assistant
{
    class Program
    {

        //Stores the class names in the same index value as the classes in Classes list.
        public static List<string> ClassList = new List<string>();
        public static List<List<student>> Classes = new List<List<student>>();
        public static List<Teacher> Teachers = new List<Teacher>();
        public static bool loggedin = false;
        public static int LoggedIndex = -1;

        static void Main(string[] args)
        {

            Teacher example = new Teacher();
            example.setupTeacher("Susan", "susan01", "susanpassword", false);
            Teachers.Add(example);

            Teacher exampleAdmin = new Teacher();
            exampleAdmin.setupTeacher("Greg", "admin", "admin", true);
            Teachers.Add(exampleAdmin);

            do
            {
                string username = "";
                string password = "";
                int ListSize = -1;
                bool found = false;

                Console.WriteLine("Please Enter Username");
                username = Console.ReadLine();
                Console.WriteLine("Please Enter Password");
                password = Console.ReadLine();

                ListSize = Teachers.Count();
                for (int I = 0; ListSize > I; I++)
                {
                    if (Teachers[I].Login(username, password) == true)
                    {
                        LoggedIndex = I;
                        found = true;
                        loggedin = true;
                    }
                }
                if(found != true)
                 Console.WriteLine("Username or Password was incorrect");
            } while (loggedin == false);

            //Creates a loop so users dont leave the program without choosing
            do
            {
                if (checkAdmin() == false)
                {
                    int menuoption = -1;
                    outputMenuNormalUser();
                    Console.WriteLine("Please choose an option:");
                    menuoption = Convert.ToInt32(Console.ReadLine());
                    switch (menuoption)
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
                            listTeachers();
                            break;
                        case 7:
                            Console.WriteLine("Goodbye, {0}", Teachers[LoggedIndex].teacherName);
                            System.Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Error, please enter a valid option");
                            break;
                    }
                }
                else if (checkAdmin() == true)
                {
                    int menuoption = -1;
                    outputMenuAdminUser();
                    Console.WriteLine("Please choose an option:");
                    menuoption = Convert.ToInt32(Console.ReadLine());
                    switch (menuoption)
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
                            addTeacher();
                            break;
                        case 7:
                            removeTeacher();
                            break;
                        case 8:
                            listTeachers();
                            break;
                        case 9:
                            Console.WriteLine("Goodbye, {0}", Teachers[LoggedIndex].teacherName);
                            System.Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Error, please enter a valid option");
                            break;
                    }
                }
                else
                    Console.WriteLine("Error");
            } while (loggedin == true);


        }
        //Outputs the menu for users
        static void outputMenuNormalUser()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. View Class");
            Console.WriteLine("2. View Student");
            Console.WriteLine("3. Remove Student");
            Console.WriteLine("4. Add Student");
            Console.WriteLine("5. Add Class");
            Console.WriteLine("6. List Teachers");
            Console.WriteLine("6. Exit");
        }

        static void outputMenuAdminUser()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. View Class");
            Console.WriteLine("2. View Student");
            Console.WriteLine("3. Remove Student");
            Console.WriteLine("4. Add Student");
            Console.WriteLine("5. Add Class");
            Console.WriteLine("6. Add Teacher");
            Console.WriteLine("7. Remove Teacher");
            Console.WriteLine("8. List Teachers");
            Console.WriteLine("9. Exit");
        }

        static void addClass()
        {
            int classize = 1;
            string className = "";
            bool success = false;
            Console.WriteLine("Please enter Class Name");
            className = Console.ReadLine();
            Console.WriteLine("Please enter class size");
            do { 
                try { 
                    classize = Convert.ToInt32(Console.ReadLine()); 
                    success = true; 
                } catch
                { Console.WriteLine("Please enter a valid option"); } 
            } while (!success);


            //created in loop as there may be mutiple students being added to the class
            List<student> classa = new List<student>();

            for (int I = 0; I < classize; I++)
            {
                classa.Add(new student());
                Console.WriteLine("Please Enter the students name");
                classa[I].setName(Console.ReadLine());
                Console.WriteLine("Please enter the Students Age");
                classa[I].setAge(Convert.ToInt32(Console.ReadLine()));
            }

            ClassList.Add(className);
            Classes.Add(classa);

            
        }
        static void viewClass()
        {
            string className = "";
            int index = -1;
            bool success = false;

            do
            {
                try
                {
                    Console.WriteLine("Please enter the classes name");
                    className = Console.ReadLine();
                    //gets index from classList to find class in Classes list
                    index = ClassList.IndexOf(className);
                    success = true;
                }
                catch { Console.WriteLine("Invalid Class Name"); }
            } while (!success);


            //Outputs whole class
            foreach (var item in Classes[index])
            {
                Console.WriteLine("Name {0}", item.returnName());
                Console.WriteLine("Age {0}", item.returnAge());
            }


        }

        static void viewStudent()
        {
            string className = "";
            string studentName = "";
            int index;
            bool found = false;
            string repeat;
            bool success = false;

            Console.WriteLine("Please enter students name");
            studentName = Console.ReadLine();
            do
            {
                try
                {
                    Console.WriteLine("Please enter the classes name");
                    className = Console.ReadLine();
                    index = ClassList.IndexOf(className);
                    success = true;
                }
                catch { Console.WriteLine("Invalid Class Name"); }
            } while (!success);

            index = ClassList.IndexOf(className);
            foreach (var item in Classes[index])
            {
                //goes through each member of the class until the correct class member is found
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
            string className = "";
            string studentName = "";
            int index = -1;
            bool found = false;
            string repeat;
            int indexOfStudent = 0;
            int count = 0;
            bool success = false;

            Console.WriteLine("Please enter students name you would like to remove");
            studentName = Console.ReadLine();
            do
            {
                try
                {
                    Console.WriteLine("Please enter the classes name");
                    className = Console.ReadLine();
                    index = ClassList.IndexOf(className);
                    success = true;
                }
                catch { Console.WriteLine("Invalid Class Name"); }
            } while (!success);

            foreach (var item in Classes[index])
            {
                //student cannot be remove while in the list removed after loop has finished 
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

            string className = "";
            int index = 0;
            bool success = false;

            
            do
            {
                try
                {
                    Console.WriteLine("Please enter the classes name");
                    className = Console.ReadLine();
                    index = ClassList.IndexOf(className);
                    success = true;
                }
                catch { Console.WriteLine("Invalid Class Name"); }
            } while (!success);

            student newClassMember = new student();
            Console.WriteLine("Please Enter the students name");
            newClassMember.setName(Console.ReadLine());
            Console.WriteLine("Please enter the Students Age");
            newClassMember.setAge(Convert.ToInt32(Console.ReadLine()));
            Classes[index].Add(newClassMember);

        }

        static bool checkAdmin()
        {
            if (Teachers[LoggedIndex].admin == true)
                return true;
            else
                return false;
        }

        static void addTeacher()
        {
            string name = "";
            string username = "";
            string password = "";
            bool admin = false;
            Teacher newMember = new Teacher();
            Console.WriteLine("Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Username: ");
            username = Console.ReadLine();
            Console.WriteLine("Password: ");
            password = Console.ReadLine();
            Console.WriteLine("Admin: ");
            admin = Convert.ToBoolean(Console.ReadLine());
            newMember.setupTeacher(name, username, password, admin);
        }

        //add error handling for removing yourself
        static void removeTeacher()
        {
            string username = "";
            string repeat = "";
            int removeIndex = -1;
            bool found = false;

            Console.WriteLine("Please enter username");
            username = Console.ReadLine();
            for(int I = 0; Teachers.Count() > I; I++)
            {
                Console.WriteLine(Teachers[I].username);
                if (username == Teachers[I].username)
                {
                    removeIndex = I;
                    found = true;
                }
            }

            if (found == true)
            {
                Teachers.RemoveAt(removeIndex);
                if(LoggedIndex > 0)
                    LoggedIndex = LoggedIndex - 1;
               
            }

            else if (found != true)
            {
                Console.WriteLine("User not found would you like to repeat the proccess Y or N");
                repeat = Console.ReadLine();
                if (repeat == "Y")
                    removeTeacher();
            }
        }

        static void listTeachers()
        {
            foreach(var item in Teachers)
            {
                Console.WriteLine("Name: {0}\nUsername: {1} ", item.teacherName, item.username);
            }
        }

    }
}

