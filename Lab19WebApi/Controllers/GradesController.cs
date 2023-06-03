using Data.DataLayer;
using Data.Exceptii;
using Lab19WebApi.DTO;
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
                DataLayerSingleton.Instance.NoteazaStudent(notaDeAdaugat.Valoare, notaDeAdaugat.StudentId, notaDeAdaugat.CursId);
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

         
    }
}
