using System;
using System.Collections.Generic;
using System.Linq;

namespace University.Models
{
    static class CityServices
    {
        public static int ConvertToNumber()
        {
            int ID;
            string InputasString = Console.ReadLine();
            while (!int.TryParse(InputasString, out ID))
            {
                Console.WriteLine("This is not a number! Try again..");
                InputasString = Console.ReadLine();
            }
            return ID;
        }
        public static void CheckNameFormat(ref string Name)
        {
            bool IsAllLetters;
            while (!(IsAllLetters = Name.All(c => char.IsLetter(c))) || !char.IsUpper(Name, 0))
            {
                Console.WriteLine("Invalid name format! Try again..");
                Name = Console.ReadLine();
            }
        }

        static public string AddCity(ref Dictionary<int, Country> ListOfCountries, ref Dictionary<int, City> ListOfCities)
        {
            Console.WriteLine("Please enter the Country's ID where you want to add a city..");
            bool IsThereCountry = false;
            while (!IsThereCountry)
            {
                int ID = ConvertToNumber();
                if (ListOfCountries.Count == 0)
                {
                    return "The list of Countries is Empty..";
                }
                if (!ListOfCountries.ContainsKey(ID))
                {
                    Console.WriteLine("There is no Country on that ID! Try again..");
                }
                else
                {
                    IsThereCountry = true;
                    bool IsCityAlreadyExists = true;
                    while (IsCityAlreadyExists)
                    {
                        Console.WriteLine("Please enter the City name..");
                        string Name = Console.ReadLine();
                        CheckNameFormat(ref Name);
                        if (!ListOfCities.All(x => Name != x.Value.Name))
                        {
                            Console.WriteLine("The City is  already exists in that Country!!! Try again..");
                        }
                        else
                        {
                            IsCityAlreadyExists = false;
                            City city = new City
                            {
                                Name = Name,
                                ID = ++City.Count,
                                Country = ListOfCountries[ID]
                            };
                            ListOfCities.Add(city.ID, city);
                            ListOfCountries[ID].SetCity(city.ID, city);
                        }
                    }
                }
            }
            return "Successfully add!!";
        }

        static public string GetCity(ref Dictionary<int, City> ListOfCities)
        {
            if (ListOfCities.Count == 0)
            {
                return "The list of Cities is Empty..";
            }
            Console.WriteLine("Please enter the City's ID ․․");
            int ID = ConvertToNumber();
            return ListOfCities.ContainsKey(ID) ? ListOfCities[ID].Name : "There is no City on that ID!!! ";
        }

        static public string RemoveCity(ref Dictionary<int, City> ListOfCities)
        {
            if (ListOfCities.Count == 0)
            {
                return "The list of Cities is Empty..";
            }

            Console.WriteLine("Please enter the City's ID ․․");
            int ID = ConvertToNumber();
            if (!ListOfCities.ContainsKey(ID))
            {
                return "There is no City on that ID!!! ";
            }
            ListOfCities.Remove(ID);
            ListOfCities[ID].Country.Cities.Remove(ID);
            return "successfully deleted!!";
        }
    

        static public string UpdateCity(ref Dictionary<int, City> ListOfCities)
        {
            if (ListOfCities.Count == 0)
            {
                return "The list of Cities is Empty..";
            }
            Console.WriteLine("Please enter the City's ID you want to change․․");
            int ID = ConvertToNumber();
            if (!ListOfCities.ContainsKey(ID))
            {
                return "There is no City on that ID!!! ";
            }
            bool IsCountryAlreadyExists = true;
            while (IsCountryAlreadyExists)
            {
                Console.WriteLine("Please enter the New City name..");
                string NewName = Console.ReadLine();
                CheckNameFormat(ref NewName);
                if (ListOfCities.All(x => NewName != x.Value.Name))
                {
                    IsCountryAlreadyExists = false;
                    ListOfCities[ID].Name = NewName;
                    ListOfCities[ID].Country.GetCity(ID).Name = NewName;
                }
                else
                {
                    Console.WriteLine("The City already exists!!!Try again..");
                }
            }
            return "Successfully updated!!";
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
