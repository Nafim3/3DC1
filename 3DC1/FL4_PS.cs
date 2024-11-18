using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace _3DC1
{
    // FL4_PS means Facility list for personal supervisor
    public class FL4_PS : Supervisor
    {
        private readonly string _filePath;
        public FL4_PS(string name, string filePath = "ResOutput.txt") : base(name)
        {
            _filePath = filePath;
        }


        public void MFacilityList4_personal_supervisor()
        {
            Console.WriteLine($"Hello, {Supervisor_name}");
            Console.WriteLine("what do you want to do?\n1.Review the status of all of students\n2.Book a meeting with students\n");
        }

        // FI4SP means Facility implementation for supervisor
        public override void FI4SP()
        {
            bool continueAction = true;

            while (continueAction)
            {
                MFacilityList4_personal_supervisor();

                string? selection = Console.ReadLine();

                if (selection == "1")
                {
                    ReviewStudentStatus("ResOutput.txt");
                }
                else if (selection == "2")
                {
                    Console.WriteLine("Enter the student's name:");
                    string? studentName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(studentName))
                    {
                        BookMeetingWithStudent(studentName, "ResOutput.txt");
                    }
                }
                else
                {
                    Console.WriteLine("Not a valid number. choose one of the options shown.");
                    continue; 
                }

                
                while (true)
                {
                    Console.WriteLine("Would you like to perform another action? (yes/no)");
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

        public void ReviewStudentStatus(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] entries = File.ReadAllLines(filePath);
                Console.WriteLine("Student Reports and Meetings:");
                foreach (var entry in entries)
                {
                    Console.WriteLine(entry);
                }
            }
            else
            {
                Console.WriteLine("No reports found.");
            }
        }

        public void BookMeetingWithStudent(string studentName, string filePath)
        {
            string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm} - Supervisor: {Supervisor_name}, Meeting booked with Student: {studentName}.";

            try
            {
                File.AppendAllText(filePath, entry + Environment.NewLine);
                Console.WriteLine($"Meeting booked with {studentName} and saved to {filePath} in the bin folder");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving meeting: {ex.Message}, try again");
            }
        }
    }
}