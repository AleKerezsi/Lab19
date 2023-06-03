using Data.DataLayer;
using Data.Exceptii;
using Lab19WebApi.DTO;
using Lab19WebApi.Extensii;
using Microsoft.AspNetCore.Mvc;

namespace Lab19WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : Controller
    {

        /// <summary>
        /// Permite adaugarea unei note pentru un student la un curs
        /// </summary>
        /// <param name="notaDeAdaugat"></param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AddNota([FromBody] NotaDeAdaugatDto notaDeAdaugat)
        {
            try
            {
                DataLayerSingleton.Instance.NoteazaStudent(notaDeAdaugat.CursId, notaDeAdaugat.StudentId, notaDeAdaugat.Valoare);
                return Ok();
            }
            catch (StudentNotFoundException studentNotFoundException)
            {
                return NotFound(studentNotFoundException.Message);
            }
            catch (CursNotFoundException cursNotFoundException)
            {
                return NotFound(cursNotFoundException.Message);
            }
        }

        /// <summary>
        /// Returneaza toate notele unui student
        /// </summary>
        /// <returns>OK - Toate notele studentului dat , 404 - Daca nu exista niciun student in db cu id-ul dat </returns>
        [HttpGet]
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
                return (IEnumerable<NotaExtrasaDinDbDto>) NotFound(studentNotFoundException.Message);
            }
        }

    }
}
