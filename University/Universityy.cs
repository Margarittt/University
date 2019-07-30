using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    class Universityy : IShowable
    {
        public string Name { get; set; }
        public int Number { get; set; }
        static public int Count { get; set; }
        public int FacultiesCount { get; set; }
        private Dictionary<int, Faculty> fName;

        public Universityy()
        {
            fName = new Dictionary<int, Faculty>();

        }

        public Faculty GetFaculty(int index)
        {
            return fName[index];
        }

        public void SetFaculty(int number, Faculty faculty)
        {
            fName.Add(number, faculty);
        }

        public Dictionary<int, Faculty> GetFacultiesList()
        {
            return fName;
        }


        public void Show()
        {
            Console.WriteLine("{0}-{1}", Number, Name);
        }
    }

}
