using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Data.Entities
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public int Distance { get; set; }
        public void Populate(string name, string surname, string adress, int distance)
        {
            Name = name;
            Surname = surname;
            Adress = adress;
            Distance = distance;
        }
        public override string ToString() => $"{Name} {Surname}\t {Adress}";
    }
}
