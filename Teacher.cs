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
    }
}
