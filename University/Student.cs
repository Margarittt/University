using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    class Student : IShowable
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public Universityy University { get; set; }
        public Faculty Faculty { get; set; }

        public void Show()
        {
            Console.WriteLine("{0}-{1} ({2}-{3})", Number, Name, University.Name, Faculty.Name);
        }
    }
}
