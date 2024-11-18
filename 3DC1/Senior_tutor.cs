using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DC1
{
    public abstract class Senior_tutor
    {
        public abstract void FI4SNT();
        protected string Tutor_name {  get; set; }

        protected Senior_tutor(string name)
        {
            if (name == null || name == String.Empty)
            {
                throw new Exception("null or empty name");
            }
            Tutor_name = name;
        }


    }
}
