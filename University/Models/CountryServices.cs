using System;
using System.Collections.Generic;
using System.Linq;

namespace University.Models
{
    static class CountryServices
    {
        static public void AddCountry(ref Dictionary<int, Country> ListOfCountries)
        {
            bool m = true;
            while (m)
            {
                bool t = true; 
                Console.WriteLine("Please enter the Country name..");
                string Name = Console.ReadLine();
                bool allLetters;
                while (!(allLetters = Name.All(c => Char.IsLetter(c))) || !(Char.IsUpper(Name,0)))
                {
                    Console.WriteLine("Invalid name format! Try again..");
                    Name = Console.ReadLine();
                }
                foreach (var item in ListOfCountries)
                {
                    if (item.Value.Name == Name)
                    {
                        t = false;
                    }
                }
                if (t)
                {
                    m = false;
                    Country country = new Country();
                    country.Name = Name;
                    country.ID = ++Country.Count;
                    ListOfCountries.Add(country.ID, country);
                }
                else
                {
                    Console.WriteLine("The Country already exists!!! Try again..");
                }
            }
        }


        static public void GetCountry(ref Dictionary<int, Country> ListOfCountries)
        {
            bool t = true;
            while (t)
            {
                if (ListOfCountries.Count == 0)
                {
                    t = false;
                    Console.WriteLine("The list of Countries is Empty..");
                }
                else
                {
                    Console.WriteLine("Please enter the Country's ID ․․");
                    var IDasStr = Console.ReadLine();
                    int ID;
                    while (!int.TryParse(IDasStr, out ID))
                    {
                        Console.WriteLine("This is not a number! Try again..");
                        IDasStr = Console.ReadLine();
                    }
                    if (!ListOfCountries.ContainsKey(ID))
                    {
                        Console.Write("There is no Country on that ID!!! ");
                    }
                    else
                    {
                        t = false;
                        Country country = ListOfCountries[ID];
                        Console.WriteLine("{0}-{1}", country.ID, country.Name);
                    }
                }
            }
        }

        static public void RemoveCountry(ref Dictionary<int, Country> ListOfCountries)
        {
            bool t = true;
            while (t)
            {
                if (ListOfCountries.Count == 0)
                {
                    t = false;
                    Console.WriteLine("The list of Countries is Empty..");
                }
                else
                {
                    Console.WriteLine("Please enter the Country's ID ․․");
                    var IDasStr = Console.ReadLine();
                    int ID;
                    while (!int.TryParse(IDasStr, out ID))
                    {
                        Console.WriteLine("This is not a number! Try again..");
                        IDasStr = Console.ReadLine();
                    }
                    if (!ListOfCountries.ContainsKey(ID))
                    {
                        Console.Write("There is no Country on that ID!!! ");
                    }
                    else
                    {
                        t = false;
                        ListOfCountries.Remove(ID);
                    }
                }
            }
        }

        static public void UpdateCountry(ref Dictionary<int, Country> ListOfCountries)
        {
            bool t = true;
            while (t)
            {
                if (ListOfCountries.Count == 0)
                {
                    t = false;
                    Console.WriteLine("The list of Countries is Empty..");
                }
                else
                {
                    Console.WriteLine("Please enter the Country's ID you want to change․․");
                    var IDasStr = Console.ReadLine();
                    int SID;
                    while (!int.TryParse(IDasStr, out SID))
                    {
                        Console.WriteLine("This is not a number! Try again..");
                        IDasStr = Console.ReadLine();
                    }
                    if (!ListOfCountries.ContainsKey(SID))
                    {
                        Console.Write("There is no Country on that ID!!! ");
                    }
                    else
                    {
                        t = false;
                        bool m = true;                       
                        while (m)
                        {
                            bool z = true;
                            Console.WriteLine("Please enter the new Country's name..");
                            string NewName = Console.ReadLine();
                            bool allLetters;
                            while (!(allLetters = NewName.All(c => Char.IsLetter(c))) || !(Char.IsUpper(NewName, 0)))
                            {
                                Console.WriteLine("Invalid name format!! Try again..");
                                NewName = Console.ReadLine();
                            }
                            foreach (var item in ListOfCountries)
                            {
                                if (item.Value.Name == NewName)
                                {
                                    z = false;
                                }
                            }
                            if (z)
                            {
                                m = false;
                                ListOfCountries[SID].Name = NewName;
                            }
                            else
                            {
                                Console.WriteLine("The Country already exists!!! Try again..");
                            }
                        }
                    }
                }
            }
        }
        public static void ShowCountries(ref Dictionary<int, Country> ListOfCountries)
        {
            if (ListOfCountries.Count == 0)
            {
                Console.WriteLine("The list of Cities is Empty..");
            }
            else
            {
                foreach (KeyValuePair<int, Country> country in ListOfCountries)
                {
                    Console.WriteLine("{0}-{1}", country.Value.ID, country.Value.Name);
                }
            }
        }
    }
}
