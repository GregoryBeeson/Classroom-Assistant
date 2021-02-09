using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom_Assistant
{
    class Teacher
    {
        public string teacherName;
        public string username;
        private string password;
        public bool admin = false;
        public List<string> teachersClasses = new List<string>();


        public void setupTeacher(string name, string username, string password, bool admin)
        {
                this.teacherName = name;
                this.username = username;
                this.password = password;
                this.admin = admin;
                teachersClasses.Add("");
        }
            

        public bool Login(string inputUsername, string inputPassword)
        {
            if (inputUsername == username && inputPassword == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void addTeacherClass(string classname)
        {
            teachersClasses.Add(classname);
        }

        public void removeTeacherClass(string classname)
        {
            teachersClasses.Remove(classname);
        }

        public bool accessClass(string classname)
        {
            bool access = false;

            foreach(var item in teachersClasses)
            {
                if (item == classname)
                    access = true;
            }
            return access;

        }
    }
}
