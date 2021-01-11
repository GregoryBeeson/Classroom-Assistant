using System;
using System.Collections.Generic;

namespace Classroom_Assistant
{
    public class student
    {
        private string name;
        private int age;

        //Each done individually in order to change specific information per student.  
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
