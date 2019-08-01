using System;
using System.Collections.Generic;
using System.Linq;

namespace University.Models
{
    static class UniversityServices
    {
        public static bool IsUpper(this string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsLower(value[i]))
                {
                    return false;
                }
            }
            return true;
        }
        static public void AddUniversity(ref Dictionary<int, University> ListOfUniversities, 
                    ref Dictionary<int, Country> ListOfCountries, ref Dictionary<int, City> ListOfCities)
        {
            Console.WriteLine("Please enter the University name..");
            string Name = Console.ReadLine();
            bool allLetters;
            while (!(allLetters = Name.All(c => Char.IsLetter(c))) || !(Name.IsUpper()))
            {
                Console.WriteLine("Invalid name format! Try again..");
                Name = Console.ReadLine();
            }
  
                Console.WriteLine("Please enter the City ID where you want to add University..");
                var CityIDasStr = Console.ReadLine();
                int CityID;
                while (!int.TryParse(CityIDasStr, out CityID))
                {
                    Console.WriteLine("This is not a number! Try again..");
                    CityIDasStr = Console.ReadLine();
                }
            if (ListOfCities.ContainsKey(CityID))
            {
                bool z = true;
                foreach (var item in ListOfCities[CityID].Universities)
                {
                    if (item.Value.Name == Name)
                    {
                        z = false;
                    }
                }
                if (z)
                {
                    University university = new University();
                    university.Name = Name;
                    university.ID = ++University.Count;
                    university.City = ListOfCities[CityID];
                    university.Country = ListOfCities[CityID].Country;
                    ListOfUniversities.Add(university.ID, university);
                    ListOfCities[CityID].Universities.Add(university.ID, university);
                }
                else
                {
                    Console.WriteLine("The City is  already exists in that Country!!! Try again.."); 
                }
            }
            else
            {
                Console.WriteLine("There is no City on this ID!");
            }
            }
           
        

        static public void GetUniversity(ref Dictionary<int, University> ListOfUniversities)
        {
            Console.WriteLine("Please enter the University's ID ․․");
            var IDasStr = Console.ReadLine();
            int ID;
            while (!int.TryParse(IDasStr, out ID))
            {
                Console.WriteLine("This is not a number! Try again..");
                IDasStr = Console.ReadLine();
            }
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
            var IDasStr = Console.ReadLine();
            int ID;
            while (!int.TryParse(IDasStr, out ID))
            {
                Console.WriteLine("This is not a number! Try again..");
                IDasStr = Console.ReadLine();
            }
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
            var UIDasStr = Console.ReadLine();
            int UID;
            while (!int.TryParse(UIDasStr, out UID))
            {
                Console.WriteLine("This is not a number! Try again..");
                UIDasStr = Console.ReadLine();
            }
            if (ListOfUniversities.ContainsKey(UID))
            {
                Console.WriteLine("Please enter the new University's name..");
                NewName = Console.ReadLine();
                bool allLetters;
                while (!(allLetters = NewName.All(c => Char.IsLetter(c))))
                {
                    Console.WriteLine("Name should contains only letters A-Z, a-z! Try again..");
                    NewName = Console.ReadLine();
                }
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
