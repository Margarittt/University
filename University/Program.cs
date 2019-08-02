using System;
using System.Collections.Generic;
using University.Models;

namespace University
{
    class Program
    {
        static void Main(string[] args)
        {
            string InputSymbol;
            var ListOfCountries = new Dictionary<int, Country>()
            {
                { 1,new Country{Name="Armenia",ID=1 } },
                {2,new Country{Name="England",ID=2 } },
                {3, new Country{Name="Germany",ID=3 } }
            };
            Country.Count = 3;
            var ListOfCities = new Dictionary<int, City>();
            var ListOfUniversities = new Dictionary<int, University>();
            var ListOfFaculties = new Dictionary<int, Faculty>();
            var ListOfLecturers = new Dictionary<int, Lecturer>();
            var ListOfStudents = new Dictionary<int, Student>();

            Console.WriteLine("1a: . .  Add new Country\n" +
                              "1b: . .  Get Country\n" +
                              "1c: . .  Delete Country\n" +
                              "1d: . .  Update Country\n");
            Console.WriteLine("2a: . .  Add new City\n" +
                              "2b: . .  Get City\n" +
                              "2c: . .  Delete City\n" +
                              "2d: . .  Update City\n");
            Console.WriteLine("3a: . .  Add new University\n" +
                              "3b: . .  Get University\n" +
                              "3c: . .  Delete University\n" +
                              "3d: . .  Update University\n");
            Console.WriteLine("4a: . .  Add new Faculty\n" +
                              "4b: . .  Get Faculty\n" +
                              "4c: . .  Delete Faculty\n" +
                              "4d: . .  Update Faculty\n");
            Console.WriteLine("5a: . .  Add new Lecturer\n" +
                              "5b: . .  Get Lecturer\n" +
                              "5c: . .  Delete Lecturer\n" +
                              "5d: . .  Update Lecturer\n");
            Console.WriteLine("6a: . .  Add new Student\n" +
                              "6b: . .  Get Student\n" +
                              "6c: . .  Delete Student\n" +
                              "6d: . .  Update Student\n");
            Console.WriteLine("{0}Help{1}\n", new string('-', 10), new string('-', 10));
            Console.WriteLine("1h: . .  Show Countries\n" +
                              "2h: . .  Show Cities\n" +
                              "3h: . .  Show Universities\n" +
                              "4h: . .  Show Faculties\n" +
                              "5h1: . . Show Lecturers of This Universities\n" +
                              "5h2:. .  Show Lecturers of This Faculties\n"+
                              "6h1:. .  Show Students of This Universities\n" +
                              "6h2:. .  Show Students of This Faculties\n"+
                              "Press q to exit:․․\n");
            do
            {
                InputSymbol = Console.ReadLine();
                switch (InputSymbol)
                {
                    case "3a":
                        UniversityServices.AddUniversity(ref ListOfUniversities, ref ListOfCountries, ref ListOfCities);                        
                        break;
                    case "3b":
                        UniversityServices.GetUniversity(ref ListOfUniversities);
                        break;
                    case "3c":
                        UniversityServices.RemoveUniversity(ref ListOfUniversities);
                        break;
                    case "3d":
                        UniversityServices.UpdateUniversity(ref ListOfUniversities);
                        break;
                    case "2a":
                        Console.WriteLine(CityServices.AddCity(ref ListOfCountries, ref ListOfCities)); 
                        break;
                    case "2b":
                        Console.WriteLine(CityServices.GetCity(ref ListOfCities));
                        break;
                    case "2c":
                        Console.WriteLine(CityServices.RemoveCity(ref ListOfCities));
                        break;
                    case "2d":
                        Console.WriteLine(CityServices.UpdateCity(ref ListOfCities));
                        break;
                    case "1a":
                        Console.WriteLine(CountryServices.AddCountry(ref ListOfCountries));
                        break;
                    case "1b":
                        Console.WriteLine(CountryServices.GetCountry(ref ListOfCountries));
                        break;
                    case "1c":
                        Console.WriteLine(CountryServices.RemoveCountry(ref ListOfCountries));
                        break;
                    case "4a":
                        Console.WriteLine(FacultyServices.AddFaculty(ref ListOfUniversities, ref ListOfFaculties));
                        break;
                    case "4b":
                        Console.WriteLine(FacultyServices.GetFaculty(ref ListOfFaculties));
                        break;
                    case "4c":
                        FacultyServices.RemoveFaculty(ref ListOfFaculties);
                        break;
                    case "4d":
                        FacultyServices.UpdateFaculty(ref ListOfFaculties);
                        break;
                    case "5a":
                        LecturerServices.AddLecturer(ref ListOfUniversities,ref ListOfLecturers);
                        break;
                    case "5b":
                        LecturerServices.GetLecturer(ref ListOfLecturers);
                        break;
                    case "5c":
                        LecturerServices.RemoveLecturer(ref ListOfLecturers);
                        break;
                    case "5d":
                        LecturerServices.UpdateLecturer(ref ListOfLecturers);
                        break;
                    case "1d":
                        Console.WriteLine(CountryServices.UpdateCountry(ref ListOfCountries));
                        break;
                    case "6a":
                        StudentsServices.AddStudent(ref ListOfUniversities, ref ListOfStudents);
                        break;
                    case "6b":
                        StudentsServices.GetStudent(ref ListOfStudents);                      
                        break;
                    case "6c":
                        StudentsServices.RemoveStudent(ref ListOfStudents);
                        break;
                    case "6d":
                        StudentsServices.UpdateStudent(ref ListOfStudents);
                        break;
                    case "1h":
                        CountryServices.ShowCountries(ref ListOfCountries);
                        break;
                    case "2h":
                        CityServices.ShowCities(ref ListOfCities);
                        break;
                    case "3h":
                        UniversityServices.ShowUniversities(ref ListOfUniversities); 
                        break;
                    case "4h":
                        FacultyServices.ShowFaculties(ref ListOfFaculties);
                        break;
                    case "5h1":
                        LecturerServices.LecturersOfThisUniversity(ref ListOfUniversities);
                        break;
                    case "5h2":
                        LecturerServices.LecturersOfThisFaculty(ref ListOfFaculties);
                        break;
                    case "6h1":
                        StudentsServices.StudentsOfThisUniversity(ref ListOfUniversities);
                        break;
                    case "6h2":
                        StudentsServices.StudentsOfThisFaculty(ref ListOfFaculties);
                        break;
                    default:
                        if (InputSymbol == "q") break;
                        else
                        {
                            Console.WriteLine("Please enter correct symbol");
                            break;
                        }
                }
            }
            while (InputSymbol != "q");
        }
    }
}
