using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    class Faculty : IShowable
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public int LecturersCount { get; set; }
        public int StudentsCount { get; set; }
        private Dictionary<int, Student> sName;
        private Dictionary<int, Lecturer> lName;

        public Faculty()
        {
            sName = new Dictionary<int, Student>();
            lName = new Dictionary<int, Lecturer>();
        }

        public void SetLecturer(Lecturer lecturer)
        {
            lName.Add(lecturer.Number, lecturer);
        }

        public Lecturer GetLecturer(int index)
        {
            return lName[index];
        }

        public Dictionary<int, Lecturer> GetLecturiesList()
        {
            return lName;
        }

        public Student GetStudent(int index)
        {
            return sName[index];
        }

        public void SetStudent(Student student)
        {
            sName.Add(student.Number, student);
        }

        public Dictionary<int, Student> GetStudentsList()
        {
            return sName;
        }

        public void Show()
        {
            Console.WriteLine("{0}-{1}", Number, Name);
        }
    }
}
