using System;
using System.Collections.Generic;

namespace University.Models
{
    static class UniversityServices
    {
        static public void AddUniversity(ref Dictionary<int, University> ListOfUniversities, 
                    ref Dictionary<int, Country> ListOfCountries, ref Dictionary<int, City> ListOfCities)
        {
            Console.WriteLine("Please enter the University name..");
            string Name = Console.ReadLine();
            Console.WriteLine("Please enter the Country ID where you want to add..");
            int CountryID = Int32.Parse(Console.ReadLine());
            if (ListOfCountries.ContainsKey(CountryID))
            {
                Console.WriteLine("Please enter the City ID where you want to add..");
                int CityID = Int32.Parse(Console.ReadLine());
                if (ListOfCountries[CountryID].Cities.ContainsKey(CityID))
                {
                    University university = new University();
                    university.Name = Name;
                    university.ID = ++University.Count;
                    university.City = ListOfCities[CityID];
                    university.Country = ListOfCountries[CountryID];
                    ListOfUniversities.Add(university.ID, university);
                    ListOfCountries[CountryID].Cities[CityID].Universities.Add(university.ID, university);
                }
                else
                {
                    Console.WriteLine("There is no City on this ID!");
                }
            }
            else
            {
                Console.WriteLine("There is no Country on this ID!");
            }
        }

        static public void GetUniversity(ref Dictionary<int, University> ListOfUniversities)
        {
            Console.WriteLine("Please enter the University's ID ․․");
            int ID = Int32.Parse(Console.ReadLine());
            if (ListOfUniversities.ContainsKey(ID))
            {
                Console.WriteLine("{0}-{1} {2},{3}",
                    ListOfUniversities[ID].ID, ListOfUniversities[ID].Name,
                    ListOfUniversities[ID].City.Name,ListOfUniversities[ID].Country.Name);
            }
            else
            {
                Console.WriteLine("There is no University on this ID!");
            }
        }

        static public void RemoveUniversity(ref Dictionary<int, University> ListOfUniversities)
        {
            Console.WriteLine("Please enter the University's ID․․");
            int ID = Int32.Parse(Console.ReadLine());
            if (ListOfUniversities.ContainsKey(ID))
            {
                ListOfUniversities[ID].City.Universities.Remove(ID);
                ListOfUniversities[ID].Country.Universities.Remove(ID);
                ListOfUniversities.Remove(ID);
            }
            else
            {
                Console.WriteLine("There is no University on this ID!");
            }
        }

        static public void UpdateUniversity(ref Dictionary<int, University> ListOfUniversities)
        {
            string NewName;
            Console.WriteLine("Please enter the University's ID․․");
            int UID = Int32.Parse(Console.ReadLine());
            if (ListOfUniversities.ContainsKey(UID))
            {
                Console.WriteLine("Please enter the new University's name..");
                NewName = Console.ReadLine();
                ListOfUniversities[UID].Name = NewName;
            }
            else
            {
                Console.WriteLine("There is no University on this ID!");
            }
        }

        public static void ShowUniversities(ref Dictionary<int, University> ListOfUniversities)
        {
            foreach (KeyValuePair<int, University> university in ListOfUniversities)
            {
                Console.WriteLine("{0}-{1} {2},{3}", university.Value.ID, 
                    university.Value.Name, university.Value.City.Name,university.Value.Country.Name);
            }
        }
    }
}
