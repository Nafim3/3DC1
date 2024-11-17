using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace _3DC1
{

    // FL4_STD means Facility List for Students
    public class FL4_STD : Student
    {
        public FL4_STD(string name) : base(name)
        {
        }
        public void MFacilityList4_students()
        {
            Console.WriteLine($"Hello, {student_name}");
            Console.WriteLine("what do you want to do?\n1.Report to your supervisor\n2.Book a meeting with your supervisor\n");
        }

        // FI4STD means Facility Implementation for students
        public override void FI4STD()
        {
            bool continueAction = true;

            while (continueAction)
            {
                Console.WriteLine("Choose a number between 1 and 2 from the options");
                string SelcInput = Console.ReadLine()!;

                if (SelcInput == "1")
                {
                    Console.WriteLine("Write down your report:");
                    string stdReport = Console.ReadLine()!;
                    if (!string.IsNullOrWhiteSpace(stdReport))
                    {

                        SaveReportToFile(stdReport, "ResOutput.txt");
                    }
                }
                else if (SelcInput == "2")
                {
                    Console.WriteLine($"Meeting booked on {DateTime.Now}");
                    SaveMeetingToFile("ResOutput.txt");
                }
                else
                {
                    Console.WriteLine("Invalid input. enter 1 or 2.");
                    continue; 
                }

                
                while (true)
                {
                    Console.WriteLine("Would you like to perform another action? (yes/no)");
                    string continueResponse = Console.ReadLine()!.ToLower();

                    if (continueResponse == "no")
                    {
                        continueAction = false; // End the main loop
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

        public void SaveReportToFile(string report, string filePath = "ResOutput.txt")
        {
           
            string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm} - Student: {student_name}, Report: {report}";

            try
            {
                // Append the entry to the file
                File.AppendAllText(filePath, entry + Environment.NewLine);
                Console.WriteLine("Report sent to your supervisor");
                Console.WriteLine("Report saved successfully to ResOutput.txt in the bin folder");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving report: {ex.Message}, try again");
            }
        }

        public void SaveMeetingToFile(string filePath = "ResOutput.txt")
        {
         
            string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm} - Student: {student_name}, Meeting booked.";

            try
            {
                File.AppendAllText(filePath, entry + Environment.NewLine);
                Console.WriteLine("Meeting is booked with your supervisor");
                Console.WriteLine("Meeting saved successfully to ResOutput.txt in the bin folder");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving meeting: {ex.Message}, try again");
            }
        }
    }

}
