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
            using var carsDbContext = new SchoolDbContext();

            var student1 = new Student()
            {
                Nume="Mihaela",
                Prenume="Popescu",
                Varsta=20,
                Adresa=new Adresa() 
                {
                    Oras="Cluj-Napoca",
                    Strada="Plopilor",
                    Numar=65
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

            carsDbContext.Add(student1);
            carsDbContext.Add(student2);
            carsDbContext.Add(student3);
            carsDbContext.Add(student4);
            carsDbContext.Add(student5);

            carsDbContext.SaveChanges();
        }
    }
}
