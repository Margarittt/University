using System;
using System.Collections.Generic;

namespace University
{
    class University 
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public Country Country { get; set; }
        static public int Count { get; set; }
        public City City { get; set; }
        public Dictionary<int, Faculty> Faculties { get; set; }
        public Dictionary<int, Lecturer> Lecturers { get; set; } 
        public Dictionary<int, Student> Students { get; set; }

        public University()
        {
            Faculties = new Dictionary<int, Faculty>();
            Lecturers = new Dictionary<int, Lecturer>();
            Students = new Dictionary<int, Student>();
        }

        public Faculty GetFaculty(int id)
        {
            return Faculties[id];
        }

        public void SetFaculty(int id, Faculty faculty)
        {
            Faculties.Add(id, faculty);
        }

        public Student GetStudent(int id)
        {
            return Students[id];
        }

        public void SetStudent(int id,Student student)
        {
            Students.Add(id, student);
        }

        public Lecturer GetLecturer(int id)
        {
            return Lecturers[id];
        }

        public void SetLecturer(int id, Lecturer Lecturer)
        {
            Lecturers.Add(id, Lecturer);
        }
    }
}
