using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static AdmissionApp.Program;

namespace AdmissionApp
{
    public static class ValidationClass
    {
        public static string ValidCourseName(string Course, List<CourseInfo> objCourseList)
        {
            string output = "";
            bool matchCourse = true;
            do
            {
                Console.Write(Course + ": ");
                output = Console.ReadLine();
                var info = objCourseList.Where(m => m.cName.ToLower() == output.ToLower());
                if (info.Any())
                {
                    matchCourse = false;
                    return output;
                }
                else
                {
                    string message = "";
                    string existList = "";
                    foreach (var dl in objCourseList)
                    {
                        existList += " , " + dl.cName;
                    }
                    if (!string.IsNullOrEmpty(existList))
                    {
                        message = "Please choose from Course from list : " + existList + ". Or add a new Course";
                    }
                    else
                    {
                        message = "This Course is not exist. Please add new Course.";
                    }

                }

            } while (matchCourse);
            return output;
        }

        public static string CheckNullValue(string val)
        {
            string Result = "";
            do
            {
                Console.Write(val + ": ");
                Result = Console.ReadLine();
                if (string.IsNullOrEmpty(Result))
                {
                    Console.WriteLine("Empty input, please try again");
                }
            } while (string.IsNullOrEmpty(Result));
            return Result;
        }



        public static string ValidNumber(string Phone)
        {
            string output = "";
            do
            {
                Console.Write(Phone + ": ");
                output = Console.ReadLine();
                if (string.IsNullOrEmpty(output))
                {
                    Console.WriteLine("Empty input, please try again");
                }
                else if (!Regex.Match(output, @"^([0-9]{10})$").Success)
                {
                    Console.WriteLine("Empty enter phone number in 10 digits. eg : 1234567890");
                }
            } while (!Regex.Match(output, @"^([0-9]{10})$").Success);
            return output;
        }

        public static string ValidType(string input)
        {
            bool valid = true;
            string output = "";
            do
            {
                Console.Write(input + ": ");
                output = Console.ReadLine();
                if (string.IsNullOrEmpty(output))
                {
                    Console.WriteLine("Empty input, please try again");
                }
                else if (output.ToLower() == "part time" || output.ToLower() == "full time")
                {
                    valid = false;
                }
                else
                {
                    Console.WriteLine("Please enter part time or full time");
                }
            } while (valid);
            return output;
        }


        public static string ValidInputDate(string input)
        {
            bool valid = true;
            string output = "";
            do
            {
                DateTime dDate;
                Console.Write(input + ": ");
                output = Console.ReadLine();
                if (string.IsNullOrEmpty(output))
                {
                    Console.WriteLine("Empty input, please try again");
                }
                else if (DateTime.TryParse(output, out dDate))
                {
                    valid = false;
                }
                else
                {
                    Console.WriteLine("Please enter valid date of birth");
                }
            } while (valid);
            return output;
        }
    }
}
