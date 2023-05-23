using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataLayer
{
    public partial class DataLayerSingleton
    {
        #region Singleton
        private DataLayerSingleton()
        {
        }

        private static DataLayerSingleton _instance;

        public static DataLayerSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataLayerSingleton();
                }
                return _instance;
            }
        }
        #endregion

        public List<Student> GetAllStudents()
        {
            using var ctx = new SchoolDbContext();
            return ctx.Students.Include(student => student.Adresa).ToList();
        }

        public Student GetStudentById(int studentId)
        {
            using var ctx = new SchoolDbContext();
            return ctx.Students.FirstOrDefault(student => student.Id == studentId);
        }

        public Student AdaugaStudent(string nume, string prenume, int varsta, string oras, string strada, int numar )
        {
            using var ctx = new SchoolDbContext();

            var adresa = new Adresa()
            {
                Oras = oras,
                Strada  = strada,
                Numar = numar
            };

            var student = new Student
            {
                Nume = nume,
                Prenume = prenume,
                Varsta = varsta,
                Adresa  = adresa,
            };

            ctx.Add(student);
            ctx.SaveChanges();
            return student;
        }

        public Student AdaugaStudent(string nume, string prenume, int varsta, int adresaId)
        {
            using var ctx = new SchoolDbContext();

            var adresa = ctx.Addresses.FirstOrDefault(adresa => adresa.Id == adresaId);

            var student = new Student
            {
                Nume = nume,
                Prenume= prenume,
                Varsta = varsta,   
                Adresa = adresa ?? new Adresa()
            };

            ctx.Add(student);
            ctx.SaveChanges();

            return student;
        }

        public void StergeStudent(int id)
        {
            using var ctx = new SchoolDbContext();

            var studentToRemove = ctx.Students.FirstOrDefault(student => student.Id == id);

            if(studentToRemove  == null) 
            {
                ctx.Remove(studentToRemove);
                ctx.SaveChanges();
            }
        }



        public Student ActualizeazaStudent(int id, string numeNou)
        {
            using var ctx = new SchoolDbContext();

            var studentToUpdate = ctx.Students.FirstOrDefault(student => student.Id == id);

            studentToUpdate.Nume = numeNou;
            ctx.SaveChanges();

            return studentToUpdate;
        }

    }
}
