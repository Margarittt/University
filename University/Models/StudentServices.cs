using System;
using System.Collections.Generic;

namespace University.Models
{
    static class StudentsServices
    {
        static public void AddStudent(ref Dictionary<int, University> ListOfUniversities, ref Dictionary<int, Student> ListOfStudents)
        {
            Console.WriteLine("Please enter the student name..");
            string Name = Console.ReadLine();
            Console.WriteLine("Please enter the University ID where you want to add..");
            int UID = Int32.Parse(Console.ReadLine());
            if (ListOfUniversities.ContainsKey(UID))
            {
                Console.WriteLine("Please enter the Faculty ID where you want to add..");
                int FID = Int32.Parse(Console.ReadLine());
                if (ListOfUniversities[UID].Faculties.ContainsKey(FID))
                {
                    Student student = new Student();
                    student.Name = Name;
                    student.ID = ++Student.Count;
                    student.University = ListOfUniversities[UID];
                    student.Faculty = ListOfUniversities[UID].GetFaculty(FID);
                    ListOfUniversities[UID].SetStudent(student.ID, student);
                    ListOfUniversities[UID].GetFaculty(FID).SetStudent(student.ID, student);
                    ListOfStudents.Add(student.ID, student);
                }
                else
                {
                    Console.WriteLine("There is no Faculty on this ID!");
                }
            }
            else
            {
                Console.WriteLine("There is no University on this ID!");
            }
        }

        static public void GetStudent(ref Dictionary<int, Student> ListOfStudents)
        {
            Console.WriteLine("Please enter the Student's ID ․․");
            int ID = Int32.Parse(Console.ReadLine());
            if (ListOfStudents.ContainsKey(ID))
            {
                Student student = ListOfStudents[ID];
                Console.WriteLine("{0}-{1} University of {2},{3},{4} Faculty of {5}",
                                student.ID, student.Name, student.University.Name,
                                    student.University.Country.Name, student.University.City.Name, student.Faculty.Name);
            }
            else
            {
                Console.WriteLine("There is no student on this ID!");
            }
        }

        static public void RemoveStudent(ref Dictionary<int, Student> ListOfStudents)
        {
            Console.WriteLine("Please enter the student's ID․․");
            int ID = Int32.Parse(Console.ReadLine());
            if (ListOfStudents.ContainsKey(ID))
            {
                ListOfStudents.Remove(ID);
                ListOfStudents[ID].University.Students.Remove(ID);
                ListOfStudents[ID].Faculty.Students.Remove(ID);
            }
            else
            {
                Console.WriteLine("There is no student on this ID!");
            }
        }

        static public void UpdateStudent(ref Dictionary<int, Student> ListOfStudents)
        {
            string NewName = Console.ReadLine();
            Console.WriteLine("Please enter the Students's ID․․");
            int SID = Int32.Parse(Console.ReadLine());
            if (ListOfStudents.ContainsKey(SID))
            {
                Console.WriteLine("Please enter the new student's name..");
                ListOfStudents[SID].Name = NewName;
                ListOfStudents[SID].University.GetStudent(SID).Name = NewName;
                ListOfStudents[SID].Faculty.GetStudent(SID).Name = NewName;
            }

            else
            {
                Console.WriteLine("There is no student on this ID!");
            }
        }

        public static void StudentsOfThisUniversity(ref Dictionary<int, University> ListOfUniversities)
        {
            int ID;
            Console.WriteLine("Please enter the University ID..");
            ID = Int32.Parse(Console.ReadLine());
            if (ListOfUniversities.ContainsKey(ID))
            {
                foreach (KeyValuePair<int, Student> student in ListOfUniversities[ID].Students)
                {
                    Console.WriteLine("{0}-{1} Faculty of {2}-{3}",
                        student.Value.ID, student.Value.Name, student.Value.Faculty.ID,student.Value.Faculty.Name);
                }
            }
        }

        public static void StudentsOfThisFaculty(ref Dictionary<int, Faculty> ListOfFaculties)
        {
            int ID;
            Console.WriteLine("Please enter the Faculty ID..");
            ID = Int32.Parse(Console.ReadLine());
            if (ListOfFaculties.ContainsKey(ID))
            {
                foreach (KeyValuePair<int, Student> student in ListOfFaculties[ID].Students)
                {
                    Console.WriteLine("{0}-{1} University of {2} {3},{4}",
                        student.Value.ID, student.Value.Name, student.Value.University.Name,
                        student.Value.University.City.Name, student.Value.University.Country.Name);
                }
            }
        }
    }
}

