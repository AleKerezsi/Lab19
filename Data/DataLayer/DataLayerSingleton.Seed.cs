using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataLayer
{
    public partial class DataLayerSingleton
    {
        public void Seed()
        {
            SeedStudenti(ctx);
            SeedCursuri(ctx);
        }

        private void SeedCursuri(SchoolDbContext ctx)
        {
            var curs1 = new Curs()
            {
                Nume = "Dezvoltare software in .NET framework"
            };

            var curs2 = new Curs()
            {
                Nume = "Dezvoltare software folosind limbajul Java"
            };

            var curs3 = new Curs()
            {
                Nume = "Istoria informaticii"
            };

            var curs4 = new Curs()
            {
                Nume = "Educatie fizica si sport"
            };

            var curs5 = new Curs()
            {
                Nume = "Limba Engleza"
            };

            ctx.Add(curs1);
            ctx.Add(curs2);
            ctx.Add(curs3);
            ctx.Add(curs4);
            ctx.Add(curs5);

            ctx.SaveChanges();

        }

        public void SeedStudenti(SchoolDbContext ctx) 
        {
            var student1 = new Student()
            {
                Nume = "Mihaela",
                Prenume = "Popescu",
                Varsta = 20,
                Adresa = new Adresa()
                {
                    Oras = "Cluj-Napoca",
                    Strada = "Plopilor",
                    Numar = 65
                }
            };

            var student2 = new Student()
            {
                Nume = "Iris",
                Prenume = "Moldovan",
                Varsta = 21,
                Adresa = new Adresa()
                {
                    Oras = "Cluj-Napoca",
                    Strada = "Nucilor",
                    Numar = 7
                }
            };

            var student3 = new Student()
            {
                Nume = "Oana",
                Prenume = "Ciondocan",
                Varsta = 20,
                Adresa = new Adresa()
                {
                    Oras = "Floresti",
                    Strada = "Rozelor",
                    Numar = 180
                }
            };

            var student4 = new Student()
            {
                Nume = "Alex",
                Prenume = "Babu",
                Varsta = 21,
                Adresa = new Adresa()
                {
                    Oras = "Floresti",
                    Strada = "Crizantemelor",
                    Numar = 192
                }
            };

            var student5 = new Student()
            {
                Nume = "Nicoleta",
                Prenume = "Savu",
                Varsta = 21,
                Adresa = new Adresa()
                {
                    Oras = "Feleacu",
                    Strada = "Spiralei",
                    Numar = 14
                }
            };

            ctx.Add(student1);
            ctx.Add(student2);
            ctx.Add(student3);
            ctx.Add(student4);
            ctx.Add(student5);

            ctx.SaveChanges();
        }
    }
}
