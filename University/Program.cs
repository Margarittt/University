using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    class Program
    {

        static void Main(string[] args)
        {
            string InputSymbol;

            Faculty faculty = new Faculty();
            faculty.Name = "Informatics";
            faculty.Number = 1;

            Universityy university = new Universityy();
            university.Name = "NPUA";
            university.Number = 1;
            university.SetFaculty(faculty.Number, faculty);
            university.FacultiesCount++;

            Student student = new Student();
            student.Name = "Margarit Safaryan";
            student.Number = 1;
            student.Faculty = faculty;
            student.University = university;

            Dictionary<int, Universityy> ListOfUniversities = new Dictionary<int, Universityy>();
            ListOfUniversities.Add(++Universityy.Count, university);

            Console.WriteLine("1a: . .  Add new University\n" +
                              "1b: . .  Get University\n" +
                              "1c: . .  Delete University\n" +
                              "1d: . .  Update University\n");
            Console.WriteLine("2a: . .  Add new Faculty\n" +
                              "2b: . .  Get Faculty\n" +
                              "2c: . .  Delete Faculty\n" +
                              "2d: . .  Update Faculty\n");
            Console.WriteLine("3a: . .  Add new Lecturer\n" +
                              "3b: . .  Get Lecturer\n" +
                              "3c: . .  Delete Lecturer\n" +
                              "3d: . .  Update Lecturer\n");
            Console.WriteLine("4a: . .  Add new Student\n" +
                              "4b: . .  Get Student\n" +
                              "4c: . .  Delete Student\n" +
                              "4d: . .  Update Student\n");
            Console.WriteLine("{0}Help{1}\n", new string('-', 10), new string('-', 10));

            Console.WriteLine("1h: . .  Show Universities\n" +
                              "2h: . .  Show Faculties\n" +
                              "3h: . .  Show Lecturers\n" +
                              "4h: . .  Show Students\n" +
                              "Press q to exit:․․\n");

            do
            {
                InputSymbol = Console.ReadLine();
                switch (InputSymbol)
                {
                    case "1a":
                        Console.WriteLine("Please enter the name of the new university..");
                        string InUniversity = Console.ReadLine();
                        Universityy university1 = new Universityy();
                        university1.Name = InUniversity;
                        university1.Number = ++Universityy.Count;
                        ListOfUniversities.Add(university1.Number, university1);
                        break;
                    case "1b":
                        Console.WriteLine("Please enter the number of the University․․");
                        int uNumber = Int32.Parse(Console.ReadLine());
                        if (ListOfUniversities.ContainsKey(uNumber))
                        {
                            Console.WriteLine(ListOfUniversities[uNumber].Name);
                        }
                        else
                        {
                            Console.WriteLine("There is no University in the given number");
                        }
                        break;
                    case "1c":
                        Console.WriteLine("Please enter the deleted number of the university․․");
                        int DelNumber = Int32.Parse(Console.ReadLine());
                        if (ListOfUniversities.ContainsKey(DelNumber))
                        {
                            ListOfUniversities.Remove(DelNumber);

                        }
                        else
                        {
                            Console.WriteLine("There is no University in the given number");
                        }
                        break;
                    case "1d":
                        string NewName;
                        Console.WriteLine("Please enter the updated number of the University․․");
                        int UpdNumber = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the new name of the University..");
                        NewName = Console.ReadLine();
                        if (ListOfUniversities.ContainsKey(UpdNumber))
                        {
                            ListOfUniversities[UpdNumber].Name = NewName;

                        }
                        else
                        {
                            Universityy NewUniversity = new Universityy();
                            NewUniversity.Name = NewName;
                            NewUniversity.Number = UpdNumber;
                            ListOfUniversities.Add(UpdNumber, NewUniversity);
                        }
                        break;
                    case "2a":
                        int k = 0;
                        int InUniverNumber;
                        string InFacultyName;
                        Console.WriteLine("Please enter the name of new the Faculty..");
                        InFacultyName = Console.ReadLine();
                        Console.WriteLine("Please enter the number of  the University where you are want to add..");
                        InUniverNumber = Int32.Parse(Console.ReadLine());
                        if (ListOfUniversities.ContainsKey(InUniverNumber))
                        {
                            Faculty faculty1 = new Faculty();
                            faculty1.Name = InFacultyName;
                            k = ++ListOfUniversities[InUniverNumber].FacultiesCount;
                            ListOfUniversities[InUniverNumber].SetFaculty(k, faculty1);
                            faculty1.Number = k;

                        }
                        else
                        {
                            Console.WriteLine("There is no University in the given number");
                        }
                        break;
                    case "2b":
                        bool m = false;
                        Console.WriteLine("Please enter the number of the Faculty․․");
                        int fNumber = Int32.Parse(Console.ReadLine());
                        for (int Gnum = 1; Gnum <= ListOfUniversities.Count; Gnum++)
                        {
                            if (ListOfUniversities.ContainsKey(Gnum))
                            {
                                if (ListOfUniversities[Gnum].GetFacultiesList().ContainsKey(fNumber))
                                {

                                    for (int val = 1; val <= ListOfUniversities[Gnum].GetFacultiesList().Count; val++)
                                    {
                                        if (ListOfUniversities[Gnum].GetFacultiesList().ContainsKey(val))
                                        {
                                            if (fNumber == ListOfUniversities[Gnum].GetFacultiesList()[val].Number)
                                            {
                                                m = true;
                                                Console.WriteLine("{1} - {0} ({2} University)", ListOfUniversities[Gnum].GetFaculty(val).Name, fNumber, ListOfUniversities[Gnum].Name);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (m == false)
                        {
                            Console.WriteLine("There is no Faculty here!");
                        }
                        break;
                    case "2c":
                        Console.WriteLine("Please enter the deleted number of the Faculty․․");
                        int DelFacultyNumber = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the University number from where it will be erased․․");
                        int UNumber = Int32.Parse(Console.ReadLine());
                        if (ListOfUniversities.ContainsKey(UNumber))
                        {
                            if (ListOfUniversities[UNumber].GetFacultiesList().ContainsKey(DelFacultyNumber))
                            {
                                ListOfUniversities[UNumber].GetFacultiesList().Remove(DelFacultyNumber);

                            }
                            else
                            {
                                Console.WriteLine("There is no Faculty in the given number");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no University in the given number");
                        }
                        break;
                    case "2d":
                        string NewFacultyName;
                        Console.WriteLine("Please enter the updated number of the Faculty․․");
                        int UpdFacultyNumber = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the University number from where it will be updated․․");
                        int UpdUniverNumber = Int32.Parse(Console.ReadLine());
                        if (ListOfUniversities.ContainsKey(UpdUniverNumber))
                        {
                            Console.WriteLine("Please enter the name of the Faculty..");
                            NewFacultyName = Console.ReadLine();
                            if (ListOfUniversities[UpdUniverNumber].GetFacultiesList().ContainsKey(UpdFacultyNumber))
                            {
                                ListOfUniversities[UpdUniverNumber].GetFacultiesList()[UpdFacultyNumber].Name = NewFacultyName;
                            }
                            else
                            {
                                Faculty faculty2 = new Faculty();
                                faculty2.Name = NewFacultyName;
                                ListOfUniversities[UpdUniverNumber].SetFaculty(UpdFacultyNumber, faculty2);
                                faculty2.Number = UpdFacultyNumber;
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no University in " +
                                                            "the given number!");
                        }
                        break;
                    case "3a":
                        k = 0;
                        Console.WriteLine("Please enter the name of the Lecturer..");
                        string InLectName = Console.ReadLine();
                        Console.WriteLine("Please enter the number of  the " +
                                                       "university where you are want to add lecturer");
                        int UniverNumb = Int32.Parse(Console.ReadLine());
                        if (ListOfUniversities.ContainsKey(UniverNumb))
                        {
                            Console.WriteLine("Please enter the number of the Faculty " +
                                                            "where you are want to add lecturer");
                            int FacultyNumb = Int32.Parse(Console.ReadLine());
                            if (ListOfUniversities[UniverNumb].GetFacultiesList().ContainsKey(FacultyNumb))
                            {
                                Lecturer lecturer1 = new Lecturer();
                                lecturer1.Name = InLectName;
                                k = ++ListOfUniversities[UniverNumb].GetFaculty(FacultyNumb).LecturersCount;
                                lecturer1.Number = k;
                                ListOfUniversities[UniverNumb].GetFaculty(FacultyNumb).SetLecturer(lecturer1);
                            }
                            else
                            {
                                Console.WriteLine("There is no Faculty in the given number!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no University in the given number!");
                        }
                        break;
                    case "3b":
                        bool t = false;
                        Console.WriteLine("Please enter the Lectuerer's number ․․");
                        int LectNumber = Int32.Parse(Console.ReadLine());
                        for (int Gnum = 1; Gnum <= ListOfUniversities.Count; Gnum++)
                        {
                            if (ListOfUniversities.ContainsKey(Gnum))
                            {
                                for (int val = 1; val <= ListOfUniversities[Gnum].GetFacultiesList().Count; val++)
                                {
                                    if (ListOfUniversities[Gnum].GetFacultiesList().ContainsKey(val))
                                    {
                                        for (int lval = 1; lval <= ListOfUniversities[Gnum].GetFaculty(val).GetLecturiesList().Count; lval++)
                                        {
                                            if (ListOfUniversities[Gnum].GetFaculty(val).GetLecturiesList().ContainsKey(lval))
                                            {
                                                if (LectNumber == ListOfUniversities[Gnum].GetFaculty(val).GetLecturer(lval).Number)
                                                {
                                                    Console.WriteLine("{0} - Lecturer of {1} University of the {2} faculty",
                                                               ListOfUniversities[Gnum].GetFaculty(val).GetLecturer(lval).Name, ListOfUniversities[Gnum].Name, ListOfUniversities[Gnum].GetFaculty(val).Name);
                                                    t = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (t == false)
                        {
                            Console.WriteLine("There is no lecturer on that number");
                        }
                        break;
                    case "3c":
                        Console.WriteLine("Please enter the lecturer's number you want to remove․․");
                        int DelLectNumber = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the university number from where it will be erased․․");
                        int UNumb = Int32.Parse(Console.ReadLine());
                        if (ListOfUniversities.ContainsKey(UNumb))
                        {
                            Console.WriteLine("Please enter the faculty number from where it will be erased․․");
                            int FNumb = Int32.Parse(Console.ReadLine());
                            if (ListOfUniversities[UNumb].GetFacultiesList().ContainsKey(FNumb))
                            {
                                if (ListOfUniversities[UNumb].GetFaculty(FNumb).GetLecturiesList().ContainsKey(DelLectNumber))
                                {
                                    ListOfUniversities[UNumb].GetFaculty(FNumb).GetLecturiesList().Remove(DelLectNumber);
                                }
                                else
                                {
                                    Console.WriteLine("There is no lecturer on this number!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("There is no Faculty on this number!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no University on this number!");
                        }
                        break;
                    case "3d":
                        string NewLecturerName;
                        Console.WriteLine("Please enter the lecturer's updated number․․");
                        int UpdLecturerNumber = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the university number from where it will be updated․․");
                        int UpdStUNumber = Int32.Parse(Console.ReadLine());
                        if (ListOfUniversities.ContainsKey(UpdStUNumber))
                        {
                            Console.WriteLine("Please enter the Faculty number from where it will be updated․․");
                            int UpdFNumber = Int32.Parse(Console.ReadLine());
                            if (ListOfUniversities[UpdStUNumber].GetFacultiesList().ContainsKey(UpdFNumber))
                            {
                                Console.WriteLine("Please enter the new lecturer's name..");
                                NewLecturerName = Console.ReadLine();
                                if (ListOfUniversities[UpdStUNumber].GetFaculty(UpdFNumber).GetLecturiesList().ContainsKey(UpdLecturerNumber))
                                {
                                    ListOfUniversities[UpdStUNumber].GetFaculty(UpdFNumber).GetLecturer(UpdLecturerNumber).Name = NewLecturerName;
                                }
                                else
                                {
                                    Lecturer lecturer1 = new Lecturer();
                                    lecturer1.Name = NewLecturerName;
                                    lecturer1.Number = UpdLecturerNumber;
                                    ListOfUniversities[UpdStUNumber].GetFaculty(UpdFNumber).SetLecturer(lecturer1);
                                }
                            }
                            else
                            {
                                Console.WriteLine("There is no Faculty on this number!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no University on this number!");
                        }
                        break;
                    case "4a":
                        k = 0;
                        Console.WriteLine("Please enter the student name..");
                        string InStudent = Console.ReadLine();
                        Console.WriteLine("Please enter the University number where you want to add....");
                        int StUNumber = Int32.Parse(Console.ReadLine());
                        if (ListOfUniversities.ContainsKey(StUNumber))
                        {
                            Console.WriteLine("Please enter the Faculty number where you want to add..");
                            int StFacultyNum = Int32.Parse(Console.ReadLine());
                            if (ListOfUniversities[StUNumber].GetFacultiesList().ContainsKey(StFacultyNum))
                            {
                                Student student1 = new Student();
                                k = ++ListOfUniversities[StUNumber].GetFaculty(StFacultyNum).StudentsCount;
                                student1.Name = InStudent;
                                student1.Number = k;
                                student1.University = ListOfUniversities[StUNumber];
                                student1.Faculty = ListOfUniversities[StUNumber].GetFaculty(StFacultyNum);
                                ListOfUniversities[StUNumber].GetFaculty(StFacultyNum).SetStudent(student1);
                            }
                            else
                            {
                                Console.WriteLine("There is no Faculty on this number!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no University on this number!");
                        }
                        break;
                    case "4b":
                        t = false;
                        Console.WriteLine("Please enter the Students's number ․․");
                        int StudNumber = Int32.Parse(Console.ReadLine());
                        for (int Gnum = 1; Gnum <= ListOfUniversities.Count; Gnum++)
                        {
                            if (ListOfUniversities.ContainsKey(Gnum))
                            {
                                for (int val = 1; val <= ListOfUniversities[Gnum].GetFacultiesList().Count; val++)
                                {
                                    if (ListOfUniversities[Gnum].GetFacultiesList().ContainsKey(val))
                                    {
                                        for (int lval = 1; lval <= ListOfUniversities[Gnum].GetFaculty(val).GetStudentsList().Count; lval++)
                                        {
                                            if (ListOfUniversities[Gnum].GetFaculty(val).GetStudentsList().ContainsKey(lval))
                                            {
                                                if (StudNumber == ListOfUniversities[Gnum].GetFaculty(val).GetStudent(lval).Number)
                                                {
                                                    Console.WriteLine("{0} - Student of {1} University of the {2} faculty",
                                                               ListOfUniversities[Gnum].GetFaculty(val).GetStudent(lval).Name, ListOfUniversities[Gnum].Name, ListOfUniversities[Gnum].GetFaculty(val).Name);
                                                    t = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (t == false)
                        {
                            Console.WriteLine("There is no student on this number!");
                        }
                        break;
                    case "4c":
                        Console.WriteLine("Please enter the student's number you want to remove․․");
                        int DelStudNumber = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the university number from where it will be erased․․");
                        int StUNumb = Int32.Parse(Console.ReadLine());
                        if (ListOfUniversities.ContainsKey(StUNumb))
                        {
                            Console.WriteLine("Please enter the faculty number from where it will be erased․․");
                            int FNumb = Int32.Parse(Console.ReadLine());
                            if (ListOfUniversities[StUNumb].GetFacultiesList().ContainsKey(FNumb))
                            {
                                if (ListOfUniversities[StUNumb].GetFaculty(FNumb).GetStudentsList().ContainsKey(DelStudNumber))
                                {
                                    ListOfUniversities[StUNumb].GetFaculty(FNumb).GetStudentsList().Remove(DelStudNumber);
                                }
                                else
                                {
                                    Console.WriteLine("There is no student on this number!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("There is no Faculty on this number!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no University on this number!");
                        }
                        break;
                    case "4d":
                        string NewStudentName;
                        Console.WriteLine("Please enter the student's updated number․․");
                        int UpdStudentNumber = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the university number from where it will be updated․․");
                        int UpdtStUNumber = Int32.Parse(Console.ReadLine());
                        if (ListOfUniversities.ContainsKey(UpdtStUNumber))
                        {
                            Console.WriteLine("Please enter the Faculty number from where it will be updated․․");
                            int UpdFNumber = Int32.Parse(Console.ReadLine());
                            if (ListOfUniversities[UpdtStUNumber].GetFacultiesList().ContainsKey(UpdFNumber))
                            {
                                Console.WriteLine("Please enter the new student's name..");
                                NewStudentName = Console.ReadLine();
                                if (ListOfUniversities[UpdtStUNumber].GetFaculty(UpdFNumber).GetStudentsList().ContainsKey(UpdtStUNumber))
                                {
                                    ListOfUniversities[UpdtStUNumber].GetFaculty(UpdFNumber).GetStudent(UpdtStUNumber).Name = NewStudentName;
                                }
                                else
                                {
                                    Student srudent1 = new Student();
                                    srudent1.Name = NewStudentName;
                                    srudent1.Number = UpdtStUNumber;
                                    ListOfUniversities[UpdtStUNumber].GetFaculty(UpdFNumber).SetStudent(srudent1);
                                }
                            }
                            else
                            {
                                Console.WriteLine("There is no Faculty on this number!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no University on this number!");
                        }
                        break;
                    case "1h":
                        Operator.ShowUniversities(ListOfUniversities);
                        break;
                    case "2h":
                        Operator.ShowFaculties(ListOfUniversities);
                        break;
                    case "3h":
                        Operator.ShowLecturers(ListOfUniversities);
                        break;
                    case "4h":
                        Operator.ShowStudents(ListOfUniversities);
                        break;
                    default:
                        if (InputSymbol == "q") break;
                        else
                        {
                            Console.WriteLine("Please enter correct symbol");
                            break;
                        }
                }
            }
            while (InputSymbol != "q");
        }
    }
}
