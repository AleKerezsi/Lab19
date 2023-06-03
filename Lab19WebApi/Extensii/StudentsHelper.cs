using Data.Models;
using Lab19WebApi.DTO;

namespace Lab19WebApi.Extensii
{
    public static class StudentsHelper
    {
        /// <summary>
        /// Mapeaza modelul Student la DTO-ul asociat
        /// </summary>
        /// <param name="student">Obiect de tipul Student</param>
        /// <returns>DTO pentru obiectul de tip Student, umplut cu info. relevante</returns>
        public static StudentToGetDto ToDto(this Student student)
        {
            if (student == null)
            {
                return null;
            }

            return new StudentToGetDto { Id = student.Id, Nume = student.Nume, Varsta = student.Varsta };
        }

        /// <summary>
        /// Mapeaza DTO-ul asociat cu obiectul Adresa la modelul Adresa
        /// </summary>
        /// <param name="addressToUpdate">Obiect de tipul DTO relativ la obiectul Adresa</param>
        /// <returns>Model nou Adresa</returns>
        public static Adresa ToEntity(this AddressToUpdateDto addressToUpdate)
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
        public static Student ToEntity(this StudentToCreateDto student)
        {
            if (student == null)
            {
                return null;
            }

            return new Student
            {
                Nume = student.Nume,
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
                Varsta = student.Varsta
            };
        }

       
    }
}
