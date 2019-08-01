using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace University.Models
{
    static class CityServices
    {
        static public void AddCity(ref Dictionary<int, Country> ListOfCountries, ref Dictionary<int, City> ListOfCities)
        {           
            Console.WriteLine("Please enter the Country's ID where you want to add a city..");
            var IDasStr = Console.ReadLine();
            int ID;
            while (!int.TryParse(IDasStr, out ID))
            {
                Console.WriteLine("This is not a number! Try again..");
                IDasStr = Console.ReadLine();
            }
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
                    if (!ListOfCountries.ContainsKey(ID))
                    {
                        Console.WriteLine("There is no Country on that ID! Try again..");
                        IDasStr = Console.ReadLine();
                        while (!int.TryParse(IDasStr, out ID))
                        {
                            Console.WriteLine("This is not a number! Try again..");
                            IDasStr = Console.ReadLine();
                        }
                    }
                    else
                    {
                        t = false;
                        bool m = true;
                        while (m)
                        {                                
                            bool z = true;
                            Console.WriteLine("Please enter the City name..");
                            string Name = Console.ReadLine();
                            bool allLetters;
                            while (!(allLetters = Name.All(c => Char.IsLetter(c))) || !(Char.IsUpper(Name, 0)))
                            {
                                Console.WriteLine("Invalid name format!! Try again..");
                                Name = Console.ReadLine();
                            }
                            foreach (var item in ListOfCountries[ID].Cities)
                            {
                                if (item.Value.Name == Name)
                                {
                                    z = false;
                                }
                            }
                            if (z)
                            {
                                m = false;
                                City city = new City();
                                city.Name = Name;
                                city.ID = ++City.Count;
                                city.Country = ListOfCountries[ID];
                                ListOfCities.Add(city.ID, city);
                                ListOfCountries[ID].SetCity(city.ID, city);
                            }
                            else
                            {
                                Console.WriteLine("The City is  already exists in that Country!!! Try again..");
                            }
                        }
                    }
                }
            }
        }

        static public void GetCity(ref Dictionary<int, City> ListOfCities)
        {
            bool t = true;
            while (t)
            {
                if (ListOfCities.Count == 0)
                {
                    t = false;
                    Console.WriteLine("The list of Cities is Empty..");
                }
                else
                {
                    Console.WriteLine("Please enter the City's ID ․․");
                    var IDasStr = Console.ReadLine();
                    int ID;
                    while (!int.TryParse(IDasStr, out ID))
                    {
                        Console.WriteLine("This is not a number! Try again..");
                        IDasStr = Console.ReadLine();
                    }
                    if (!ListOfCities.ContainsKey(ID))
                    {
                        Console.Write("There is no City on that ID!!! ");
                    }
                    else
                    {
                        t = false;
                        City city = ListOfCities[ID];
                        Console.WriteLine("{0}-{1}", city.ID, city.Name, city.Country.Name);
                    }
                }
            }
        }

        static public void RemoveCity(ref Dictionary<int, City> ListOfCities)
        {
            bool t = true;
            while (t)
            {
                if (ListOfCities.Count == 0)
                {
                    t = false;
                    Console.WriteLine("The list of Cities is Empty..");
                }
                else
                {
                    Console.WriteLine("Please enter the City's ID ․․");
                    var IDasStr = Console.ReadLine();
                    int ID;
                    while (!int.TryParse(IDasStr, out ID))
                    {
                        Console.WriteLine("This is not a number! Try again..");
                        IDasStr = Console.ReadLine();
                    }
                    if (!ListOfCities.ContainsKey(ID))
                    {
                        Console.Write("There is no City on that ID!!! ");
                    }
                    else
                    {
                        t = false;
                        ListOfCities.Remove(ID);
                    }
                }
            }
        }

        static public void UpdateCity(ref Dictionary<int, City> ListOfCities)
        {
            bool t = true;
            while (t)
            {
                if (ListOfCities.Count == 0)
                {
                    t = false;
                    Console.WriteLine("The list of Cities is Empty..");
                }
                else
                {
                    Console.WriteLine("Please enter the City's ID you want to change․․");
                    var IDasStr = Console.ReadLine();
                    int CID;
                    while (!int.TryParse(IDasStr, out CID))
                    {
                        Console.WriteLine("This is not a number! Try again..");
                        IDasStr = Console.ReadLine();
                    }
                    if (!ListOfCities.ContainsKey(CID))
                    {
                        Console.Write("There is no City on that ID!!! ");
                    }
                    else
                    {
                        t = false;
                        string NewName;
                        Console.WriteLine("Please enter the new City's name..");
                        NewName = Console.ReadLine();
                        bool allLetters;
                        while (!(allLetters = NewName.All(c => Char.IsLetter(c))) || !(Char.IsUpper(NewName, 0)))
                        {
                            Console.WriteLine("Name should contains only letters A-Z, a-z! Try again..");
                            NewName = Console.ReadLine();
                        }
                        ListOfCities[CID].Name = NewName;
                    }
                }
            }
        }

        public static void ShowCities(ref Dictionary<int, City> ListOfCities)
        {
            if (ListOfCities.Count == 0)
            {
                Console.WriteLine("The list of Cities is Empty..");
            }
            else
            {
                foreach (KeyValuePair<int, City> city in ListOfCities)
                {
                    Console.WriteLine("{0}-{1}, {2}", city.Value.ID, city.Value.Name, city.Value.Country.Name);
                }
            }
        }
    }
}
