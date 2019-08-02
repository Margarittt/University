using System;
using System.Collections.Generic;

namespace University
{
    class City
    {
        public string Name { get; set; }
        public int ID { get; set; }
        static public int Count { get; set; }
        public Country Country { get; set; }
        public Dictionary<int, University> Universities { get; set; }

        public City()
        {
            Universities = new Dictionary<int, University>();
        }

        public University GetUniversity(int id)
        {
            return Universities[id];
        }

        public void SetUniversity(int id, University university)
        {
            Universities.Add(id,university);
        }
    }
}
