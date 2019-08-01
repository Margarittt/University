using System;
using System.Collections.Generic;

namespace University.Models
{
    static class CountryServices
    {
        static public void AddCountry(ref Dictionary<int, Country> ListOfCountries)
        {
            Console.WriteLine("Please enter the Country name..");
            string Name = Console.ReadLine();
            Country country = new Country();
            country.Name = Name;
            country.ID = ++Country.Count;
            ListOfCountries.Add(country.ID, country);
        }

        static public void GetCountry(ref Dictionary<int, Country> ListOfCountries)
        {
            Console.WriteLine("Please enter the Country's ID ․․");
            int ID = Int32.Parse(Console.ReadLine());
            if (ListOfCountries.ContainsKey(ID))
            {
                Country country = ListOfCountries[ID];
                Console.WriteLine("{0}-{1}", country.ID, country.Name);
            }
            else
            {
                Console.WriteLine("There is no Country on this ID!");
            }
        }

        static public void RemoveCountry(ref Dictionary<int, Country> ListOfCountries)
        {
            Console.WriteLine("Please enter the Country's ID․․");
            int ID = Int32.Parse(Console.ReadLine());
            if (ListOfCountries.ContainsKey(ID))
            {
                ListOfCountries.Remove(ID);              
            }
            else
            {
                Console.WriteLine("There is no Country on this ID!");
            }
        }

        static public void UpdateCountry(ref Dictionary<int, Country> ListOfCountries)
        {
            string NewName; 
            Console.WriteLine("Please enter the Country's ID․․");
            int SID = Int32.Parse(Console.ReadLine());
            if (ListOfCountries.ContainsKey(SID))
            {
                Console.WriteLine("Please enter the new Country's name..");
                NewName = Console.ReadLine();
                ListOfCountries[SID].Name = NewName;
            }
            else
            {
                Console.WriteLine("There is no Country on this ID!");
            }
        }

        public static void ShowCountries(ref Dictionary<int, Country> ListOfCountries)
        {
            foreach (KeyValuePair<int, Country> country in ListOfCountries)
            {
                Console.WriteLine("{0}-{1}", country.Value.ID, country.Value.Name);
            }
        }
    }
}
