using Data.DataLayer;
using Data.Models;
using Lab19WebApi.DTO;
using Lab19WebApi.Extensii;
using Microsoft.AspNetCore.Mvc;

namespace Lab19WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : Controller
    {
        /// <summary>
        /// Adauga un curs nou in baza de date
        /// </summary>
        /// <param name="cursName">Numele cursului nou</param>
        [HttpPost()]
        public CursExtrasDinDbDto AddCurs([FromBody] string cursName) => DataLayerSingleton.Instance.AdaugaCurs(cursName).ToDto();

        /// <summary>
        /// Returneaza toate cursurile existente in baza de date
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public IEnumerable<Curs> GetAll() => DataLayerSingleton.Instance.GetAllCursuri();
    }
}
