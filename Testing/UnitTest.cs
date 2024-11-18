using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace _3DC1.Tests
{
    [TestClass]
    public class UnitTest
    {
        private string tempFilePath = "ResOutput_Test.txt";
        private FL4_SNT seniorTutor = new FL4_SNT("tutor name");
        private FL4_PS supervisor = new FL4_PS("supervisor name");
        private FL4_STD student = new FL4_STD("student name");
        private UI ui = new UI();

        [TestInitialize]
        public void Setup()
        {
            
            tempFilePath = "ResOutput_Test.txt";
            File.WriteAllLines(tempFilePath, new[] {
            "Phase 1: Meeting with student A",
            "Phase 2: Report to supervisor",
            "Phase 3: Feedback session with supervisor"
        });

            
            seniorTutor = new FL4_SNT("Senior Tutor name");
            supervisor = new FL4_PS("Supervisor name");
            student = new FL4_STD("Student_Name");
            ui = new UI();
        }


        [TestMethod] // 1
        public void DisplayAllInteractions_FileExists_DisplaysInteractions()
        {
            using (var StW = new StringWriter())
            {
                Console.SetOut(StW);

                
                seniorTutor.DisplayAllInteractions(tempFilePath);

                var result = StW.ToString();

               
                Assert.IsTrue(result.Contains("Phase 1: Meeting with student"));
                Assert.IsTrue(result.Contains("Phase 2: Report to supervisor"));
                Assert.IsTrue(result.Contains("Phase 3: Feedback session with supervisor"));
            }
        }

        [TestMethod] // 2
        public void DisplayAllInteractions_FileDoesNotExist_DisplaysNoInteractionsMessage()
        {
            File.Delete(tempFilePath);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                
                seniorTutor.DisplayAllInteractions(tempFilePath);

                var result = sw.ToString();

                
                Assert.IsTrue(result.Contains("No interactions found."));
            }
        }

        [TestMethod] // 3
        public void ReviewStudentStatus_FileExists_DisplaysStatus()
        {
            using (var StW = new StringWriter())
            {
                Console.SetOut(StW);

                supervisor.ReviewStudentStatus(tempFilePath);

                var result = StW.ToString();

                Assert.IsTrue(result.Contains("Meeting with student"));
                Assert.IsTrue(result.Contains("Report to supervisor"));
                Assert.IsTrue(result.Contains("Feedback session with supervisor"));
            }
        }


        [TestMethod] // 4
        public void BookMeetingWithStudent_AppendsToFile()
        {
            supervisor.BookMeetingWithStudent("Student_Name", tempFilePath);

            string[] lines = File.ReadAllLines(tempFilePath);
            string lastLine = lines[^1]; 

            Assert.IsTrue(lastLine.Contains("Meeting booked with Student: Student_Name"));
            Assert.IsTrue(lastLine.Contains("Supervisor: Supervisor name"));
        }
        
        [TestMethod]  // 5
        public void SaveReportToFile_ValidReport_SavesReport()
        {
           
            string reportName = "test report.";
            student.SaveReportToFile(reportName, tempFilePath);

            
            string[] lines = File.ReadAllLines(tempFilePath);
            string lastLine = lines[^1]; 

            Assert.IsTrue(lastLine.Contains("Student: Student_Name"));
            Assert.IsTrue(lastLine.Contains("Report: test report."));
        }

        [TestMethod] // 6
        public void SaveMeetingToFile_SavesMeeting_For_Student()
        {
           
            student.SaveMeetingToFile(tempFilePath);

            
            string[] lines = File.ReadAllLines(tempFilePath);
            string lastLine = lines[^1]; 

            Assert.IsTrue(lastLine.Contains("Student: Student_Name"));
            Assert.IsTrue(lastLine.Contains("Meeting booked."));
        }

        [TestMethod] // 7

        public void GetValidInput_ValidOptionEntered_ReturnsInput()
        {
            
            var ui = new UI();
            string Testprompt = "Enter option:";
            List<string> validOptions = new List<string> { "1", "2", "3" };

            using (StringReader sr = new StringReader("2\n"))
            {
                Console.SetIn(sr);

                
                string result = ui.GetValidInput(Testprompt, validOptions);
                Assert.AreEqual("2", result);
            }
        }

        [TestMethod] // 8
        public void GetValidInput_InvalidThenValidOption_ReturnsValidOption()
        {
           
            var ui = new UI();
            string Testprompt = "Enter option:";
            List<string> validOptions = new List<string> { "1", "2", "3" };

            
            using (StringReader StR = new StringReader("4\n2\n"))
            {
                Console.SetIn(StR);

                
                string result = ui.GetValidInput(Testprompt, validOptions);

                
                Assert.AreEqual("2", result);
            }
        }


        [TestMethod] // 9
        public void GetNonEmptyInput_EmptyThenValidInput_ReturnsValidInput()
        {
            
            var ui = new UI();
            var Testprompt = "Enter your name:";
            var inputSequence = new Queue<string>(new[] { "", "ValidName" }); // first empty, then valid

            
            using (var Stw = new StringWriter())
            using (var Str = new StringReader(string.Join(Environment.NewLine, inputSequence)))
            {
                Console.SetOut(Stw);
                Console.SetIn(Str);

               
                string result = ui.GetNonEmptyInput(Testprompt);

                
                Assert.AreEqual("ValidName", result);
            }
        }

        [TestCleanup] 
        public void Clearup()
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });

            if (File.Exists(tempFilePath))
            {
                File.Delete(tempFilePath);
            }
        }
    }
}
