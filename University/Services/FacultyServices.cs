using System;
using System.Collections.Generic;
using System.Linq;

namespace University.Models
{
    static class FacultyServices
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
        static public string AddFaculty(ref Dictionary<int, University> ListOfUniversities, ref Dictionary<int, Faculty> ListOfFaculties)
        {
            Console.WriteLine("Please enter the University's ID where you want to add a city..");
            bool IsThereUniversity = false;
            while (!IsThereUniversity)
            {
                int ID = ConvertToNumber();
                if (ListOfUniversities.Count == 0)
                {
                    return "The list of Universities is Empty..";
                }
                if (!ListOfUniversities.ContainsKey(ID))
                {
                    Console.WriteLine("There is no University on that ID! Try again..");
                }
                else
                {
                    IsThereUniversity = true;
                    bool IsFacultyAlreadyExists = true;
                    while (IsFacultyAlreadyExists)
                    {
                        Console.WriteLine("Please enter the Faculty name..");
                        string Name = Console.ReadLine();
                        CheckNameFormat(ref Name);
                        if (!ListOfFaculties.All(x => Name != x.Value.Name))
                        {
                            Console.WriteLine("The City is  already exists in that Country!!! Try again..");
                        }
                        else
                        {
                            IsFacultyAlreadyExists = false;
                            Faculty faculty = new Faculty
                            {
                                Name = Name,
                                ID = ++City.Count,
                                University = ListOfUniversities[ID]
                            };
                            ListOfFaculties.Add(faculty.ID, faculty);
                            ListOfUniversities[ID].SetFaculty(faculty.ID, faculty);
                        }
                    }
                }
            }
            return "Successfully add!!";
        }

        static public string GetFaculty(ref Dictionary<int, Faculty> ListOfFaculties)
        {
            if (ListOfFaculties.Count == 0)
            {
                return "The list of Faculties is empty..";
            }
            Console.WriteLine("Please enter the Faculty's ID ․․");
            int ID = ConvertToNumber();
            if (ListOfFaculties.ContainsKey(ID))
            {
                return string.Concat(
                ListOfFaculties[ID].ID, "-", ListOfFaculties[ID].Name, " ", ListOfFaculties[ID].University.Name, " ",
                    ListOfFaculties[ID].University.City.Name, ",", ListOfFaculties[ID].University.Country.Name);
            }
            else
            {
                return "There is no Faculty on this ID!";
            }
        }

        static public string RemoveFaculty(ref Dictionary<int, Faculty> ListOfFaculties)
        {
            if (ListOfFaculties.Count == 0)
            {
                return "The list of Faculties is Empty..";
            }
            Console.WriteLine("Please enter the Faculty's ID ․․");
            int ID = ConvertToNumber();
            if (!ListOfFaculties.ContainsKey(ID))
            {
                return "There is no Faculty on that ID!!! ";
            }
            ListOfFaculties.Remove(ID);
            ListOfFaculties[ID].University.Faculties.Remove(ID);
            return "successfully deleted!!";
        }


        static public string UpdateFaculty(ref Dictionary<int, Faculty> ListOfFaculties)
        {
            if (ListOfFaculties.Count == 0)
            {
                return "The list of Faculties is Empty..";
            }
            Console.WriteLine("Please enter the Faculty's ID you want to change․․");
            int ID = ConvertToNumber();
            if (!ListOfFaculties.ContainsKey(ID))
            {
                return "There is no Faculty on that ID!!! ";
            }
            bool IsFacultyAlreadyExists = true;
            while (IsFacultyAlreadyExists)
            {
                Console.WriteLine("Please enter the New City name..");
                string NewName = Console.ReadLine();
                CheckNameFormat(ref NewName);
                if (ListOfFaculties.All(x => NewName != x.Value.Name))
                {
                    IsFacultyAlreadyExists = false;
                    ListOfFaculties[ID].Name = NewName;
                    ListOfFaculties[ID].University.GetFaculty(ID).Name = NewName;
                }
                else
                {
                    Console.WriteLine("The Faculty already exists!!!Try again..");
                }
            }
            return "Successfully updated!!";
        }

        public static void ShowFaculties(ref Dictionary<int, Faculty> ListOfFaculties)
        {
            if (ListOfFaculties.Count == 0)
            {
                Console.WriteLine("The list of Faculties is Empty..");
            }
            else
            {
                foreach (KeyValuePair<int, Faculty> faculty in ListOfFaculties)
                {
                    Console.WriteLine("{0}-{1} {2} {3},{4}", faculty.Value.ID,
                        faculty.Value.Name, faculty.Value.University.Name,
                        faculty.Value.University.City.Name, faculty.Value.University.Country.Name);
                }
            }
        }
    }
}
