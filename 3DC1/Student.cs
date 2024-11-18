using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _3DC1
{
    public abstract class Student
    {

        protected string student_name { get; set; }
        public abstract void FI4STD();

        protected Student(string name)
        {
            if (name == null || name == String.Empty)
            {
                throw new Exception("null or empty name");
            }
            student_name = name;
        }
    }
}
