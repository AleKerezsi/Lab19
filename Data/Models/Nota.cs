using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public int Valoare { get; set; }
        public DateTime OraAcordarii { get; set; }
        public int CursId { get; set; }
        public Curs Curs { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
