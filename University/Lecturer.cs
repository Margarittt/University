using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    class Lecturer : IShowable
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public void Show()
        {
            Console.WriteLine("{0}-{1}", Number, Name);
        }
    }
}
