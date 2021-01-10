using System;

namespace TeacherStudent
{
    class Program
    {
        static void Main(string[] args)
        {
            int classize = 1;

            Console.WriteLine("Please enter class size");
            classize = Convert.ToInt32(Console.ReadLine());

            student[] classa = new student[classize];

            for(int I = 0; I < classize; I++)
            {
                classa[I] = new student();
                Console.WriteLine("Please Enter the students name");
                classa[I].setName(Console.ReadLine());
                Console.WriteLine("Please enter the Students Age");
                classa[I].setAge(Convert.ToInt32(Console.ReadLine()));
            }

            for(int I = 0; I < classize; I++)
            {
                Console.WriteLine("Name: {0}" ,classa[I].returnName());
                Console.WriteLine("Age: {0}" ,classa[I].returnAge());

            }
        }
    }

    public class student
    {
        public string name = "";
        public int age = -1;

        public void setName(string x)
        {
            this.name = x;
        }

        public void setAge(int x)
        {
            this.age = x;
        }

        public string returnName()
        {
            return name;
        }

        public int returnAge()
        {
            return age;
        }
    }

}
