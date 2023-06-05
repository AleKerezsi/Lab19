using System.ComponentModel.DataAnnotations;

namespace Lab19WebApi.DTO
{
    public class StudentDeAdaugatDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Numele studentului nu poate fi lasat gol !")]
        public string Nume { get; set; }
      
        [Required(AllowEmptyStrings = false, ErrorMessage = "Prenumele studentului nu poate fi lasat gol !")]
        public string Prenume { get; set; }

        [Range(1, 100)]
        public int Varsta { get; set; }
    }
}
