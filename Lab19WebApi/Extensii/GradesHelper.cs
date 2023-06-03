using Data.Models;
using Lab19WebApi.DTO;

namespace Lab19WebApi.Extensii
{
    public static class GradesHelper
    {
        /// <summary>
        /// Mapeaza modelul Curs la DTO-ul asociat
        /// </summary>
        /// <param name="curs">Obiect de tipul Curs</param>
        /// <returns>DTO pentru obiectul de tip Curs, umplut cu info. relevante</returns>
        public static NotaExtrasaDinDbDto ToDto(this Nota nota)
        {
            if (nota == null)
            {
                return null;
            }

            return new NotaExtrasaDinDbDto
            {
                Valoare = nota.Valoare,
                OraAcordarii  = nota.OraAcordarii,
                Curs = nota.Curs,
                CursId = nota.CursId,
            };
        }
    }
}
