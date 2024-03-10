using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdmissionApp
{
    public class Program 
    {
        #region Fields Info
        static int ObjIndex = 0;
        static List<StudentInfo> std = new List<StudentInfo>();
        static List<CourseInfo> course = new List<CourseInfo>();
        static List<string> menuItems = new List<string>();
        static int stdID = 4;
        static int courseID = 5;
        #endregion


        #region Main
        static void Main(string[] args)
        {
            Console.Clear();
            course.Add(new CourseInfo { cID = "1", cName = "Technology", Fees = "6,165£/Year"});
            course.Add(new CourseInfo { cID = "2", cName = "Business", Fees = "6,165£/Year"});
            course.Add(new CourseInfo { cID = "3", cName = "Health", Fees = "6,165£/Year"});
            course.Add(new CourseInfo { cID = "4", cName = "Accounting", Fees = "6,165£/Year"});
            course.Add(new CourseInfo { cID = "5", cName = "Education", Fees = "6,000£/Year" });
            std.Add(new StudentInfo { ID = "1", FName = "Cristin", LName = "Ursu", DOB ="15/02/1992", Phone_Number="0745556663", CStartDate=DateTime.Now , CName ="Technology", Course_Fees= "6,165£/Year", SType ="Part Time" });
            std.Add(new StudentInfo { ID = "2", FName = "Angela", LName = "Gonta", DOB = "23/10/1996", Phone_Number = "0744446661", CStartDate = DateTime.Now, CName = "Health", Course_Fees = "6,165£/Year", SType = "Part Time" });
            std.Add(new StudentInfo { ID = "3", FName = "Ion", LName = "Vanuschi", DOB = "10/09/1991", Phone_Number = "0765396463", CStartDate = DateTime.Now, CName = "Business", Course_Fees = "6,165£/Year", SType = "Part Time" });
            std.Add(new StudentInfo { ID = "4", FName = "Alex", LName = "Sonix", DOB = "03/05/1990", Phone_Number = "0740550603", CStartDate = DateTime.Now, CName = "Education", Course_Fees = "6,000£/Year", SType = "Part Time" });
            menuItems = new List<string>()
            {
                "Add New Admission",
                "Add New Course",
                "Get Student Admission List",
                "Get Course List",
                "Admission List By StudentID",
                "Admission List By Course",
                "Remove Admission By StudentID",
                "Remove Course By cID",
                "Change Course Name By cID",
                "Course Detail By Name",
                "Exit"
            };
            Console.CursorVisible = false;
            while (true)
            {
                string menuName = AdminOptions(menuItems);
                if (menuName == "Add New Admission")
                {
                    AddNewAdmission();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (menuName == "Add New Course")
                {
                    AddNewCourse();
                    Console.ReadKey();
                    Console.Clear();
                }else if (menuName == "Get Student Admission List")
                {
                    GetStudentAdmissionList();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (menuName == "Admission List By StudentID")
                {
                    SearchAdmissionByStudentID();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (menuName == "Admission List By Course")
                {
                    SearchAdmissionDetailByCourse();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (menuName == "Get Course List")
                {
                    GetCourseList();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (menuName == "Remove Admission By StudentID")
                {
                    DeleteStudentById();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (menuName == "Remove Course By cID")
                {
                    DeleteExistingCourse();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (menuName == "Change Course Name By cID")
                {
                    ChangeExistingCourse();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (menuName == "Course Detail By Name")
                {
                    SearchCourseByName();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (menuName == "Exit")
                {
                    Environment.Exit(0);
                }
            }
        }

        public static string AdminOptions(List<string> MenuOpt)
        {
            for (int i = 0; i < MenuOpt.Count; i++)
            {
                if (i == ObjIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(MenuOpt[i]);
                }
                else
                {
                    Console.WriteLine(MenuOpt[i]);
                }
                Console.ResetColor();
            }

            ConsoleKeyInfo KeyDetail = Console.ReadKey();
            if (KeyDetail.Key == ConsoleKey.DownArrow)
            {
                if (ObjIndex == MenuOpt.Count - 1) { }
                else { ObjIndex++; }
            }
            else if (KeyDetail.Key == ConsoleKey.UpArrow)
            {
                if (ObjIndex <= 0) { }
                else { ObjIndex--; }
            }
            else if (KeyDetail.Key == ConsoleKey.LeftArrow)
            {
                Console.Clear();
            }
            else if (KeyDetail.Key == ConsoleKey.RightArrow)
            {
                Console.Clear();
            }
            else if (KeyDetail.Key == ConsoleKey.Enter)
            {
                return MenuOpt[ObjIndex];
            }
            else
            {
                return "";
            }

            Console.Clear();
            return "";
        }
        #endregion

        #region Methods
        public static void AddNewAdmission()
        {
            Console.WriteLine();
            StudentInfo info = new StudentInfo();
            stdID++;
            info.ID = stdID.ToString();
            info.FName = ValidationClass.CheckNullValue("First Name");
            info.LName = ValidationClass.CheckNullValue("Last Name");
            info.DOB = ValidationClass.ValidInputDate("Date of birth(DD/MM/YYY)");
            info.Phone_Number = ValidationClass.ValidNumber("Phone Number");
            info.CName = ValidationClass.ValidCourseName("Course Name", course);
            info.CStartDate = DateTime.Now.Date;
            info.Course_Fees = course.Where(ls => ls.cName == info.CName).FirstOrDefault().Fees;
            info.SType = ValidationClass.ValidType("Student_Type(Part Time/Full Time)");
            Console.WriteLine();
            Console.WriteLine("****************Admission added successfully**********************");
            std.Add(info);

        }

        public static void AddNewCourse()
        {
            Console.WriteLine();
            CourseInfo cd = new CourseInfo();
            courseID++;

            cd.cID = courseID.ToString();
            cd.cName = ValidationClass.CheckNullValue("Enter Course Name");
            cd.Fees = ValidationClass.CheckNullValue("Enter Course Fees") + "£/Year";
            course.Add(cd);
            Console.WriteLine();
            Console.WriteLine("****************Course added successfully**********************");
        }


        public static void GetStudentAdmissionList()
        {
            Console.WriteLine("****************Student List**********************");
            var table = new ConsoleTable("ID", "First Name", "Last Name", "Date Of Birth", "Phone Number", "Course Name", "Start Date", "Course Fees", "Student Student_Type");
            if (std.Any())
            {
                foreach (var info in std)
                {
                    table.AddRow(info.ID, info.FName, info.LName, info.DOB, info.Phone_Number, info.CName, info.CStartDate, info.Course_Fees, info.SType);
                }
            }
            else
            {
                Console.WriteLine("No record found");
            }
            table.Write();
        }

        public static void SearchAdmissionByStudentID()
        {
            Console.WriteLine();
            string ID = ValidationClass.CheckNullValue("Enter Student Id");
            Console.WriteLine("****************Admission Info By Student ID**********************");
            var table = new ConsoleTable("ID", "First Name", "Last Name", "Date Of Birth", "Phone Number", "Course Name", "Start Date", "Course Fees", "Student_Type");
            if (std.Any())
            {
                var info = std.Where(m => m.ID == ID).FirstOrDefault();
                if (info != null)
                {
                    table.AddRow(info.ID, info.FName, info.LName, info.DOB, info.Phone_Number, info.CName, info.CStartDate, info.Course_Fees, info.SType);
                }
                else
                {
                    Console.WriteLine("No record found");
                }
            }
            table.Write();
            Console.WriteLine("****************Admission Info By Student ID**********************");

        }

        public static void SearchAdmissionDetailByCourse()
        {
            Console.WriteLine();
            string Course = ValidationClass.ValidCourseName("Enter Course Name", course);
            Console.WriteLine("****************Admission Info By Course**********************");
            var table = new ConsoleTable("ID", "First Name", "Last Name", "Date Of Birth", "Phone Number", "Course Name", "Start Date", "Course Fees", "Student_Type");
            if (course.Any())
            {
                var sInfo = std.Where(m => m.CName == Course);
                if (sInfo.Any())
                {
                    foreach (var info in sInfo)
                    {
                        table.AddRow(info.ID, info.FName, info.LName, info.DOB, info.Phone_Number, info.CName, info.CStartDate, info.Course_Fees, info.SType);
                    }
                }
                else
                {
                    Console.WriteLine("No record found");
                }
            }
            table.Write();
            Console.WriteLine("****************Admission Info By Course**********************");
        }

        public static void GetCourseList()
        {
            Console.WriteLine("****************Get Course List**********************");
            var table = new ConsoleTable("ID", "Course Name","Course Fees");
            if (course.Any())
            {
                foreach (var info in course)
                {
                    table.AddRow(info.cID, info.cName,info.Fees);
                }
            }
            else
            {
                Console.WriteLine("No record found");
            }
            table.Write();
        }

        public static void DeleteStudentById()
        {
            Console.WriteLine();
            string stfID = ValidationClass.CheckNullValue("Enter Student ID");
            var info = std.Where(m => m.ID == stfID);
            if (info.Any())
            {
                std.RemoveAll(m => m.ID == stfID);
                Console.WriteLine("Student info has been deleted.");
            }
            else
            {
                Console.WriteLine("Student info not found.");
            }
        }

        public static void DeleteExistingCourse()
        {
            Console.WriteLine();
            string courseID = ValidationClass.CheckNullValue("Enter Course ID");
            var info = course.Where(m => m.cID == courseID);
            if (info.Any())
            {
                course.RemoveAll(m => m.cID == courseID);
                Console.WriteLine("Course info has been deleted.");
            }
            else
            {
                Console.WriteLine("Course info not found.");
            }
        }

        public static void ChangeExistingCourse()
        {
            Console.WriteLine();
            string courseID = ValidationClass.CheckNullValue("Enter Course ID");
            var info = course.Where(m => m.cID == courseID);
            if (info.Any())
            {
                info.FirstOrDefault().cName = ValidationClass.CheckNullValue("Enter New Course Name");
                Console.WriteLine("Course info has been changed.");
            }
            else
            {
                Console.WriteLine("Course info not found.");
            }
        }

        public static void SearchCourseByName()
        {
            Console.WriteLine("****************Get Course List**********************");
            string cName = ValidationClass.CheckNullValue("Please enter course name");
            var table = new ConsoleTable("ID", "Course Name", "Course Fees");
            if (course.Any())
            {
                var info = course.Where(ls => ls.cName == cName).FirstOrDefault(); 
                if(info != null)
                {
                    table.AddRow(info.cID, info.cName, info.Fees);
                }
                else
                {
                    Console.WriteLine("No record found");
                }
            }
            else
            {
                Console.WriteLine("No record found");
            }
            table.Write();
        }

        #endregion
    }
}
