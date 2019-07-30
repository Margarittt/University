using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    static class Operator
    {
        public static void ShowStudents(Dictionary<int, Universityy> ListOfUniversities)
        {
            foreach (KeyValuePair<int, Universityy> university in ListOfUniversities)
            {
                foreach (Faculty faculty in university.Value.GetFacultiesList().Values)
                {
                    foreach (Student sitem in faculty.GetStudentsList().Values)
                    {
                        sitem.Show();
                    }
                }
            }
        }

        public static void ShowFaculties(Dictionary<int, Universityy> ListOfUniversities)
        {
            foreach (KeyValuePair<int, Universityy> university in ListOfUniversities)
            {
                Console.WriteLine("Faculties of {0}", university.Value.Name);
                foreach (Faculty faculty in university.Value.GetFacultiesList().Values)
                {
                    faculty.Show();
                }
                Console.WriteLine(new string('-', 10));
            }
        }

        public static void ShowLecturers(Dictionary<int, Universityy> ListOfUniversities)
        {
            {
                foreach (KeyValuePair<int, Universityy> university in ListOfUniversities)
                {
                    foreach (Faculty faculty in university.Value.GetFacultiesList().Values)
                    {
                        Console.WriteLine("Lecturer/Lecturers of {0} of {1} faculty", university.Value.Name, faculty.Name);
                        foreach (Lecturer lecturer in university.Value.GetFaculty(faculty.Number).GetLecturiesList().Values)
                        {
                            lecturer.Show();
                        }
                        Console.WriteLine(new string('-', 10));
                    }
                }
            }

        }

        public static void ShowUniversities(Dictionary<int, Universityy> ListOfUniversities)
        {

            foreach (KeyValuePair<int, Universityy> university in ListOfUniversities)
            {
                university.Value.Show();
            }
        }
    }
}
