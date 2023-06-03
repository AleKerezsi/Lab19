using Data.Models;

namespace Lab19WebApi.DTO
{
    public class StudentExtrasDinDbDto
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int Varsta { get; set; }

        public AdresaDto Adresa { get; set; }
    }
}
