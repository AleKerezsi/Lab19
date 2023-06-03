using Data.Exceptii;
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
        private readonly SchoolDbContext ctx = new SchoolDbContext();

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

        #region Functii pentru student
        public IEnumerable<Student> GetAllStudents() => ctx.Students.Include(student => student.Adresa).ToList();

        public Student GetStudentById(int studentId)
        {
            var studentFoundById = ctx.Students.FirstOrDefault(student => student.Id == studentId);
            if (studentFoundById != null)
            {
                throw new StudentNotFoundException($"Studentul cu id-ul {studentId} nu a fost gasit.");
            }
            return studentFoundById;
        }
       

        public Student AdaugaStudent(Student student)
        {
            if (ctx.Students.Any(s => s.Id == student.Id))
            {
                throw new DuplicatException($"Id-ul de student {student.Id} este duplicat.");
            }

            ctx.Add(student);
            ctx.SaveChanges();

            return student;
        }

        public Student ActualizeazaStudent(Student studentToUpdate)
        {
            var student = ctx.Students.FirstOrDefault(s => s.Id == studentToUpdate.Id);
            if (student == null)
            {
                throw new StudentNotFoundException($"Studentul cu id-ul {studentToUpdate.Id} nu a fost gasit.");
            }

            student.Nume = studentToUpdate.Nume;
            student.Varsta = studentToUpdate.Varsta;

            ctx.SaveChanges();

            return student;
        }

        public bool ActualizeazaSauCreeazaAdresaDeStudent(int studentId, Adresa nouaAdresa)
        {
            var student = ctx.Students.Include(s => s.Adresa).FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                throw new StudentNotFoundException($"Studentul cu id-ul {studentId} nu a fost gasit.");
            }

            var adresaCreata = false;
            if (student.Adresa == null)
            {
                student.Adresa = new Adresa();
                adresaCreata = true;
            }
            student.Adresa.Numar = nouaAdresa.Numar;
            student.Adresa.Strada = nouaAdresa.Strada;
            student.Adresa.Oras = nouaAdresa.Oras;

            ctx.SaveChanges();
            return adresaCreata;
        }

        public void StergeStudent(int studentId)
        {
            var student = ctx.Students.FirstOrDefault(s => s.Id == studentId);

            if (student == null)
            {
                throw new StudentNotFoundException($"Studentul cu id-ul {studentId} nu a fost gasit.");
            }

            ctx.Students.Remove(student);

            ctx.SaveChanges();
        }
        #endregion

        #region Functii pentru cursuri
        public Curs AdaugaCurs(string numeCurs)
        {
            var curs = new Curs { Nume = numeCurs };
            ctx.Cursuri.Add(curs);
            ctx.SaveChanges();
            return curs;
        }
        public IEnumerable<Curs> GetAllCursuri() => ctx.Cursuri.ToList();
        #endregion

        #region Functii pentru note
        public void NoteazaStudent(int cursId, int studentId, int valoare)
        {
            if (!ctx.Students.Any(s => s.Id == studentId))
            {
                throw new StudentNotFoundException($"Studentul cu id-ul {studentId} nu a fost gasit.");
            }
            if (!ctx.Cursuri.Any(s => s.Id == cursId))
            {
                throw new CursNotFoundException($"Cursul cu id-ul {cursId} nu a fost gasit.");
            }

            ctx.Note.Add(new Nota { Valoare = valoare, StudentId = studentId, CursId = cursId });
            ctx.SaveChanges();
        }
        #endregion


    }
}
