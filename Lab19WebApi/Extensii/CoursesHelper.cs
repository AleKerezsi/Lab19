using Data.Models;
using Lab19WebApi.DTO;

namespace Lab19WebApi.Extensii
{
    public static class CoursesHelper
    {
        /// <summary>
        /// Mapeaza modelul Curs la DTO-ul asociat
        /// </summary>
        /// <param name="curs">Obiect de tipul Curs</param>
        /// <returns>DTO pentru obiectul de tip Curs, umplut cu info. relevante</returns>
        public static CursExtrasDinDbDto ToDto(this Curs curs)
        {
            if (curs == null)
            {
                return null;
            }

            return new CursExtrasDinDbDto
            {
                Nume = curs.Nume,
            };
        }
    }
}
