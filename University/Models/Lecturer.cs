using System;
using System.Collections.Generic;

namespace University
{
    class Lecturer
    {
        public string Name { get; set; }
        public int ID { get; set; }
        static public int Count { get; set; }
        public University University { get; set; }
        public Faculty Faculty { get; set; }
    }
}
