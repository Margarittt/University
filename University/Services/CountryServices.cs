using System;
using System.Collections.Generic;
using System.Linq;

namespace University.Models
{
    static class CountryServices
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

        public static string AddCountry(ref Dictionary<int, Country> ListOfCountries)
        {
            bool IsCountryAlreadyExists = true;
            while (IsCountryAlreadyExists) 
            {
                Console.WriteLine("Please enter the Country name..");
                string Name = Console.ReadLine();
                CheckNameFormat(ref Name);
                if (ListOfCountries.All(x => Name != x.Value.Name))
                {
                    IsCountryAlreadyExists = false;
                    Country country = new Country
                    {
                        Name = Name,
                        ID = ++Country.Count
                    };
                    ListOfCountries.Add(country.ID, country);
                }
                else
                {
                    Console.WriteLine("The Country already exists!!!Try again..");
                }
            }
            return "Successfully added!!";
        }

        public static string GetCountry(ref Dictionary<int, Country> ListOfCountries)
        {
            if (ListOfCountries.Count == 0)
            {
                return "The list of Countries is Empty..";
            }
            Console.WriteLine("Please enter the Country's ID ․․");
            int ID = ConvertToNumber();
            return ListOfCountries.ContainsKey(ID) ? ListOfCountries[ID].Name : "There is no Country on that ID!!! ";
        }      

        public static string RemoveCountry(ref Dictionary<int, Country> ListOfCountries)
        {
            if (ListOfCountries.Count == 0)
            {
                return "The list of Countries is Empty..";
            }

            Console.WriteLine("Please enter the Country's ID ․․");
            int ID=ConvertToNumber();           
            if (!ListOfCountries.ContainsKey(ID))
            {
                return "There is no Country on that ID!!! ";
            }
            ListOfCountries.Remove(ID);
            return "successfully deleted!!";
        }

        static public string UpdateCountry(ref Dictionary<int, Country> ListOfCountries)
        {
            if (ListOfCountries.Count == 0)
            {
                return "The list of Countries is Empty..";
            }
            Console.WriteLine("Please enter the Country's ID you want to change․․");
            int ID = ConvertToNumber();
            if (!ListOfCountries.ContainsKey(ID))
            {
                return "There is no Country on that ID!!! ";
            }
            bool IsCountryAlreadyExists = true;
            while (IsCountryAlreadyExists)
            {
                Console.WriteLine("Please enter the New Country name..");
                string NewName = Console.ReadLine();
                CheckNameFormat(ref NewName);
                if (ListOfCountries.All(x => NewName != x.Value.Name))
                {
                    IsCountryAlreadyExists = false;
                    ListOfCountries[ID].Name = NewName;
                }
                else
                {
                    Console.WriteLine("The Country already exists!!!Try again..");
                }
            }
            return "Successfully updated!!";
        }
                   
        public static void ShowCountries(ref Dictionary<int, Country> ListOfCountries)
        {
            if (ListOfCountries.Count == 0)
            {
                Console.WriteLine("The list of Countries is Empty..");
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
