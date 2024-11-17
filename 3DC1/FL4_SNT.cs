using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _3DC1
{
    // FL4_SNT means Facility List for senior tutor

    public class FL4_SNT : Senior_tutor
    {
        public FL4_SNT(string name) : base(name)
        {
        }

        public void MFacilityList4_senior_tutor()
        {
            Console.WriteLine($"hello, {Tutor_name} ");
            Console.WriteLine("Option\n1.see the status of all students and how the PS are interacting with the students");
        }

        // FI4SNT means Facility Implementation for senior tutor 
        public override void FI4SNT()
        {
            bool continueAction = true;

            while (continueAction)
            {
                Console.WriteLine("You have one option. To view all interactions, enter the number '1'.");

                string? SeclOp = Console.ReadLine();
                if (SeclOp == "1")
                {
                    
                    DisplayAllInteractions();
                }
                else
                {
                    Console.WriteLine("Invalid input. enter '1' to proceed.");
                    continue; 
                }

                
                while (true)
                {
                    Console.WriteLine("Would you like to perform the same action again? (yes/no)");
                    string continueResponse = Console.ReadLine()?.ToLower() ?? "";

                    if (continueResponse == "no")
                    {
                        continueAction = false; 
                        break;
                    }
                    else if (continueResponse == "yes")
                    {
                        break; 
                    }
                    else
                    {
                        Console.WriteLine("Invalid response. enter 'yes' or 'no'.");
                    }
                }
            }
        }

        public void DisplayAllInteractions(string filePath = "ResOutput.txt")
        {
            if (File.Exists(filePath))
            {
                string[] entries = File.ReadAllLines(filePath);
                Console.WriteLine("All Interactions (Reports and Meetings):");
                foreach (var entry in entries)
                {
                    Console.WriteLine(entry);
                }
            }
            else
            {
                Console.WriteLine("No interactions found.");
            }
        }
    }
}
