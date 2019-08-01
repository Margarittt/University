using System;
using System.Collections.Generic;

namespace University.Models
{
    static class LecturerServices
    {
        static public void AddLecturer(ref Dictionary<int, University> ListOfUniversities,
                                                      ref Dictionary<int, Lecturer> ListOfLecturers)
        {
            Console.WriteLine("Please enter the lecturer name..");
            string Name = Console.ReadLine();
            Console.WriteLine("Please enter the University ID where you want to add..");
            int LID = Int32.Parse(Console.ReadLine());
            if (ListOfUniversities.ContainsKey(LID))
            {
                Console.WriteLine("Please enter the Faculty ID where you want to add..");
                int FID = Int32.Parse(Console.ReadLine());
                if (ListOfUniversities[LID].Faculties.ContainsKey(FID))
                {
                    Lecturer lecturer = new Lecturer();
                    lecturer.Name = Name;
                    lecturer.ID = ++Lecturer.Count;
                    lecturer.University = ListOfUniversities[LID];
                    lecturer.Faculty = ListOfUniversities[LID].GetFaculty(FID);
                    ListOfUniversities[LID].SetLecturer(lecturer.ID, lecturer);
                    ListOfUniversities[LID].GetFaculty(FID).SetLecturer(lecturer.ID, lecturer);
                    ListOfLecturers.Add(lecturer.ID, lecturer);
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

        static public void GetLecturer(ref Dictionary<int, Lecturer> ListOfLecturers)
        {
            Console.WriteLine("Please enter the Lecturer's ID ․․");
            int ID = Int32.Parse(Console.ReadLine());
            if (ListOfLecturers.ContainsKey(ID))
            {
                Lecturer lecturer = ListOfLecturers[ID];
                Console.WriteLine("{0}-{1} University of {2},{3},{4} Faculty of {5}",
                                lecturer.ID, lecturer.Name, lecturer.University.Name,
                                    lecturer.University.Country.Name, lecturer.University.City.Name, lecturer.Faculty.Name);
            }
            else
            {
                Console.WriteLine("There is no Faculty on this ID!");
            }
        }

        static public void RemoveLecturer(ref Dictionary<int, Lecturer> ListOfLecturers)
        {
            Console.WriteLine("Please enter the lecturer's ID․․");
            int ID = Int32.Parse(Console.ReadLine());
            if (ListOfLecturers.ContainsKey(ID))
            {
                ListOfLecturers.Remove(ID);
                ListOfLecturers[ID].University.Lecturers.Remove(ID);
                ListOfLecturers[ID].Faculty.Lecturers.Remove(ID);
            }
            else
            {
                Console.WriteLine("There is no Lecturer on this ID!");
            }
        }

        static public void UpdateLecturer(ref Dictionary<int, Lecturer> ListOfLecturers)
        {
            string NewName;
            Console.WriteLine("Please enter the Students's ID․․");
            int LID = Int32.Parse(Console.ReadLine());
            if (ListOfLecturers.ContainsKey(LID))
            {
                Console.WriteLine("Please enter the new lecturer's name..");
                NewName = Console.ReadLine();
                ListOfLecturers[LID].Name = NewName;
                ListOfLecturers[LID].University.GetLecturer(LID).Name = NewName;
                ListOfLecturers[LID].Faculty.GetLecturer(LID).Name = NewName;
            }
            else
            {
                Console.WriteLine("There is no lecturer on this ID!");
            }
        }

        public static void LecturersOfThisUniversity(ref Dictionary<int, University> ListOfUniversities)
        {
            int ID;
            Console.WriteLine("Please enter the University ID..");
            ID = Int32.Parse(Console.ReadLine());
            if (ListOfUniversities.ContainsKey(ID))
            {
                foreach (KeyValuePair<int, Lecturer> lecturer in ListOfUniversities[ID].Lecturers)
                {
                    Console.WriteLine("{0}-{1} Faculty of {2}-{3}",
                        lecturer.Value.ID, lecturer.Value.Name, lecturer.Value.Faculty.ID, lecturer.Value.Faculty.Name);
                }
            }
        }

        public static void LecturersOfThisFaculty(ref Dictionary<int, Faculty> ListOfFaculties)
        {
            int ID;
            Console.WriteLine("Please enter the Faculty ID..");
            ID = Int32.Parse(Console.ReadLine());
            if (ListOfFaculties.ContainsKey(ID))
            {
                foreach (KeyValuePair<int, Lecturer> lecturers in ListOfFaculties[ID].Lecturers)
                {
                    Console.WriteLine("{0}-{1} University of {2} {3},{4}",
                        lecturers.Value.ID, lecturers.Value.Name, lecturers.Value.University.Name, 
                        lecturers.Value.University.City.Name,lecturers.Value.University.Country.Name);
                }
            }
        }
    }
}
