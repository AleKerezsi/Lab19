using System.Collections.Generic;

namespace Lab19WebApi.DTO
{
    public class StudentCuMediiDto
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }

        public Dictionary<CursExtrasDinDbDto,int> note = new Dictionary<CursExtrasDinDbDto, int>();
    }
}
