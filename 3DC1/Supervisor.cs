using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DC1
{
    public abstract class Supervisor
    {
        public abstract void FI4SP();
        protected string Supervisor_name {  get; set; }
        

        protected Supervisor(string name) 
        {
            if (name == null || name == String.Empty)
            {
                throw new Exception("null or empty name");
            }
            Supervisor_name = name;
        }




    }
}
