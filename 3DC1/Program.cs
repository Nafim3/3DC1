using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DC1
{
    internal class Program
    {

        static void Main()
        {
            Console.WriteLine("1.Start the program\n2.Exit\n");
            Console.WriteLine("choose a number between 1 and 2");
            while (true)
            {
                string First_input = Console.ReadLine()!;
                if (First_input == "1")
                {
                    UI uI = new UI();
                    uI.Display_Facility_Options();
                    break;
                }
                else if (First_input == "2")
                {
                    Console.WriteLine("exited the program");
                    break;
                }
                else {Console.WriteLine("not a valid number. try again and choose one of following options"); }
            }
        }

    }

}

