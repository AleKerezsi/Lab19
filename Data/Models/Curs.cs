using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Curs
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public List<Student> Studenti { get; set; } = new List<Student>();
        public List<Nota> Note { get; set; } = new List<Nota>();
    }
}
