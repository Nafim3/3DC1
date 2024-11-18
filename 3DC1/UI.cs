using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DC1
{
    public class UI // UI means User Interface
    {
        public void Display_Facility_Options()
        {
            string user_Credentials = GetValidInput(
            "What are you?\n1. Student \n2. Senior Tutor \n3. Supervisor\nenter your role as number:\n",
            new List<string> { "1", "2", "3" });

            if (user_Credentials == "1")
            {
                string student_name = GetNonEmptyInput("What is your name?");
                FL4_STD fL4stdinstantiation = new FL4_STD(student_name);
                fL4stdinstantiation.MFacilityList4_students();
                fL4stdinstantiation.FI4STD();

            }

            else if (user_Credentials == "3")
            {
                string Supervisor_name = GetNonEmptyInput("What is your name?");
                FL4_PS supervisor_instantiation = new FL4_PS(Supervisor_name);
                supervisor_instantiation.MFacilityList4_personal_supervisor();
                supervisor_instantiation.FI4SP();
            }

            else if (user_Credentials == "2")
            {
                string Tutor_name = GetNonEmptyInput("What is your name?");
                FL4_SNT SnTinstantiation = new FL4_SNT(Tutor_name);
                SnTinstantiation.MFacilityList4_senior_tutor();
                SnTinstantiation.FI4SNT();
            }
        }

        public string GetValidInput(string prompt, List<string> validOptions)
        {
            string input;
            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine()?.Trim()?.ToLower() ?? "";

                if (!validOptions.Contains(input))
                {
                    Console.WriteLine("Invalid input. enter the serial number denoting for one of the following options: " + string.Join(", ", validOptions));
                }

            } while (!validOptions.Contains(input));

            return input;
        }

        // method to ensure a non-empty input for names
        public string GetNonEmptyInput(string prompt)
        {
            string input;
            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine()?.Trim()??"";

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty. enter a valid name.");
                }

            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }
    }
}
