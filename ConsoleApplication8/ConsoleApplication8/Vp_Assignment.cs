using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication8
{
    class Student
    {
        private string id;
        private string name;
        private string cgpa;
        private string semester;
        private string department;
        private string university;
        private string attendance;
        private int flag;
        Student[] _students;

        public Student()
        {
            id = "";
            name = "";
            cgpa = "";
            semester = "";
            department = "";
            university = "";
            attendance ="NIL";
            flag = 0;
        }
        public void checkId(Student obj)
        {
            for (int i = 0; i < _students.Length; i++)
            {
                if (_students[i].id == obj.id)
                {
                     obj.flag=0;
                }
                else
                {
                    obj.flag=1;
                }
            }
        }
        public void checkGpa(Student obj)
        {
           
            if (Convert.ToDouble(obj.cgpa)>4)
            {
                obj.flag = 0;
            }
            else
            {
                obj.flag = 1;
            }
            
        }
        public void checkDel(int k)
        {
            string ch = "n";
            header();
            studentPrint(k);
            Console.Write("Do you want to DELETE this Record:  (y/n) ");
            ch = Console.ReadLine();
            if (ch=="y"||ch=="Y")
            {
                flag = 1;
            }
            else
            {
                flag = 0;
            }
        }
        public void deleteRecord()
        {
            bool d = false;
            string del;
            int x=0;
            Console.Write("Enter the Id : ");
            del = Console.ReadLine();
            for (int i = 0; i < _students.Length; i++)
            {
                if (del == _students[i].id)
                {
                    d = true;
                    x = i;
                    checkDel(i);                  
                }               
            }
            if (d==false)
            {
                Console.WriteLine("Record not Found!");
            }
            if (flag == 1)
            {
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\umar\Data.txt", false))
                {
                    for (int i = 0; i < _students.Length; i++)
                    {
                        if (i != x)
                        {
                            file.WriteLine(_students[i].id);
                            file.WriteLine(_students[i].name);
                            file.WriteLine(_students[i].cgpa);
                            file.WriteLine(_students[i].semester);
                            file.WriteLine(_students[i].department);
                            file.WriteLine(_students[i].university);
                            file.WriteLine(_students[i].attendance);
                        }
                    }
                    file.Close();
                }
                Console.Clear();
                Console.WriteLine("\n\n\n\n\n\n\t\t\tRecord Deleted Successfully!");
            } 

        }
        public  void studentInput(Student obj)
        {
            Console.Write("Enter Id: ");
            obj.id = Console.ReadLine();
            checkId(obj);
            if (obj.flag==1)
            {
                Console.Write("Enter Name: ");
                obj.name = Console.ReadLine();
                Console.Write("Enter CGPA: ");
                obj.cgpa = Console.ReadLine();
                checkGpa(obj);
                if (obj.flag == 1)
                {
                    Console.Write("Enter Semester: ");
                    obj.semester = Console.ReadLine();
                    Console.Write("Enter Department: ");
                    obj.department = Console.ReadLine();
                    Console.Write("Enter University: ");
                    obj.university = Console.ReadLine();
                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"C:\umar\Data.txt", true))
                    {
                        file.WriteLine(obj.id);
                        file.WriteLine(obj.name);
                        file.WriteLine(obj.cgpa);
                        file.WriteLine(obj.semester);
                        file.WriteLine(obj.department);
                        file.WriteLine(obj.university);
                        file.WriteLine(obj.attendance);
                        file.Close();
                    }
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n\n\t\t\tRecord Added Successfully!");
                }
                else
                {
                    Console.WriteLine("CGPA Can not Exceed 4!");
                }
            }
            else
            {
                Console.WriteLine("Id Must be Unique!");
            }
        }
       
        public void topStudent()
        {
            double[] arr = new double[_students.Length];
            double temp;
            //double gpa;
            if (_students.Length>2)
            {
               for (int i = 0; i < _students.Length; i++)
               {
                    arr[i] = Convert.ToDouble(_students[i].cgpa);
               }
            }
            else
            {
                Console.WriteLine("Number of Students are Less than 3!");
            }
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i]<arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            header();
            for (int i = 0; i <3; i++)
            {
                printToppers(arr, i);

            }
        }
        public void printToppers(Double[] arr,int j)
        {         
            for (int i = 0; i < _students.Length; i++)
            {
                if (Convert.ToDouble(_students[i].cgpa)==arr[j])
                {
                    studentPrint(i);
                }
            }
        }
        public void veiwAttendance()
        {
            Console.WriteLine(" _____________________________________________________________________________");
            Console.WriteLine("                                 Students Attendance                           ");
            Console.WriteLine(" _____________________________________________________________________________");
            Console.WriteLine("\n\n\t\t _________________________________");
            Console.WriteLine("\t\t|Id   |    Name   |   Attendance  |");
            Console.WriteLine("\t\t|_____|___________|_______________|");
            for (int i = 0; i < _students.Length; i++)
            {
                studentPrintAttendance(_students, i);
            }
        }
        public void markAttendance()
        {
            Console.WriteLine(" _____________________________________________________________________________");
            Console.WriteLine("                                 Marking Attendance                           ");
            Console.WriteLine(" _____________________________________________________________________________");
            Console.WriteLine("\n\n\t\t __________________________________");
            Console.WriteLine("\t\t|Id   |    Name   |   Attendance  |");
            Console.WriteLine("\t\t|_____|___________|_______________|");
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\umar\Data.txt", false))
            {
                for (int i = 0; i < _students.Length; i++)
                {
                    //Console.Write(_students[i].id + "       " + _students[i].name + "       ");
                    Console.Write("\t\t|{0,3:G}  |", _students[i].id);
                    Console.Write("{0,9:G}  |    ", _students[i].name);
                    _students[i].attendance = Console.ReadLine();
                    Console.WriteLine("\t\t|_____|___________|_______________|");
                    file.WriteLine(_students[i].id);
                    file.WriteLine(_students[i].name);
                    file.WriteLine(_students[i].cgpa);
                    file.WriteLine(_students[i].semester);
                    file.WriteLine(_students[i].department);
                    file.WriteLine(_students[i].university);
                    file.WriteLine(_students[i].attendance);
                }
                file.Close();

            }
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\t\t\tAttendance Marked Successfully!");

        }
        public void header()
        {
            Console.Clear();
            Console.WriteLine(" _____________________________________________________________________________");
            Console.WriteLine("                                 Students Record                           ");
            Console.WriteLine(" _____________________________________________________________________________");
            Console.WriteLine(" _____________________________________________________________________________");
            Console.WriteLine("| Id  | Name   | CGPA   |  Semester | Department | University   |  Attendance |");
            Console.WriteLine("|_____|________|________|___________|____________|______________|_____________|");
        }
        public void studentSearch()
        {
            int option;
            bool flag = false;
            Console.WriteLine("Press one of the following: ");
            Console.WriteLine("\t\t1. For Search By Id");
            Console.WriteLine("\t\t2. For Search By Name");
            Console.WriteLine("\t\t3. For Display Records");
            Console.Write(" Your Choice: ");
            option = Convert.ToInt32(Console.ReadLine());
            if (option==1)
            {
                Console.Write("Enter the Id of Student to Search : ");
                string tempId = Console.ReadLine();
                header();
                for (int i = 0; i < _students.Length; i++)
                {
                    if (_students[i].id == tempId)
                    {                        
                        studentPrint(i);
                        flag = true;
                    }                    
                }
                if (flag==false)
                {
                    Console.WriteLine("Record Not Found!");
                }
            }
            else if (option == 2)
            {
                Console.Write("Enter the Name of Student to Search : ");
                string tempName = Console.ReadLine();
                header();
                for (int i = 0; i < _students.Length; i++)
                {
                    if (_students[i].name == tempName)
                    {
                        flag = true;
                        studentPrint( i);
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Record Not Found!");
                }
            }
            else if (option == 3)
            {
                header();
                for (int i = 0; i < _students.Length; i++)
                {
                      studentPrint( i);
                }
            }
            else
            {
                Console.WriteLine("Invalid Input!");
            }
            
        }
        public void studentPrintAttendance(Student[] arr,int i)
        {
            //Console.WriteLine(arr[i].id + "       " + arr[i].name + "       " + arr[i].attendance);
            Console.Write("\t\t|{0,3:G}  |", _students[i].id);
            Console.Write("{0,9:G}  |    ", _students[i].name);
            Console.WriteLine("{0,7:G}    |", _students[i].attendance);
            Console.WriteLine("\t\t|_____|___________|_______________|");
        }
        public void studentPrint(int i)
        {
            Console.Write("|{0,3:G}  |", _students[i].id);
            Console.Write("{0,7:G} |", _students[i].name);
            Console.Write("{0,6:G}  |", _students[i].cgpa);
            Console.Write("{0,7:G}    |", _students[i].semester);
            Console.Write("{0,10:G}  |", _students[i].department);
            Console.Write("{0,10:G}    |", _students[i].university);
            Console.WriteLine("{0,10:G}   |", _students[i].attendance);
            Console.WriteLine("|_____|________|________|___________|____________|______________|_____________|");

            // Console.WriteLine(_students[i].id + "       " + _students[i].name + "       " + _students[i].cgpa + "       " + _students[i].semester + "        " + _students[i].department + "        " + _students[i].university + "         " + _students[i].attendance);           
        }
       
        public void reading()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\umar\Data.txt");
            int noOfStudents = lines.Length / 6;
            int index = 0;
            Console.WriteLine(lines.Length);
            Student[] students = new Student[noOfStudents];
            for (int i = 0; i < noOfStudents; i++)
            {
                students[i] = new Student();
                students[i].id = lines[index];
                index++;
                students[i].name = lines[index];
                index++;
                students[i].cgpa = lines[index];
                index++;
                students[i].semester = lines[index];
                index++;
                students[i].department = lines[index];
                index++;
                students[i].university = lines[index];
                index++;
                students[i].attendance = lines[index];
                if (index<lines.Length)
                {                    
                    index++;
                }                
            }            
            _students=students;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            Student std = new Student();
          while(true)
          {


            Console.Clear();
            Console.WriteLine(" _____________________________________________________________________________");
            Console.WriteLine("  Umar Farooq                        VP Assignment             01-131172-030  ");
            Console.WriteLine(" _____________________________________________________________________________");
            Console.WriteLine("Press one of the Following: ");
            Console.WriteLine("\t\t1. For Add Record");
            Console.WriteLine("\t\t2. For Search Record");
            Console.WriteLine("\t\t3. For Delete Record");
            Console.WriteLine("\t\t4. For Top 3 Student");
            Console.WriteLine("\t\t5. For Mark Attendence");
            Console.WriteLine("\t\t6. For Veiw Attendence");
            Console.WriteLine("\t\t7. For Exit");
            Console.Write(" Your Choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
            std.reading();
            Console.Clear();
            switch (choice)
            {
               case 1:
                   {
                            Console.WriteLine(" _____________________________________________________________________________");
                            Console.WriteLine("                                  Add Record                                ");
                            Console.WriteLine(" _____________________________________________________________________________");
                            std.studentInput(std);
                       break;
                   }
               case 2:
                   {
                            Console.WriteLine(" _____________________________________________________________________________");
                            Console.WriteLine("                                  Search Record                           ");
                            Console.WriteLine(" _____________________________________________________________________________");
                            std.studentSearch();
                        break;
                   }
               case 3:
                   {
                            Console.WriteLine(" _____________________________________________________________________________");
                            Console.WriteLine("                                   Detele Record                              ");
                            Console.WriteLine(" _____________________________________________________________________________");
                            std.deleteRecord();
                       break;
                   }
               case 4:
                   {
                            Console.WriteLine(" _____________________________________________________________________________");
                            Console.WriteLine("                                   Top 3 Students                              ");
                            Console.WriteLine(" _____________________________________________________________________________");
                            std.topStudent();
                       break;
                   }
               case 5:
                   {
                        std.markAttendance();
                       break;
                   }
               case 6:
                   {
                        std.veiwAttendance();
                       break;
                   }
               case 7:
                   {
                            System.Environment.Exit(1);
                       break;
                   }


                    default:
                   {
                            Console.WriteLine("\n\n\n\n\t\t\tInvalid Input!");
                       break;
                   }
                      
             }
                Console.ReadKey();
            }
        }
       
    }
}
