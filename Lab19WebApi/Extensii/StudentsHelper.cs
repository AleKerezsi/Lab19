using Data.Models;
using Lab19WebApi.DTO;
using System.Runtime.CompilerServices;

namespace Lab19WebApi.Extensii
{
    public static class StudentsHelper
    {
        /// <summary>
        /// Mapeaza modelul Student la DTO-ul asociat
        /// </summary>
        /// <param name="student">Obiect de tipul Student</param>
        /// <returns>DTO pentru obiectul de tip Student, umplut cu info. relevante</returns>
        public static StudentExtrasDinDbDto ToDto(this Student student)
        {
            if (student == null)
            {
                return null;
            }

            return new StudentExtrasDinDbDto 
            { 
                Id = student.Id, 
                Nume = student.Nume, 
                Prenume = student.Prenume,
                Varsta = student.Varsta,
                //incarc si adresa impreuna cu studentul, folosind o metoda de mapare
                Adresa = student.Adresa?.ToDto() 
            };
        }


        /// <summary>
        /// Mapeaza modelul Adresa la DTO-ul asociat
        /// </summary>
        /// <param name="adresa">Obiectul de tip Adresa</param>
        /// <returns>DTO pentru obiectul de tip Adresa, umplut cu info. relevante</returns>
        public static AdresaDto ToDto(this Adresa adresa)
        {
            return new AdresaDto()
            {
                Id = adresa.Id,
                Oras = adresa.Oras,
                Strada  = adresa.Strada,
                Numar = adresa.Numar,
            };
        }

        /// <summary>
        /// Mapeaza DTO-ul asociat cu obiectul Adresa la modelul Adresa
        /// </summary>
        /// <param name="addressToUpdate">Obiect de tipul DTO relativ la obiectul Adresa</param>
        /// <returns>Model nou Adresa</returns>
        public static Adresa ToEntity(this AdresaDeActualizatDto addressToUpdate)
        {
            if (addressToUpdate == null)
                return null;

            return new Adresa
            {
                Numar = addressToUpdate.Numar,
                Oras = addressToUpdate.Oras,
                Strada = addressToUpdate.Strada
            };
        }

        /// <summary>
        /// Mapeaza DTO-ul asociat cu obiectul Student la modelul Student
        /// </summary>
        /// <param name="student">Obiect de tipul DTO relativ la obiectul Student</param>
        /// <returns>Model nou Student</returns>
        public static Student ToEntity(this StudentDeAdaugatDto student)
        {
            if (student == null)
            {
                return null;
            }

            return new Student
            {
                Nume = student.Nume,
                Prenume= student.Prenume,
                Varsta = student.Varsta
            };
        }
        /// <summary>
        /// Mapeaza DTO-ul asociat cu obiectul Student la modelul Student
        /// </summary>
        /// <param name="student">Obiect de tipul DTO relativ la obiectul Student</param>
        /// <returns>Model nou Student</returns>
        public static Student ToEntity(this StudentToUpdateDto student)
        {
            if (student == null)
            {
                return null;
            }

            return new Student
            {
                Id = student.Id,
                Nume = student.Nume,
                Prenume = student.Prenume,
                Varsta = student.Varsta
            };
        }

       
    }
}
