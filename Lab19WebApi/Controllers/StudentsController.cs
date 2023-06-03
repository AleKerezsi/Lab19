using Data.DataLayer;
using Data.Models;
using Lab19WebApi.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Lab19WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : Controller
    {
        //[HttpPost("")]
        //public Student AddStudent([FromBody] NewStudentDto dateStudent)
        //{
        //    return DataLayerSingleton.Instance.AdaugaStudent(dateStudent.Nume, dateStudent.Prenume, dateStudent.Varsta, dateStudent.Oras, dateStudent.Strada, dateStudent.Numar);
        //}

        //[HttpGet("{id}")]
        //public Student GetById(int id) => DataLayerSingleton.Instance.GetStudentById(id);


        //[HttpGet(Name = "GetAllStudents")]
        //public IEnumerable<Student> GetAllStudents()
        //{
        //    return DataLayerSingleton.Instance.GetAllStudents().ToList();
        //}

        //[HttpPut("{id}")]
        //public Student UpdateStudent(int id, [FromBody] string numeNou)
        //{
        //    return DataLayerSingleton.Instance.ActualizeazaStudent(id, numeNou);
        //}

        //[HttpDelete("{id}")]
        //public void DeleteStudent(int id)
        //{
        //    DataLayerSingleton.Instance.StergeStudent(id);
        //}
    }
}
