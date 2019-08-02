using System;
using System.Collections.Generic;

namespace University
{
    class Country
    {
        public string Name { get; set; }
        public int ID { get; set; }
        static public int Count { get; set; }
        public Dictionary<int, City> Cities { get; set; }     
        public Dictionary<int, University> Universities { get; set; }

        public Country()
        {
            Cities = new Dictionary<int, City>();
            Universities = new Dictionary<int, University>();
        }

        public City GetCity(int id)
        {
            return Cities[id];
        }

        public void SetCity(int id, City city)
        {
            Cities.Add(id, city);
        }

        public University GetUniversity(int id)
        {
            return Universities[id];
        }

        public void SetUniversity(int id, University university)
        {
            Universities.Add(id, university);
        }
    }
}
