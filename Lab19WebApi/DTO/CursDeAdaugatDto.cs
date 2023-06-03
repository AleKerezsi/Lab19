using System.ComponentModel.DataAnnotations;

namespace Lab19WebApi.DTO
{
    public class CursDeAdaugatDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Numele cursului nu poate fi lasat gol !")]
        public string Nume { get; set; }
    }
}
