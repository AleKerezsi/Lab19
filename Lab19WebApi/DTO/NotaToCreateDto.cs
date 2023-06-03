using System.ComponentModel.DataAnnotations;

namespace Lab19WebApi.DTO
{
    public class NotaToCreateDto
    {
        [Range(1, 10)]
        public int Valoare { get; set; }

        [Range(0, int.MaxValue)]
        public int StudentId { get; set; }

        [Range(0, int.MaxValue)]
        public int CursId { get; set; }
    }
}
