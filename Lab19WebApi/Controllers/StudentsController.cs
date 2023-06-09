﻿using Data.DataLayer;
using Data.Exceptii;
using Data.Models;
using Lab19WebApi.DTO;
using Lab19WebApi.Extensii;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;

namespace Lab19WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        #region CRUD (Create Read Update Delete) Operations
        /// <summary>
        /// Returneaza toti studentii din baza de date
        /// </summary>
        /// <returns>OK - Toti studentii din baza de date , 204 - Daca nu exista niciun student in db / "no content" </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<StudentExtrasDinDbDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(IEnumerable<StudentExtrasDinDbDto>))]
        public IEnumerable<StudentExtrasDinDbDto> GetAllStudents()
        {
            return DataLayerSingleton.Instance.GetAllStudents().Select(student => student.ToDto()).ToList();
        }

        /// <summary>
        /// Returneaza un student dupa un Id dat
        /// </summary>
        /// <param name="id">Id-ul studentului dorit</param>
        /// <returns>Studentul gasit cu informatiile lui </returns>
        [HttpGet("/api/students/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentExtrasDinDbDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]

        public ActionResult<StudentExtrasDinDbDto> GetStudentById([Range(1, int.MaxValue)] int id)
        {
            try
            {
                return Ok(DataLayerSingleton.Instance.GetStudentById(id).ToDto());
            }
            catch (StudentNotFoundException studentNotFoundException)
            {
                return NotFound(studentNotFoundException.Message);
            }
        }

        /// <summary>
        /// Returneaza adresa unui student
        /// </summary>
        /// <param name="id">Id-ul studentului a carei adresa vrem sa o gasim</param>
        /// <returns>Adresa studentului </returns>
        [HttpGet("/api/students/{id}/address")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentExtrasDinDbDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]

        public ActionResult<AdresaDto> GetAddressByStudentId([Range(1, int.MaxValue)] int id)
        {
            try
            {
                return Ok(DataLayerSingleton.Instance.GetAddressByStudentId(id).ToDto());
            }
            catch (StudentNotFoundException studentNotFoundException)
            {
                return NotFound(studentNotFoundException.Message);
            }
        }

        /// <summary>
        /// Creeaza un student nou
        /// </summary>
        /// <param name="studentDeAdaugat">Studentul nou care va fi creat</param>
        /// <returns>Studentul nou creat</returns>
        [HttpPost]
        public StudentExtrasDinDbDto CreateStudent([FromBody] StudentDeAdaugatDto studentDeAdaugat) => DataLayerSingleton.Instance.AdaugaStudent(studentDeAdaugat.ToEntity()).ToDto();

        /// <summary>
        /// Actualizeaza un student
        /// </summary>
        /// <param name="studentDeActualizat"></param>
        /// <returns>Studentul actualizat impreuna cu informatiile lui</returns>
        [HttpPatch]
        public StudentExtrasDinDbDto UpdateStudent([FromBody] StudentToUpdateDto studentDeActualizat) => DataLayerSingleton.Instance.ActualizeazaStudent(studentDeActualizat.ToEntity()).ToDto();

        /// <summary>
        /// Aplica modificari unei Adrese pentru un student, sau creeaza o adresa noua completa in cazul in care studentul nu are
        /// </summary>
        /// <param name="id">Id-ul Adresei care se doreste actualizat</param>
        /// <param name="adresaDeActualizat">DTO-ul asociat cu Adresa unui student care se doreste actualizata</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult UpdateStudentAddress([FromRoute] int id, [FromBody] AdresaDeActualizatDto adresaDeActualizat)
        {

            if (DataLayerSingleton.Instance.ActualizeazaSauCreeazaAdresaDeStudent(id, adresaDeActualizat.ToEntity()))
            {
                return Created($"Adresa cu id-ul {id} a fost actualizata, sau creata in cazul in care nu exista, cu succes !", null);
            }
            return NoContent();
        }

        /// <summary>
        /// Sterge un student dupa Id-ul dat
        /// </summary>
        /// <param name="id">Id-ul relativ la studentul care se doreste sters din baza de date</param>
        /// <returns>OK - Daca studentul a fost sters corect, 404 - Daca studentul nu a fost gasit</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteStudent([Range(1, int.MaxValue)] int id)
        {
            try
            {
                DataLayerSingleton.Instance.StergeStudent(id);
            }
            catch (StudentNotFoundException studentNotFoundException)
            {
                return NotFound(studentNotFoundException.Message);
            }
            return Ok();
        }
        #endregion


        /// <summary>
        /// Returneaza toate notele unui student
        /// </summary>
        /// <returns>OK - Toate notele studentului dat , 404 - Daca nu exista niciun student in db cu id-ul dat </returns>
        [HttpGet("/api/students/{studentId}/allGrades")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<NotaExtrasaDinDbDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<NotaExtrasaDinDbDto> GetAllGradesForStudentId(int studentId)
        {
            try
            {
                return DataLayerSingleton.Instance.ExtrageToateNotelePentruStudentulCuId(studentId).Select(nota => nota.ToDto()).ToList();
            }
            catch (StudentNotFoundException studentNotFoundException)
            {
                return (IEnumerable<NotaExtrasaDinDbDto>)NotFound(studentNotFoundException.Message);
            }
        }

        /// <summary>
        /// Returneaza toate notele unui student dintr-un curs
        /// </summary>
        /// <returns>OK - Toate notele studentului dat , 404 - Daca nu exista niciun student in db cu id-ul dat </returns>
        [HttpGet("/api/students/{studentId}/allGrades/{courseId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<NotaExtrasaDinDbDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<NotaExtrasaDinDbDto> GetAllGradesForStudentInCourse(int studentId, int courseId)
        {
            try
            {
                return DataLayerSingleton.Instance.ExtrageToateNoteleCuStudentIdSiCursId(studentId, courseId).Select(nota => nota.ToDto()).ToList();
            }
            catch (StudentNotFoundException studentNotFoundException)
            {
                return (IEnumerable<NotaExtrasaDinDbDto>)NotFound(studentNotFoundException.Message);
            }
        }

        /// <summary>
        /// Returneaza toate mediile unui student pentru fiecare curs in care a participat
        /// </summary>
        /// <returns>OK - Toate cursurile in care studentul a participat, impreuna cu media notelor acestora , 404 - Daca nu exista niciun student in db cu id-ul dat </returns>
        [HttpGet("/api/students/{studentId}/averageGrades")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<NotaExtrasaDinDbDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Dictionary<string, double>> GetAllGradesAveragesForStudent(int studentId)
        {
            var averageGrades = new Dictionary<string, double>();

            try
            {
                var groupedData = DataLayerSingleton.Instance
                    .ExtrageNoteStudentGrupatePerCursPentruStudentCuId(studentId)
                    .SelectMany(data => data).ToList();

                var coursesStudentEnrolledIn = groupedData.DistinctBy(x => x.Curs.Id).ToList();

                foreach (var groupedDataItem in coursesStudentEnrolledIn)
                {
                    averageGrades.Add(groupedDataItem.Curs.Nume, ComputeAverageGrade(groupedData, groupedDataItem.Curs.Nume));
                }

                return averageGrades;

            }
            catch (StudentNotFoundException studentNotFoundException)
            {
                return NotFound(studentNotFoundException.Message);
            }
        }

        protected Dictionary<string, double> GetAllGradesAveragesForStudentId(int studentId)
        {
            var averageGrades = new Dictionary<string, double>();

            var groupedData = DataLayerSingleton.Instance
                .ExtrageNoteStudentGrupatePerCursPentruStudentCuId(studentId)
                .SelectMany(data => data).ToList();

            var coursesStudentEnrolledIn = groupedData.DistinctBy(x => x.Curs.Id).ToList();

            foreach (var groupedDataItem in coursesStudentEnrolledIn)
            {
                averageGrades.Add(groupedDataItem.Curs.Nume, ComputeAverageGrade(groupedData, groupedDataItem.Curs.Nume));
            }

            return averageGrades;

        }

        private double ComputeAverageGrade(List<Nota> groupedData, string courseName)
        {
            var average = groupedData.Where(data => data.Curs.Nume == courseName).Average(x => x.Valoare);
            return average;
        }

        /// <summary>
        /// Returneaza studentii ordonati dupa medii - specificati 'desc' pentru parametrul sortOrder daca doriti descendent, default se face ascendent
        /// </summary>
        /// <returns>OK - Toti studentii ordonati dupa medii </returns>
        [HttpGet("/api/students/studentsByAverageGrades")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<StudentExtrasDinDbDto>))]
        public IEnumerable<StudentExtrasDinDbCuMediiDto> GetStudentsByAscendingAverageGrade(string sortOrder = "asc")
        {
            var students = DataLayerSingleton.Instance.GetAllStudents().Select(student => student).ToList();

            var cursuriCount = DataLayerSingleton.Instance.GetAllCursuri().ToList().Count();

            var studentiMedii = new Dictionary<Student, double>();

            foreach (var student in students) 
            {
                //ne folosim de codul pe care il avem deja la celalalt endpoint
                var studentGradesAverages = GetAllGradesAveragesForStudentId(student.Id);

                //facem o medie aritmetica aici, desi in mod normal ar trebui sa tinem cont si de creditele cursului si sa facem o medie ponderata ...
                studentiMedii.Add(student, studentGradesAverages.Sum(nota => nota.Value) / cursuriCount);
            }

            var orderedData = (sortOrder == "desc" ? studentiMedii.OrderByDescending(pair => pair.Value).ToList() : studentiMedii.OrderBy(pair => pair.Value).ToList());

            var finalData = new List<StudentExtrasDinDbCuMediiDto>();

            foreach(var student in orderedData) 
            {
                finalData.Add(new StudentExtrasDinDbCuMediiDto()
                {
                    Nume = student.Key.Nume,
                    Prenume = student.Key.Prenume,
                    Media = student.Value
                });
            }

            return finalData;
        }
    }
}
