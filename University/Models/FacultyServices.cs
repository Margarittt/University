using System;
using System.Collections.Generic;

namespace University.Models
{
    static class FacultyServices
    {
        static public void AddFaculty(ref Dictionary<int, University> ListOfUniversities, ref Dictionary<int, Country> ListOfCountries,
                     ref Dictionary<int, City> ListOfCities, ref Dictionary<int, Faculty> ListOfFaculty)
        {
            Console.WriteLine("Please enter the Faculty name..");
            string Name = Console.ReadLine();
            Console.WriteLine("Please enter the University ID where you want to add..");
            int ID = Int32.Parse(Console.ReadLine());
            if (ListOfUniversities.ContainsKey(ID))
            {
                Faculty faculty = new Faculty();
                faculty.Name = Name;
                faculty.ID = ++Faculty.Count;
                ListOfUniversities[ID].Faculties.Add(faculty.ID, faculty);
                ListOfFaculty.Add(faculty.ID, faculty);
            }
            else
            {
                Console.WriteLine("There is no University on this ID!");
            }
        }

        static public void GetFaculty(ref Dictionary<int, Faculty> ListOfFaculties)
        {
            Console.WriteLine("Please enter the Faculty's ID ․․");
            int ID = Int32.Parse(Console.ReadLine());
            if (ListOfFaculties.ContainsKey(ID))
            {
                Console.WriteLine("{0}-{1} {2} {3},{4}",
                    ListOfFaculties[ID].ID, ListOfFaculties[ID].Name,
                    ListOfFaculties[ID].University.Name, ListOfFaculties[ID].University.City.Name,
                    ListOfFaculties[ID].University.Country.Name);
            }
            else
            {
                Console.WriteLine("There is no Faculty on this ID!");
            }
        }

        static public void RemoveFaculty(ref Dictionary<int, Faculty> ListOfFaculties)
        {
            Console.WriteLine("Please enter the Faculty's ID․․");
            int ID = Int32.Parse(Console.ReadLine());
            if (ListOfFaculties.ContainsKey(ID))
            {
                ListOfFaculties.Remove(ID);
                ListOfFaculties[ID].University.Faculties.Remove(ID);
            }
            else
            {
                Console.WriteLine("There is no Faculty on this ID!");
            }
        }

        static public void UpdateFaculty(ref Dictionary<int, Faculty> ListOfFaculties)
        {
            string NewName;
            Console.WriteLine("Please enter the Faculty's ID․․");
            int FID = Int32.Parse(Console.ReadLine());
            if (ListOfFaculties.ContainsKey(FID))
            {
                NewName = Console.ReadLine();
                Console.WriteLine("Please enter the new Faculty's name..");
                ListOfFaculties[FID].Name = NewName;
            }
            else
            {
                Console.WriteLine("There is no Faculty on this ID!");
            }
        }

        public static void ShowFaculties(ref Dictionary<int, Faculty> ListOfFaculties)
        {
            foreach (KeyValuePair<int,Faculty> faculty in ListOfFaculties)
            {
                Console.WriteLine("{0}-{1} {2} {2},{3}", faculty.Value.ID,
                    faculty.Value.Name, faculty.Value.University.Name, 
                    faculty.Value.University.City.Name, faculty.Value.University.Country.Name);
            }
        }
    }
}
