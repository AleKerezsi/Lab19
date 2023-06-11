using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int Varsta { get; set; }
        public List<Curs> Cursuri { get; set; } = new List<Curs>();
        public Adresa Adresa { get; set; }
    }
}
