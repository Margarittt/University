using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace University.Models
{
    static class CityServices
    {
        static public void AddCity(ref Dictionary<int, Country> ListOfCountries,ref Dictionary<int, City> ListOfCities)
        {  
            Console.WriteLine("Please enter the City name..");

            string Name = Console.ReadLine();
            bool allLetters;
            while(!(allLetters =Name.All(c => Char.IsLetter(c))))
            {
                Console.WriteLine("Name should contains only letters A-Z, a-z! Try again..");
                Name = Console.ReadLine();
            }
            Console.WriteLine("Please enter the Country's ID where you want to add..");
            var IDasStr = Console.ReadLine();
            int ID;
            while (!int.TryParse(IDasStr, out ID))
            {
                Console.WriteLine("This is not a number! Try again..");
                IDasStr = Console.ReadLine();
            }
            if (ListOfCountries.ContainsKey(ID))
            {
                City city = new City();
                city.Name = Name;
                city.ID = ++City.Count;
                city.Country = ListOfCountries[ID];
                ListOfCities.Add(city.ID, city);
                ListOfCountries[ID].SetCity(city.ID, city);
            }   
            else
            {
                Console.WriteLine("There is no Country on that ID!");
            }
        }

        static public void GetCity(ref Dictionary<int, City> ListOfCities)
        {
            Console.WriteLine("Please enter the City's ID ․․");
            var IDasStr = Console.ReadLine();
            int ID;
            while (!int.TryParse(IDasStr, out ID))
            {
                Console.WriteLine("This is not a number! Try again..");
                IDasStr = Console.ReadLine();
            }
            if (ListOfCities.ContainsKey(ID))
            {
                City city = ListOfCities[ID];
                Console.WriteLine("{0}-{1}", city.ID, city.Name,city.Country.Name);
            }
            else
            {
                Console.WriteLine("There is no City on this ID!");
            }
        }

        static public void RemoveCity(ref Dictionary<int, City> ListOfCities)
        {
            Console.WriteLine("Please enter the City's ID․․");
            var IDasStr = Console.ReadLine();
            int ID;
            while (!int.TryParse(IDasStr, out ID))
            {
                Console.WriteLine("This is not a number! Try again..");
                IDasStr = Console.ReadLine();
            }
            if (ListOfCities.ContainsKey(ID))
            {
                ListOfCities.Remove(ID);
            }
            else
            {
                Console.WriteLine("There is no City on this ID!");
            }
        }

        static public void UpdateCity(ref Dictionary<int, City> ListOfCities)
        {
            string NewName;
            Console.WriteLine("Please enter the City's ID you want to change․․");
            var CIDasStr = Console.ReadLine();
            int CID;
            while (!int.TryParse(CIDasStr, out CID))
            {
                Console.WriteLine("This is not a number! Try again..");
                CIDasStr = Console.ReadLine();
            }
            if (ListOfCities.ContainsKey(CID))
            {
                Console.WriteLine("Please enter the new City's name..");
                NewName = Console.ReadLine();
                bool allLetters;
                while (!(allLetters = NewName.All(c => Char.IsLetter(c))))
                {
                    Console.WriteLine("Name should contains only letters A-Z, a-z! Try again..");
                    NewName = Console.ReadLine();
                }
                ListOfCities[CID].Name = NewName;
            }
            else
            {
                Console.WriteLine("There is no City on this ID!");
            }
        }

        public static void ShowCities(ref Dictionary<int, City> ListOfCities)
        {
            foreach (KeyValuePair<int, City> city in ListOfCities)
            {
                Console.WriteLine("{0}-{1}, {2}", city.Value.ID, city.Value.Name, city.Value.Country.Name);
            }
        }
    }
}
