using Data.Models;

namespace Lab19WebApi.DTO
{
    public class NotaExtrasaDinDbDto
    {
        public int Id { get; set; }
        public int Valoare { get; set; }
        public DateTime OraAcordarii { get; set; }
        public int CursId { get; set; }
        public Curs Curs { get; set; }
       
    }
}
