using System;
using System.Collections.Generic;

namespace University
{
    class Faculty
    {
        public string Name { get; set; }
        public int ID { get; set; }
        static public int Count;
        public University University { get; set; }  
        public Dictionary<int, Lecturer> Lecturers { get; set; }
        public Dictionary<int, Student> Students { get; set; }

        public Faculty()
        {
            Lecturers = new Dictionary<int, Lecturer>();
            Students = new Dictionary<int, Student>();
        }

        public Lecturer GetLecturer(int id)
        {
            return Lecturers[id];
        }

        public void SetLecturer(int id, Lecturer Lecturer)
        {
            Lecturers.Add(id, Lecturer);
        }

        public Student GetStudent(int id)
        {
            return Students[id];
        }

        public void SetStudent(int id, Student student)
        {
            Students.Add(id, student);
        }
    }
}
